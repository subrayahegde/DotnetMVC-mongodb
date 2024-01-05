using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
﻿using MongoDB.Bson.Serialization.Attributes;

namespace EmployeeCRUD.Models
{
    public class Employee
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _id { get; set; }

        [Required]
        [Display(Name ="Employee Name")]
        public string name { get; set; }
        public string designation { get; set; }
        [DataType(DataType.MultilineText)]
        public string address { get; set; }        
       
    }
}
