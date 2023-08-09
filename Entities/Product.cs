namespace Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string CategoryId { get; set; }
        public string BrandId { get; set; }
    }
}
