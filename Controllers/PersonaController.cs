using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using practice.Common;
using practice.Domain.Access;
using practice.Domain.Entities;

namespace practice.Controllers
{
    public class PersonaController : Controller
    {
        private readonly PersonaContext _personaContext;

        public PersonaController(PersonaContext personaContext)
        {
            _personaContext = personaContext;
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
        public IActionResult AddPersona([FromBody] PersonaViewModel Request)
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
            
            //check if Firstname, lastname, email and phone number match result from NIN service
            //if not return invalid data response
            
            //save data to db
            
            //send request to sms service to send a default welcome message to persona phone number
            
            
            
            
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