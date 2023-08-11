namespace Entities
{
    public class ProductDto : Product
    {
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
        public float PriceDiscount { get; set; }
        public float OriginalPrice { get; set; }
    }
}
