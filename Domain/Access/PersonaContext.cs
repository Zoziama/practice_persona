using Microsoft.EntityFrameworkCore;
using practice.Domain.Entities;

namespace practice.Domain.Access
{
    public class PersonaContext : DbContext
        {
            public PersonaContext(DbContextOptions<PersonaContext> options) : base(options)
            {
            
            }
            public virtual DbSet<Persona> Personas { get; set; }
            
    }
}