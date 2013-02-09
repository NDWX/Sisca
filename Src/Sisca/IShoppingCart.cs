
namespace Pug.Sisca
{
	public interface IShoppingCart<I, L, P, Pp, Li, La, S> : Cartage.ICart<I, L, Li, La, S>
		where I : Cartage.ICartInfo
		where L : ICartLine<P, Li, La>
		where Pp : IProductInfoProvider<P>
		where P : IProductInfo
		where Li : ICartLineInfo<P>
		where La : Cartage.ICartLineAttributeInfo
		where S : ICartSummary
	{
		//string AddItems(string productCode, decimal quantity, System.Collections.Generic.IDictionary<string, string> attributes);
		//void Clear();
		//void Dispose();
		//CartSummary GetCartSummary();
		//CartLine GetLine(string identifier);
		//System.Collections.Generic.ICollection<CartLineInfo> GetLines();
		//Pug.Cartage.ICartInfo Info { get; }
		//void RemoveLine(string identifier);
		//void UpdateLine(string line, decimal quantity, System.Collections.Generic.IDictionary<string, string> attributes);
	}

	public interface IShoppingCart<P, Pp> : IShoppingCart<Cartage.ICartInfo, ICartLine<P>, P, Pp, ICartLineInfo<P>, Cartage.ICartLineAttributeInfo, ICartSummary>
		where Pp : IProductInfoProvider<P>
		where P : IProductInfo
	{
	}

	public interface IShoppingCart<P> : IShoppingCart<Cartage.ICartInfo, ICartLine<P>, P, IProductInfoProvider<P>, ICartLineInfo<P>, Cartage.ICartLineAttributeInfo, ICartSummary>
		where P : IProductInfo
	{
	}

	public interface IShoppingCart : IShoppingCart<Cartage.ICartInfo, ICartLine, IProductInfo, IProductInfoProvider, ICartLineInfo, Cartage.ICartLineAttributeInfo, ICartSummary>
	{
	}
}
