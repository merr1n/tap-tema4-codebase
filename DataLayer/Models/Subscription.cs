using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Subscription
    {
        public Subscription(string type, float price)
        {
            Type = type;
            Price = price;
        }

        public Guid Id { get; set; }
        public string Type { get; set; }
        public float Price { get; set; }
    }
}
