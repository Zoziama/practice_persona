using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace practice.Domain.Entities
{
    public class Persona : AuditableEntity
    {
    public string FirstName { get; set; }

    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string NIN { get; set; }
    public DateTime DOB { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

      [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id {get; set;}
    }
}