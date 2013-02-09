

namespace Pug.Sisca
{
	class CartSummary : Pug.Sisca.ICartSummary
	{
		decimal totalProducts, totalItems, totalPrice;

		public CartSummary(decimal totalProducts, decimal totalItems, decimal totalPrice)
		{
			this.totalProducts = totalProducts;
			this.totalItems = totalItems;
			this.totalPrice = totalPrice;
		}
		public decimal TotalProducts
		{
			get
			{
				return totalProducts;
			}
		}
		public decimal TotalItems
		{
			get
			{
				return totalItems;
			}
		}
		public decimal TotalPrice
		{
			get
			{
				return totalPrice;
			}
		}
	}
}
