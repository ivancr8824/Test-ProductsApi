using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ProductsApi1.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("UPC")]
        public string Upc { get; set; } = null!;

        [BsonElement("prodName")]
        public string Name { get; set; } = null!;

        [BsonElement("model")]
        public string Model { get; set; } = null!;

        [BsonElement("unitListPrice")]
        public double UnitListPrice { get; set; }

        [BsonElement("unitsInStock")]
        public int UnitsInStock { get; set; }
    }
}
