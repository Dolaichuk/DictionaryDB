
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Dictionary.Data.Entity;
using Dictionary.Services.Interface;
using Dictionary.Web.ServiceModel;
using Microsoft.AspNetCore.Mvc;

namespace Dictionary.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExplanationController : ControllerBase
    {
        private readonly IExplanationService _explanationService;
        private readonly IEmailSenderService _emailSenderService;
        public ExplanationController(IExplanationService explanationService, IEmailSenderService emailSenderService)
        {
            _explanationService = explanationService;
            _emailSenderService = emailSenderService;
        }
        [HttpGet]
        public async Task<Explanation> GetbyId(int Id)
        {
            return await _explanationService.GetById(Id);
        }
        [HttpPut]
        public async Task Edit(ExplanationModelEdit explanationEdit)
        {
            Explanation explanation = await _explanationService.GetById(explanationEdit.Id);
            explanation.Meaning = explanationEdit.Meaning;
            await _explanationService.Update(explanation);
        }
        [HttpDelete]
        public async Task Delete(int Id)
        {
            await _explanationService.Delete(Id);
        }
        [HttpPost]
        public async Task Create(ExplanationModel e, string sendTo)
        {
            Explanation explanation = new Explanation() { Meaning = e.Meaning };
            await _explanationService.Add(explanation);
            MailAddress to = new MailAddress(sendTo);
            await _emailSenderService.SendAsync(to, "smtp@gmail.com", "In the table Explanation added an alement");
        }
    }
}