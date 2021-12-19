namespace FoodService.Models.DtoModels
{
    public class ProductsDto
    {
        public string[] ProductIds { get; set; }
        public string[] ProductsCount { get; set; }
        public string[] Prices { get; set; }
        public bool isPaid { get; set; } = false;

        public double CountTotalPrice()
        {
            double sum = 0;
            for (int i = 0; i < ProductsCount.Length; i++)
                sum += double.Parse(ProductsCount[i]) * double.Parse(Prices[i]);
            return sum;
        }
    }
}
