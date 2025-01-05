using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Examen.Advanced.Csharp.Contracts.Shared;

namespace Examen.Advanced.Csharp.Contracts.Models
{
    public class ZipCode : ModelBase
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
        public bool Main { get; set; } = default!;

        //[Required]
        //[Range(01000,99999)]
        //public int NisCode { get; set; } = string.Empty;


        //[Required]
        //[Range(1000, 9993)]
        //public int PostalCode { get; set; }
    }
}
