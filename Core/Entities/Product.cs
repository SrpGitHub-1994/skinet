
namespace Core.Entities
{
    public class Product:BaseEntity
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public ProductType ProductType { get; set; }
        public int ProdTypeId { get; set; }
        public ProductBrand ProductBrand { get; set; }
        public int ProdBrandid { get; set; }

    }

}