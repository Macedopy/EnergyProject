using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.Application.Dtos;
using src.Infrastructure;

namespace src.Controllers
{
    [ApiController, Route("dapper/[controller]")]
    public class EntityController : ControllerBase
    {
        private readonly IEntityRepositorie _entityRepositorie;

        public EntityController(IEntityRepositorie entityRepositorie)
        {
            _entityRepositorie = entityRepositorie;
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _entityRepositorie.GetEntityById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterEntity([FromBody] Entity entity)
        {
            var register = await _entityRepositorie.RegisterEntity(entity);
            return Ok(register);
        }
    }
}