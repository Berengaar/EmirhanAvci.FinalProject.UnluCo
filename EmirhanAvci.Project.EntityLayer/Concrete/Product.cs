using EmirhanAvci.Project.EntityLayer.Authentication;
using EmirhanAvci.Project.SharedLayer.Entities.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EmirhanAvci.Project.EntityLayer.Concrete
{
    public class Product:EntityBase,IEntity
    {
        //[JsonPropertyName("name")]
        public string Name { get; set; }
        //[JsonPropertyName("description")]
        public string Description { get; set; }
        //[JsonPropertyName("imagepath")]
        public string ImagePath { get; set; }
        //[JsonPropertyName("isofferable")]
        public bool IsOfferable { get; set; }
        //[JsonPropertyName("issold")]
        public bool IsSold { get; set; }
        //[JsonPropertyName("price")]
        public double Price { get; set; }
        //[JsonPropertyName("soldprice")]
        public double? SoldPrice { get; set; }
        //[JsonPropertyName("offers")]
        public ICollection<Offer> Offers { get; set; }
        //[JsonPropertyName("orderid")]
        public int? OrderId { get; set; }
        //[JsonPropertyName("order")]
        public Order Order { get; set; }
        //[JsonPropertyName("categoryid")]
        public int CategoryId { get; set; }
        //[JsonPropertyName("category")]
        public Category Category { get; set; }
        //[JsonPropertyName("brandid")]
        public int BrandId { get; set; }
        //[JsonPropertyName("brand")]
        public Brand Brand{ get; set; }
        //[JsonPropertyName("colorid")]
        public int ColorId { get; set; }
        //[JsonPropertyName("color")]
        public Color Color { get; set; }
        //[JsonPropertyName("userid")]
        public int UserId { get; set; }
        //[JsonPropertyName("user")]
        public User User { get; set; }
    }
}


// User Id = 1  

//User'a ait ürünlere gelen teklifler
// User'ın gönderdiği teklifler