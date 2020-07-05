using System;
using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specification
{
    public class ProductTypeandBrandSpecification : BaseSpecification<Products>
    {
        public ProductTypeandBrandSpecification(ProductSpecParams productSpecParams)
            : base(x =>
                (string.IsNullOrEmpty(productSpecParams.Search) || x.Name.ToLower().Contains(productSpecParams.Search))
                && (!productSpecParams.brandId.HasValue || x.ProductBrandId == productSpecParams.brandId)
                && (!productSpecParams.typeId.HasValue || x.ProductTypeId == productSpecParams.typeId)
            )
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
            AddOrderBy(x => x.Name);

            ApplyPaging(productSpecParams.pageSize * (productSpecParams.PageIndex - 1)
                        , productSpecParams.pageSize);

            if (!string.IsNullOrEmpty(productSpecParams.Sort))
            {
                switch (productSpecParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;

                    case "priceDesc":
                        AddOrderByDescnding(p => p.Price);
                        break;

                    default:
                        AddOrderBy(p => p.Name);
                        break;

                }
            }
        }

        public ProductTypeandBrandSpecification(int id)
            : base(x => x.Id == id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);
        }

    }
}