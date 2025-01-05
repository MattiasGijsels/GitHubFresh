using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Examen.Advanced.Csharp.Contracts.Models;
using Examen.Advanced.Csharp.Database.Context;
using Microsoft.EntityFrameworkCore;

public class PersonService
{
    private readonly PersonsDbContext _context;

    public PersonService(PersonsDbContext context)
    {
        _context = context;
    }
    public static void FindPersonData(PersonsDbContext context)
    {
        var personService = new PersonService(context);
        Console.Write("Enter in the firstname,lastname or adressinfo searchterm: ");//how did I fuck up?
        string? name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("Please give me some data to work with.");
        }
        else 
        {
            var results = personService.SearchPersons(name);
            PrintResults(results);
        }
    }
    public List<Person> SearchPersons(string name)
    {
     // Apply filters for both firstName and lastName and adress information
     return _context.Person
         .Where(
         p => p.FirstName.ToLower().Contains(name.ToLower()) ||
         p.LastName.ToLower().Contains(name.ToLower()) ||
         p.Address.Street.ToLower().Contains(name.ToLower())).ToList(); // Filter by last name or first name or by street data
    }
    public static void PrintResults(List<Person> results)
    {
        if (results.Count > 0)
        {
            Console.WriteLine();
            Console.WriteLine("Search Results:");
            Console.WriteLine("----------------------------------------------------");
            foreach (var person in results)
            {
                Console.WriteLine($"Name: {person.FirstName} {person.LastName}");
                Console.WriteLine($"Date of birth: {person.DateOfBirth}");
                Console.WriteLine($"Adress: {person.Address.Street}");
                Console.WriteLine($"CityName: {person.Address.ZipCode.CityName}");
                Console.WriteLine($"PostalCode: {person.Address.ZipCode.PostalCode}");
                Console.WriteLine($"NisCode: {person.Address.ZipCode.NisCode}");
                Console.WriteLine($"Province: {person.Address.ZipCode.Province}");
                Console.WriteLine($"MainCity: {person.Address.ZipCode.Main}");
                Console.WriteLine("----------------------------------------------------");
            }
        }
        else
        {
            Console.WriteLine("Your query didn't yield any results");
        }
    }
    public static void FindCityPostcode(PersonsDbContext context)
    {
        var personService = new PersonService(context);
        Console.Write("Enter the name of the city or the postal code: ");
        string? userInput = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(userInput))
        {
            Console.WriteLine("Please give me some data to work with.");
        }
        else
        {
            var results = personService.SearchCityNamePostalCode(userInput);
            PrintResults(results);
        }
    }

    public List<Person> SearchCityNamePostalCode(string userInput)
    {
        return _context.Person
            .Include(p => p.Address)
            .ThenInclude(a => a.ZipCode)
            .Where(p => p.Address.ZipCode.CityName.ToLower().Contains(userInput.ToLower()) ||
                        p.Address.ZipCode.PostalCode.ToLower().Contains(userInput))
            .ToList();
    }
}
