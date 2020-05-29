using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dictionary.Data.Entity;
using Dictionary.Services.Interface;
using Dictionary.Web.ServiceModel;
using Microsoft.AspNetCore.Mvc;

namespace Dictionary.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageOriginController : ControllerBase
    {
        private readonly ILanguageOriginService _languageOriginService;
        public LanguageOriginController(ILanguageOriginService languageOriginService)
        {
            _languageOriginService = languageOriginService;
        }
        [HttpGet]
        public async Task<LanguageOrigin> GetbyId(int Id)
        {
            return await _languageOriginService.GetById(Id);
        }
        [HttpPut]
        public async Task Edit(LanguageOriginModelEdit languageOriginEdit)
        {
            LanguageOrigin languageOrigin = await _languageOriginService.GetById(languageOriginEdit.Id);
            languageOrigin.Origin = languageOriginEdit.Origin;
            await _languageOriginService.Update(languageOrigin);
        }
        [HttpDelete]
        public async Task Delete(int Id)
        {
            await _languageOriginService.Delete(Id);
        }
        [HttpPost]
        public async Task Create(LanguageOrigin l)
        {
            LanguageOrigin languageOrigin = new LanguageOrigin() { Origin = l.Origin };
            await _languageOriginService.Add(languageOrigin);
        }
    }
}