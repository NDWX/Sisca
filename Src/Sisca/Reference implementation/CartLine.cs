using System.Collections.Generic;


namespace Pug.Sisca
{
	class CartLine<P> : ICartLine<P>
		where P : IProductInfo
	{
		Cartage.ICartLine cartLine;
		//P productInfo;

		CartLineInfo<P> info;

		public CartLine(Cartage.ICartLine cartLine, P productInfo)
		{
			this.cartLine = cartLine;
			//this.productInfo = productInfo;
			info = new CartLineInfo<P>(cartLine.Info, productInfo);
		}

		#region Cartage.ICartLine<Cartage.CartLineInfo, Cartage.ICartLineAttributeInfo> Members

		public IDictionary<string, Cartage.ICartLineAttributeInfo> Attributes
		{
			get { return cartLine.Attributes; }
		}

		public ICartLineInfo<P> Info
		{
			get
			{
				return info;
			}
		}

		#endregion

		public decimal PriceForQuantity
		{
			get
			{
				return this.info.ProductInfo.UnitPrice * this.info.Quantity;
			}
		}
	}
}
