
namespace Pug.Sisca
{
	public interface IProductInfo
	{
		global::System.Collections.Generic.IDictionary<string, string> Attributes { get; }
		string Category { get; }
		string Description { get; }
		string Identifier { get; }
		string Image { get; }
		string Name { get; }
		decimal UnitPrice { get; }
	}
}
