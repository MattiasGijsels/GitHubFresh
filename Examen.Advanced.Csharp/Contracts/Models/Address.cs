using Examen.Advanced.Csharp.Contracts.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Advanced.Csharp.Contracts.Models
{
    public class Address:ModelBase
    {
        public Address()
        {

        }

        [Required]
        [StringLength(100)]
        public string Street { get; set; } = string.Empty;

        [Required]//check if this one will fuck up the seeding !!
        public ZipCode Zipcode { get; set; } = new ZipCode();

        [StringLength(50)]
        public string? Country { get; set; } = "Belgium"; // Default country is "Belgium"

    }
}

