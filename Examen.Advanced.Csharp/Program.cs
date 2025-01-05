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
        static async Task Main(string[] args)
        {
            var db = await DbInitializer.Initialize();
            await MenuHandler.HandleAsync(db);
        }
    }
}
