using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using GraphQLIssue.Core.Repositories;

namespace GraphQLIssue.Identity.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize(Policy="SuperAdmin")]
    public class ConfigController : Controller
    {
        private readonly IConfigRepository _configRepository;
 
        public ConfigController(IConfigRepository configRepository)
        {
            _configRepository = configRepository;
        }

        [HttpPost]
        public async Task<bool> SetInitialSettings()
        {
            var result = await _configRepository.SetInitialSettings();
            return result;
        }
    }
}
