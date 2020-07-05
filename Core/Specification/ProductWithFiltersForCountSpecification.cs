using Core.Entities;

namespace Core.Specification
{
    public class ProductWithFiltersForCountSpecification : BaseSpecification<Products>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecParams productSpecParams)
                    : base(x =>
                (string.IsNullOrEmpty(productSpecParams.Search) || x.Name.ToLower().Contains(productSpecParams.Search))
                 && (!productSpecParams.brandId.HasValue || x.ProductBrandId == productSpecParams.brandId) &&
                (!productSpecParams.typeId.HasValue || x.ProductTypeId == productSpecParams.typeId)
            )
        {
        }
    }
}