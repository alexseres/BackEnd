﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HearthStone_Backend.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

namespace HearthStone_Backend.Controllers
{
    [Route("api")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CardContext context;

        public HomeController(ILogger<HomeController> logger, CardContext cardContext)
        {
            _logger = logger;
            context = cardContext;
        }
        
        [HttpGet("list")]
        public async Task<JObject> GetHomePageData()
        {
            var result = await context.GetInfo();
            JObject js = new JObject(result);

            return js;
        }

    }
}
