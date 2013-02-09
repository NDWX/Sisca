
namespace Pug.Sisca
{
	public interface IProductInfoProvider<P>
		where P : IProductInfo
	{
		P GetProductInfo(string identifier);
	}

	public interface IProductInfoProvider : IProductInfoProvider<IProductInfo>
	{
	}
}
