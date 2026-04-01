using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace VoltGearSystem.Models
{
    public class Laptop
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BindNever]
        public string? SerialNumber { get; set; }

        [Required]
        public string ModelName { get; set; }
        [Required]
        public int Price { get; set; }

    }
}
