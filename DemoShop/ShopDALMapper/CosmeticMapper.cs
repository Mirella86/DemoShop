using ShopDAL.Model;
using ShopDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDALMapper
{
    public class CosmeticMapper
    {
        public static CosmeticDTO ClothesToClothesDto(Cosmetic entity)
        {
            if (entity != null)
            {
                CosmeticDTO cosmeticDTO = new CosmeticDTO();
                ShopHelpers.MappingHelper.MapObjects(entity, cosmeticDTO);
                return cosmeticDTO;
            }
            return null;
        }

        public static Cosmetic CosmeticDtoToCosmetic(CosmeticDTO cosmeticDto)
        {
            if (cosmeticDto != null)
            {
                Cosmetic cosmetic = new Cosmetic();
                ShopHelpers.MappingHelper.MapObjects(cosmeticDto, cosmetic);
                return cosmetic;
            }
            return null;
        }
    }
}
