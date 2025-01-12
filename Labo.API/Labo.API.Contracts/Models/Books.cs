using Labo.API.Contracts.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Labo.API.Contracts.Models
{
    public class Books:ModelBase

    {
        [StringLength(100)]
        public string BookTitle { get; set; } = default!;
        public Genre Genre{ get; set; } = new Genre();
        public Writers Writer { get; set; } = new Writers();

        public int PageCount { get; set; }

        public Books() { }
    }
}
