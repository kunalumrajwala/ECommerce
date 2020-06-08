 namespace Core.Entities
{
    public class Products : BaseEntity
    {
       public string Name { get; set; }
       public string Description { get; set; }
       public decimal price { get; set; }
       public string pictureURL { get; set; }
       public ProductType ProductType { get; set; }
       public int ProductTypeId { get; set; }
       public ProductBrand ProductBrand { get; set; }
       public int ProductBrandId { get; set; }
    }
}