namespace Pug.Sisca
{
	public interface ICartLineInfo<P> : Cartage.ICartLineInfo
		where P : IProductInfo
	{
		P ProductInfo { get; }
	}

	public interface ICartLineInfo : ICartLineInfo<IProductInfo>
	{
	}
}
