using Cartage = Pug.Cartage;

namespace Pug.Sisca
{
	public interface ICartSummary : Cartage.ICartSummary
	{
		//decimal TotalItems { get; }
		decimal TotalPrice { get; }
		//decimal TotalProducts { get; }
	}
}
