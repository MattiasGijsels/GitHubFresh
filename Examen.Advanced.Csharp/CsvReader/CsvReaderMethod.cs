using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Examen.Advanced.Csharp.Contracts.Models;

namespace CsvParserExample
{
    public static class CsvParser
    {
        public static List<ZipCode> ParseCsvToZipCode(string filePath)
        {
            var zipCodes = new List<ZipCode>();

            // Ensure the file exists
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"File not found: {filePath}");

            // Read the file line by line
            var lines = File.ReadLines(filePath).ToList();

            if (lines.Count <= 1)
                throw new Exception("The CSV file is empty or missing headers.");

            // Assume the first line contains headers and skip it
            var dataLines = lines.Skip(1);

            foreach (var line in dataLines)
            {
                var columns = line.Split(',');

                if (columns.Length < 6)
                {
                    Console.WriteLine($"Skipping invalid row: {line}");
                    continue;
                }

                try
                {
                    var zipCode = new ZipCode
                    {
                        CityName = columns[0].Trim(),
                        PostalCode = columns[1].Trim(),
                        NisCode = columns[2].Trim(),
                        Province = columns[3].Trim(),
                        Main = byte.Parse(columns[4].Trim()),
                        Country = string.IsNullOrWhiteSpace(columns[5]) ? null : columns[5].Trim()
                    };

                    // Validate the model
                    var validationResults = new List<ValidationResult>();
                    if (!Validator.TryValidateObject(zipCode, new ValidationContext(zipCode), validationResults, true))
                    {
                        Console.WriteLine($"Validation failed for row: {line}");
                        foreach (var result in validationResults)
                            Console.WriteLine($" - {result.ErrorMessage}");
                        continue;
                    }

                    zipCodes.Add(zipCode);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error parsing row: {line}. Exception: {ex.Message}");
                }
            }

            return zipCodes;
        }
    }
}
