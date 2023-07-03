using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintDocument.Core.Entities
{
    public class Keyword
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public int? ParentId { get; set; }

        public Keyword? Parent { get; set; }
    }
}
