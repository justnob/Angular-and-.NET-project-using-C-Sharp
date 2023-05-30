namespace Core.Entities
{
    public class CustomerBasket
    {
        public CustomerBasket(string id, List<BasketItems> items)
        {
            Id = id;
            Items = items;
        }

        public string Id { get; set; }

        public List<BasketItems> Items { get; set; } = new List<BasketItems>();
    }
}