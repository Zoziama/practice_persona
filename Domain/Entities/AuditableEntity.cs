using System;

namespace practice.Domain.Entities
{
    public class AuditableEntity
    {
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string Creator { get; set; }
        public string Modifier { get; set; }
    }
}