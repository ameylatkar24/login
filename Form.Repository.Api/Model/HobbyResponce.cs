using System;
using Form.Repository.Api.Entities;
using Microsoft.AspNetCore.Http;
using Form.Repository.Api.Helpers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Form.Repository.Api.Model
{

    public class HobbyResponce
    {
        public string Hobby { get; set; }

        public HobbyResponce(HobbyRequest hobby)
        {
            Hobby = hobby.Hobby;
            //   UserId = hobby.UserId;
            //   User = hobby.User;
        }

    }
}