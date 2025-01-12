using Labo.API.Contracts.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo.API.Contracts.Models
{
    public class Writers:ModelBase
    {
        [StringLength(50)]
        public string GenreId { get; set; } = default!;

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        public Writers() { }
    }
}
