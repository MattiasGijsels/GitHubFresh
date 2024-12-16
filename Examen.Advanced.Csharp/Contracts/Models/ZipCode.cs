using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Examen.Advanced.Csharp.Contracts.Shared;

namespace Examen.Advanced.Csharp.Contracts.Models
{    
    public class ZipCode:ModelBase
    {
        public ZipCode()
        {

        }

        [Required]
        [StringLength(50)]
        public string CityName { get; set; } = string.Empty;

        [Required]
        [StringLength(4)]
        public string PostalCode { get; set; } = string.Empty;

        [Required]
        [StringLength(5)]
        public string NisCode { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Province { get; set; } = string.Empty;

        [Required]
        [StringLength(1)]
        public byte Main { get; set; } = default!;

        [StringLength(50)]
        public string? Country { get; set; } = "Belgium"; // Default country is "Belgium"


    }
}
