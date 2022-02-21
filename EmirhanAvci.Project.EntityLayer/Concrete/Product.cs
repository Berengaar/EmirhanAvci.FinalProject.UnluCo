using EmirhanAvci.Project.SharedLayer.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.EntityLayer.Concrete
{
    public class Product:EntityBase,IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsOfferable { get; set; }
        public bool IsSold { get; set; }
        public double Price { get; set; }
        public double? SoldPrice { get; set; }
        public ICollection<Offer> Offers { get; set; }
        public int? OrderId { get; set; }
        public Order Order { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int BrandId { get; set; }
        public Brand Brand{ get; set; }
        public int ColorId { get; set; }
        public Color Color { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}


// User Id = 1  

//User'a ait ürünlere gelen teklifler
// User'ın gönderdiği teklifler