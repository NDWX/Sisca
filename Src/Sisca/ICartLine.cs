namespace Pug.Sisca
{
	public interface ICartLine<P, I, A> : Cartage.ICartLine<I, A>
		where P : IProductInfo
		where I : ICartLineInfo<P>
		where A : Cartage.ICartLineAttributeInfo
	{
		decimal PriceForQuantity { get; }
	}

	public interface ICartLine<P> : ICartLine<P, ICartLineInfo<P>, Cartage.ICartLineAttributeInfo>
		where P : IProductInfo
	{
	}

	public interface ICartLine : ICartLine<IProductInfo, ICartLineInfo, Cartage.ICartLineAttributeInfo>
	{
	}
}
