using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
using Newtonsoft.Json;

namespace src.Application.Dtos
{
    public abstract class EntityBase
    {
        protected EntityBase()
        {
            Id = Guid.NewGuid();
        }

        [DynamoDBHashKey, Display(Name = "ID"), JsonProperty("name")]
        public Guid Id { get; set; }
    }
}