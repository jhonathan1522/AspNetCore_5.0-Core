using AspNetCore.Application;
using AspNetCore.Entities;
using AspNetCore.Entities.DTO_S;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AspNetCore.WebApi.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class FotballTeamController : ControllerBase
    {

        IApplication<FootballTeam> _footbal;

        public FotballTeamController(IApplication<FootballTeam> footbal)
        {
            _footbal = footbal;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_footbal.GetAll());
        }

        [HttpPost]
        public IActionResult Save(FootballTeamDto dto)
        {
            var f = new FootballTeam()
            {
                Name = dto.Name,
                Score = dto.Score,
                Manager = dto.Manager
            };

            return Ok(_footbal.Save(f));
        }

    }
}
