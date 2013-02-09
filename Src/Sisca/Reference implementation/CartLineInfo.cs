
namespace Pug.Sisca
{
	class CartLineInfo<P> : ICartLineInfo<P>
		where P : IProductInfo
	{
		Cartage.ICartLineInfo cartLine;
		P productInfo;

		public CartLineInfo(Cartage.ICartLineInfo cartLine, P productInfo)
		{
			this.cartLine = cartLine;
			this.productInfo = productInfo;
		}

		#region ICartLine Members

		public string Identifier
		{
			get { return cartLine.Identifier; }
		}

		public string ProductCode
		{
			get { return cartLine.ProductCode; }
		}

		public decimal Quantity
		{
			get { return cartLine.Quantity; }
		}

		public decimal PriceForQuantity
		{
			get
			{
				return Quantity * productInfo.UnitPrice;
			}
		}

		#endregion

		public P ProductInfo
		{
			get { return productInfo; }
		}
	}
}
