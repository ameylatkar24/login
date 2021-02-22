using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MongoDB.Bson;
using Form.Repository.Api.Entities;
using MongoDB.Bson.Serialization.Attributes;
using Form.Repository.Api.Infrastructure;
using Form.Repository.Api.Helpers;
using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Form.Repository.Api.Entities
{

    public class Hobbies
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id;

        //public string Id { get; set; }
        public string Hobby { get; set; }




        //[ForeignKey(nameof(UserId))]
        //    public IdentityUser User { get; set; }

    }
}