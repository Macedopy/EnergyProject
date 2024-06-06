using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using src.Application.Dtos;

namespace src.Application.Mapping
{
    public static class MapToEntity
    {
        public static Entity ToEntity(this Entity entity)
        {
            return new Entity
            {
                Id = entity.Id,
                Name = entity.Name,
                age = entity.age,
            };
        }
    }
}