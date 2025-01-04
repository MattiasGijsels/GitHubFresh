using Examen.Advanced.Csharp.CsvReader;
using Examen.Advanced.Csharp.Contracts.Models;
using Examen.Advanced.Csharp.Database.Context;
using Examen.Advanced.Csharp.Database.DbInitializer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Examen.Advanced.Csharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DbInitializer.Initialize();
        }
    }
}
