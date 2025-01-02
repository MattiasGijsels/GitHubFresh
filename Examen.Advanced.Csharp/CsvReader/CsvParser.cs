using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Examen.Advanced.Csharp.Contracts.Models;

namespace CsvParser
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
            foreach (var line in lines.Skip(1)) // Skip header
            {
                try
                {
                    var columns = line.Split(',');

                    // Trim and handle special cases for each column
                    var cityName = columns[0].Trim().Trim('\''); // Remove quotes
                    var postalCode = columns[1].Trim();
                    var nisCode = columns[2].Trim();
                    var province = columns[3].Trim();
                    var main = byte.Parse(columns[4].Trim());

                    // Validate required fields before adding
                    if (!string.IsNullOrWhiteSpace(cityName) &&
                        !string.IsNullOrWhiteSpace(postalCode) &&
                        !string.IsNullOrWhiteSpace(nisCode) &&
                        !string.IsNullOrWhiteSpace(province))
                    {
                        zipCodes.Add(new ZipCode
                        {
                            CityName = cityName,
                            PostalCode = postalCode,
                            NisCode = nisCode,
                            Province = province,
                            Main = main,
                            Country = "Belgium" // Default value
                        });
                    }
                    else
                    {
                        Console.WriteLine($"Skipping invalid row: {line}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing row: {line}. Exception: {ex.Message}");
                }
            }

            return zipCodes;
        }

    }
}
