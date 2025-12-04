namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Results.ReadResults.OrderDetailResults
{
    public class GetOrderDetailByIdQueryResult
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
    }
}
