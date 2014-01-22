namespace ShopModels
{
    public class CosmeticModel : Model
    {
        public string Name { get; set; }

        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public int Stock { get; set; }
    }
}
