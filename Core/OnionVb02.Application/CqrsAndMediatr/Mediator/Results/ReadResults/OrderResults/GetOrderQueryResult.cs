namespace OnionVb02.Application.CqrsAndMediatr.Mediator.Results.ReadResults.OrderResults
{
    public class GetOrderQueryResult
    {
        public int Id { get; set; }
        public string ShippingAddress { get; set; }
        public int AppUserId { get; set; }
    }
}
