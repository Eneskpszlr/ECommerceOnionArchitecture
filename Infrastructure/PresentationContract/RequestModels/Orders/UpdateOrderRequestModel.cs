namespace OnionVb02.PresentationContract.RequestModels.Orders
{
    public class UpdateOrderRequestModel
    {
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public string ShippingAddress { get; set; }
    }
}
