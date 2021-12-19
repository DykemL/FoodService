namespace FoodService.Models.DtoModels
{
    public class PaymentDto
    {
        public string UserName { get; set; }
        public string Hash { get; set; }
        public string CryptedHash { get; set; }
    }
}
