using Examen.Advanced.Csharp.Contracts.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Advanced.Csharp.Contracts.Models
{
    public class Person : ModelBase
    {
        public Person()
        {

        }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required] 
        public Address Address { get; set; } = new Address();

        #region
        // Parameterized constructor for immutability,data validation, clearer object state, flexibility in combo with default ctr
        #endregion
        public Person(string id, string firstName, string lastName, DateTime dateOfBirth)
            : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }
    }
}
