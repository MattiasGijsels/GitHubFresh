using Labo.API.Contracts.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo.API.Contracts.Models
{
    public class Genre: ModelBase
    {
        [StringLength(50)]
        public string? GenreId { get; set; } = default!;

        [StringLength(50)]
        public string GenreName { get; set; }

        public Genre() 
        {

        }
    }
}
