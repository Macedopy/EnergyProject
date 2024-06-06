using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Newtonsoft.Json;
using Dapper;
using Amazon.DynamoDBv2.DataModel;

namespace src.Application.Dtos
{

    [DynamoDBTable("Entity")]
    public class Entity : EntityBase
    {
        [DynamoDBProperty, Display(Name = "Name"), JsonProperty("name")]
        public string Name { get; init; } = default!;
        [DynamoDBProperty, Display(Name = "Age"),  JsonProperty("age")]
        public DateTime age { get; init; }
    }
}