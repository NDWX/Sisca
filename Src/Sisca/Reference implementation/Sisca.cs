using System;
using System.Collections.Generic;

using Pug.Application.Data;
using Pug.Application.Security;

namespace Pug.Sisca
{
	public class Sisca<Sp, P, Pp> : Pug.Sisca.ISisca<P, Pp>
        where Sp: Cartage.ICartInfoStoreProvider
		where P : IProductInfo
		where Pp : IProductInfoProvider<P>
	{
		Pp productInfoProvider;
		Cartage.ICartage cartage;

		bool disposeBase = false;

		public Sisca(Cartage.ICartage cartage, Pp productInfoProvider)
		{
			this.productInfoProvider = productInfoProvider;
			this.cartage = cartage;
		}

		public Sisca(IApplicationData<Sp> storeProvider, ISecurityManager securityManager, Pp productInfoProvider)
			: this(new Cartage.Cartage<Sp>(storeProvider, securityManager), productInfoProvider)
		{
			disposeBase = true;
		}

		#region IDisposable Members

		public void Dispose()
		{
			if (disposeBase)
				cartage.Dispose();
		}

		#endregion

		#region ICartage<ShoppingCart,ICartInfo,CartLine> Members

		public bool CartExists(string identifier)
		{
			return cartage.CartExists(identifier);
		}

		public IShoppingCart<P, Pp> GetCart(string identifier = "")
		{
			Cartage.ICart cart;

			if (string.IsNullOrEmpty(identifier))
				cart = cartage.RegisterCart();
			else if (cartage.CartExists(identifier))
				cart = cartage.GetCart(identifier);
			else
				cart = cartage.RegisterCart(identifier);

			return new ShoppingCart<P, Pp>(cartage.GetCart(identifier), productInfoProvider);
		}

		public ICollection<Cartage.ICartInfo> GetCarts(Range<DateTime> creationPeriod, Range<DateTime> modificationPeriod)
		{
			return cartage.GetCarts(creationPeriod, modificationPeriod);
		}

		public IShoppingCart<P, Pp> RegisterCart()
		{
			Cartage.ICart cart;

			cart = cartage.RegisterCart();

			return new ShoppingCart<P, Pp>(cart, productInfoProvider);
		}

		public IShoppingCart<P, Pp> RegisterCart(string identifier)
		{
			Cartage.ICart cart;

			cart = cartage.RegisterCart(identifier);

			return new ShoppingCart<P, Pp>(cartage.GetCart(identifier), productInfoProvider);
		}

		public void DeleteCart(string identifier)
		{
			cartage.DeleteCart(identifier);
		}

		#endregion
	}

	public class Sisca<Sp, P> : Sisca<Sp, P, IProductInfoProvider<P>>
        where Sp : Cartage.ICartInfoStoreProvider
		where P : IProductInfo
	{
		public Sisca(Cartage.ICartage cartage, IProductInfoProvider<P> productInfoProvider)
			: base(cartage, productInfoProvider)
		{
		}

		public Sisca(IApplicationData<Sp> storeProvider, ISecurityManager securityManager, IProductInfoProvider<P> productInfoProvider)
			: base(storeProvider, securityManager, productInfoProvider)
		{
		}
	}

    public class Sisca<Sp> : Sisca<Sp, IProductInfo>
        where Sp : Cartage.ICartInfoStoreProvider
	{
		public Sisca(Cartage.ICartage cartage, IProductInfoProvider productInfoProvider)
			: base(cartage, productInfoProvider)
		{
		}

		public Sisca(IApplicationData<Sp> storeProvider, ISecurityManager securityManager, IProductInfoProvider productInfoProvider)
			: base(storeProvider, securityManager, productInfoProvider)
		{
		}
	}
}
