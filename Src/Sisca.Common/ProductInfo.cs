using System.Collections.Generic;

namespace Pug.Sisca
{
	public class ProductInfo : IProductInfo
	{
		string identifier, name, description, category, image;
		decimal unitPrice;
		IDictionary<string, string> attributes;

		public ProductInfo(string identifier, string name, string description, string category, string image, decimal unitPrice, IDictionary<string, string> attributes)
		{
			this.identifier = identifier;
			this.category = category;
			this.name = name;
			this.description = description;
			this.image = image;
			this.attributes = attributes;
			this.unitPrice = unitPrice;
		}
		public string Identifier
		{
			get
			{
				return identifier;
			}
		}
		public string Name
		{
			get
			{
				return name;
			}
		}
		public string Description
		{
			get
			{
				return description;
			}
		}
		public string Category
		{
			get
			{
				return category;
			}
		}
		public string Image
		{
			get
			{
				return image;
			}
		}
		public decimal UnitPrice
		{
			get
			{
				return unitPrice;
			}
		}
		public IDictionary<string, string> Attributes
		{
			get
			{
				return attributes;
			}
		}
	}
}
