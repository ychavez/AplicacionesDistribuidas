namespace DWShop.Web.Client.DTO
{
    public class CheckoutDTO
    {

        public string userName { get; set; } = null!;
        public int totalPrice { get; set; }
        public string firstName { get; set; } = null!;
        public string lastName { get; set; } = null!;
        public string emailAddress { get; set; } = null!;
        public string addressLine { get; set; } = null!;
        public string country { get; set; } = null!;
        public string state { get; set; } = null!;
        public string zipCode { get; set; } = null!;
        public string cardName { get; set; } = null!;
        public string cardNumber { get; set; } = null!;
        public string expiration { get; set; } = null!;
        public string cvv { get; set; } = null!;
        public int paymentMethod { get; set; }

    }
}
