using System.Collections.Generic;

namespace Core.Entities
{
    public class CustomerBasket
    {
        public string id { get; set; }
        public CustomerBasket()
        {
        }

        public CustomerBasket(string _id)
        {
            id = _id;
        }
        public List<BacketItems> Items { get; set; } = new List<BacketItems>();

    }
}