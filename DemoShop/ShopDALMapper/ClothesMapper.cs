using ShopDAL.Model;
using ShopDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDALMapper
{
    public class ClothesMapper
    {
        public static ClothesDTO ClothesToClothesDto(Clothes entity)
        {

            if (entity != null)
            {
                ClothesDTO clothesDTO = new ClothesDTO();
                ShopHelpers.MappingHelper.MapObjects(entity, clothesDTO);
                return clothesDTO;
            }
            return null;
        }

        public static Clothes BrandDtoToBrand(ClothesDTO clothesDto)
        {

            if (clothesDto != null)
            {
                Clothes clothes = new Clothes();
                ShopHelpers.MappingHelper.MapObjects(clothesDto, clothes);
                return clothes;
            }
            return null;
        }
    }
}
