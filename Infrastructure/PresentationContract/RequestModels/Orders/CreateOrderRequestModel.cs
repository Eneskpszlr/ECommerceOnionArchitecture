namespace OnionVb02.PresentationContract.RequestModels.Orders
{
    public class CreateOrderRequestModel
    {
        public int AppUserId { get; set; }
        public string ShippingAddress { get; set; }
    }
}
