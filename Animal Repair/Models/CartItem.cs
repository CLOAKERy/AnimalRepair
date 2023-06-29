namespace Animal_Repair.Models
{
    public class CartItem
    {
        public bool IsProduct { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductPicture { get; set; }
        public int ProductCount { get; set; }
        public decimal ProductPrice { get; set; }

        public int? AnimalId { get; set; }
        public string KindOfAnimal { get; set; }
        public string KindOfGendr { get; set; }
        public string AnimalPicture { get; set; }
    }
}
