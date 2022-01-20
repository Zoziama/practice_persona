using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using practice.BusinessLogic.Interfaces;
using practice.Common;
using practice.Domain.Access;
using practice.Domain.Entities;

namespace practice.Controllers
{
    public class PersonaController : Controller
    {
        private readonly PersonaContext _personaContext;
        private readonly INinService _ninService;
        private readonly ISmsService _smsService;

        public PersonaController(PersonaContext personaContext, 
            INinService ninService,
            ISmsService smsService)
        {
            _personaContext = personaContext;
            _ninService = ninService;
            _smsService = smsService;

        }
        // GET
        [HttpGet("GetPersonas")]
        public IActionResult GetPersonas()
        {
            var personas = _personaContext.Personas.ToList();
            if (personas.Count < 1)
            {
                return BadRequest(" Ain't nobody here ho");
            }
            return Ok(personas);
        }
        
        [HttpGet("GetPersonabyId/{id}")]
        public IActionResult GetPersonabyId(long id)
        {
            var Persona = _personaContext.Personas.Find(id);
            if (Persona is null)
            {
                return BadRequest("Data not here");
            }
            return Ok(Persona);
        }
        
        [HttpPost("AddPersona")]
        public async Task<IActionResult> AddPersona([FromBody] PersonaViewModel Request)
        {
            //check if phone number length is less or more than 11
            if (Request.PhoneNumber.Length > 11 || Request.PhoneNumber.Length < 11)
            {
                return BadRequest("Phone number must be 11 digits");
            }
            
            //check if email is really an email format
            //var isemailvalid = IsValidEmail(Request.Email);
            if (!IsValidEmail(Request.Email))
            {
                return BadRequest("Invalid email format");
            }
            //request for NIN data from NIN service

            var N = await _ninService.GetNinData(Request.NIN);
            if (N.response.Count is 0 || N.verificationStatus == "NOT VERIFIED")
                return BadRequest("Invalid NIN");
            //check if Firstname, lastname, email and phone number match result from NIN service

            var A = _ninService.isNinValid(Request, N);
            //if not return invalid data response
            if (!A)
                return BadRequest("Invalid details supplied");
            
            //save data to db
            var NewPersona = _personaContext.Personas.Add(
                new Persona
                {
                    FirstName = Request.FirstName,
                    LastName = Request.LastName,
                    MiddleName = Request.MiddleName,
                    Email = Request.Email,
                    PhoneNumber = Request.PhoneNumber,
                    DOB = Request.DOB,
                    NIN = Request.NIN,
                    DateCreated = DateTime.Now,
                    Creator = Request.FirstName + " " + Request.LastName

                });
            _personaContext.SaveChanges();
            
            //send request to sms service to send a default welcome message to persona phone number
            var phoneno = N.response[0].telephoneno;
            var s = await _smsService.SendSms(phoneno);

            if (s.data.status != "success")
            {
                return BadRequest("Unable to send sms to your phone number");
            }
            
            return Ok("New Persona Ho");
        }
        
        bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith(".")) {
                return false; 
            }
            try {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch {
                return false;
            }
        }
    }
}