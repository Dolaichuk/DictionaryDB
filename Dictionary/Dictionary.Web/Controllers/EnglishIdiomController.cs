using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dictionary.Data.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Dictionary.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnglishIdiomController : ControllerBase
    {
        [HttpGet]
        public async Task<EnglishIdiom> GetbyId(int Id)
        {
            return null;
        }
        [HttpPut]
        public async Task Edit(EnglishIdiom englishIdiom)
        {

        }
        [HttpDelete]
        public async Task Delete(int Id)
        {

        }
        [HttpPost]
        public async Task Create(EnglishIdiom englishIdiom)
        {

        }
    }
}