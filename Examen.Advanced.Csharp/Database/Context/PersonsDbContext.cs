using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Examen.Advanced.Csharp.Contracts.Models;
using Microsoft.IdentityModel.Protocols;

namespace Examen.Advanced.Csharp.Database.Context
{
    public class PersonsDbContext :DbContext
    {
        public  DbSet<Address> Addresses { get; set; }
        public  DbSet<Person> Person { get; set; }
        public  DbSet<ZipCode> ZipCode { get; set; }

        public PersonsDbContext(DbContextOptions<PersonsDbContext> options) : base(options) { }

        public PersonsDbContext()
        {

        }
    }
}
