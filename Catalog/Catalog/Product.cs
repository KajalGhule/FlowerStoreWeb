using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog
{
    public class Product
    {
        // How  we can write Propery 
        // Auto property get by default private variable
        public int Likes { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }

        public Product()
        {
            this.Id = 0;
            this.Title = "";
            this.Description = "";
            this.Quantity = 0;
            this.UnitPrice = 0;
        }

        public Product(int id, string title, string description, double unitPrice, int quantity)
        {
            this.Id = id;
            this.Title = title;
            this.Description = description;
            this.Quantity = quantity;
            this.UnitPrice = unitPrice;
        }

    }
}
