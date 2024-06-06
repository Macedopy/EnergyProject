using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;

namespace src.Application.Dtos
{
    public class ToolEntity: EntityBase
    {
        [DynamoDBProperty, Display(Name = "Tool")]
        public string ToolName { get; init; } = default!;
        [DynamoDBProperty, Display(Name = "Manufacturer")]
        public string Manufacturer { get; init; } = default!;
        [DynamoDBProperty, Display(Name = "Model")]
        public string ToolModel { get; init; } = default!;
    }
}