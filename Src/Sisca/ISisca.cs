namespace Pug.Sisca
{
	public interface ISisca<C, I, L, P, Pp, Li, La, S> : Cartage.ICartage<C, I, L, Li, La, S>
		where C : IShoppingCart<I, L, P, Pp, Li, La, S>
		where I : Cartage.ICartInfo
		where L : ICartLine<P, Li, La>
		where Pp : IProductInfoProvider<P>
		where P : IProductInfo
		where Li : ICartLineInfo<P>
		where La : Cartage.ICartLineAttributeInfo
		where S : ICartSummary
	{
	}

	public interface ISisca<P, Pp> : ISisca<IShoppingCart<P, Pp>, Cartage.ICartInfo, ICartLine<P>, P, Pp, ICartLineInfo<P>, Cartage.ICartLineAttributeInfo, ICartSummary>
		where Pp : IProductInfoProvider<P>
		where P : IProductInfo
	{
	}

	public interface ISisca<P> : ISisca<IShoppingCart<P>, Cartage.ICartInfo, ICartLine<P>, P, IProductInfoProvider<P>, ICartLineInfo<P>, Cartage.ICartLineAttributeInfo, ICartSummary>
		where P : IProductInfo
	{
	}

	public interface ISisca : ISisca<IShoppingCart, Cartage.ICartInfo, ICartLine, IProductInfo, IProductInfoProvider, ICartLineInfo, Cartage.ICartLineAttributeInfo, ICartSummary>
	{
	}
}
