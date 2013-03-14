using System.Collections.Generic;
using System.Linq;


namespace Pug.Sisca
{
	class ShoppingCart<P, Pp> : IShoppingCart<P, Pp>
		where P : IProductInfo
		where Pp : IProductInfoProvider<P>
	{
		Cartage.ICart _cart;
		Pp productInfoProvider;

		Dictionary<string, string> productLines;

		public ShoppingCart(Cartage.ICart cart, Pp productInfoProvider)
		{
			_cart = cart;
			this.productInfoProvider = productInfoProvider;

			productLines = new Dictionary<string, string>();
		}

		#region IDisposable Members

		public void Dispose()
		{
			_cart.Dispose();
		}

		#endregion

		#region ICart<ICartInfo,CartLine> Members

		public string AddItems(string productCode, decimal quantity, IDictionary<string, string> attributes)
		{
			string lineIdentifier = null;

			decimal newQuantity = quantity;

			if (productLines.ContainsKey(productCode))
			{
				lineIdentifier = productLines[productCode];
				Cartage.ICartLine cartLine = _cart.GetLine(lineIdentifier);

				newQuantity = cartLine.Info.Quantity + quantity;

				_cart.UpdateLine(lineIdentifier, newQuantity > 0 ? newQuantity : 0, attributes);
			}
			else
			{
				lineIdentifier = _cart.AddItems(productCode, newQuantity > 0 ? newQuantity : 0, attributes);
				productLines.Add(productCode, lineIdentifier);
			}

			return lineIdentifier;
		}

		public ICollection<ICartLineInfo<P>> GetLines()
		{
			ICollection<Cartage.ICartLineInfo> cartLineInfos = _cart.GetLines();

			IEnumerable<CartLineInfo<P>> cartLines = from cartLine in cartLineInfos
													 select new CartLineInfo<P>(cartLine, productInfoProvider.GetProductInfo(cartLine.ProductCode));

			return cartLines.ToArray();
		}

		public void Clear()
		{
			_cart.Clear();
		}

		public Cartage.ICartInfo Info
		{
			get { return _cart.Info; }
		}

		public ICartLine<P> GetLine(string identifier)
		{
			Cartage.ICartLine cartLine = _cart.GetLine(identifier);

			return new CartLine<P>(cartLine, productInfoProvider.GetProductInfo(cartLine.Info.ProductCode));
		}

		public void UpdateLine(string line, decimal quantity, IDictionary<string, string> attributes)
		{
			_cart.UpdateLine(line, quantity, attributes);
		}

		public void RemoveLine(string identifier)
		{
			_cart.RemoveLine(identifier);
		}
		
		public ICartSummary GetCartSummary()
		{
			ICollection<Cartage.ICartLineInfo> cartLineInfos = _cart.GetLines();

			IEnumerable<CartLine<P>> cartLines = from cartLine in cartLineInfos
												 select new CartLine<P>(new Cartage.CartLine(cartLine, null), productInfoProvider.GetProductInfo(cartLine.ProductCode));

			CartSummary summary = (from cartLine in cartLines group cartLine by "" into linesSummary select new CartSummary((decimal)linesSummary.Count(), linesSummary.Sum(l => l.Info.Quantity), linesSummary.Sum(l => l.PriceForQuantity))).First();

			return summary;
		}

		public void MarkAsFinalized()
		{
			_cart.MarkAsFinalized();
		}

		#endregion

	}
}
