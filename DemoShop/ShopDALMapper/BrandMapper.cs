using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShopDAL.Model;
using ShopDTO;

namespace ShopDALMapper
{
	public class BrandMapper 
	{
		public static BrandDTO BrandToBrandDto(Brand entity, List<ProductDTO> products)
		{
            BrandDTO brandDTO = BrandToBrandDto(entity);
            if (brandDTO != null)
			{
                brandDTO.Products = products;
                return brandDTO;
			}
			return null;
		}
        public static BrandDTO BrandToBrandDto(Brand entity)
        {

            if (entity != null)
            {
                BrandDTO brandDTO = new BrandDTO();
                ShopHelpers.MappingHelper.MapObjects(entity, brandDTO);
                return brandDTO;
            }
            return null;
        }
		public static Brand BrandDtoToBrand(BrandDTO brandDto)
		{

			if (brandDto != null)
			{
                Brand brand  = new Brand();
                ShopHelpers.MappingHelper.MapObjects(brandDto, brand);
                return brand;
			}
			return null;
		}
	}
}
