using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopHelpers
{
    public class MappingHelper
    {
        public static void MapObjects(object source, object destination)
        {
            Type sourceType = source.GetType();
            Type destinationType = destination.GetType();

            var sourceProperties = sourceType.GetProperties();
            var destionationProperties = destinationType.GetProperties();

            var commonProperties = from sp in sourceProperties
                                   join dp in destionationProperties on new { sp.Name, sp.PropertyType } equals
                                       new { dp.Name, dp.PropertyType }
                                   select new { sp, dp };

            foreach (var match in commonProperties)
            {
                match.dp.SetValue(destination, match.sp.GetValue(source, null), null);
            }
        }
    }
}
