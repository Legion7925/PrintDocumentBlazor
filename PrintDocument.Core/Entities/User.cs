using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintDocument.Core.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public required string NameAndFamily { get; set; }

        public required string Username { get; set; }

        public required string PasswordHash { get; set; }
    }
}
