namespace OnionVb02.Application.CqrsAndMediatr.CQRS.Results.ReadResults.ProductResults
{
    public class GetProductByIdQueryResult
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int CategoryId { get; set; }
    }
}
