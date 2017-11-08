
using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace rest.Model
{
    public class Product
    {
        [BsonId]
        public string Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public List<Category> Categories {get; set;}
    }

    public class Category{
        public string Id { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}