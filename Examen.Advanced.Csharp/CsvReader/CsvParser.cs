using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using Examen.Advanced.Csharp.Contracts.Models;

namespace Examen.Advanced.Csharp.CsvReader
{
    public static class CsvParser
    {

        public static List<ZipCode> ParseCsvToZipCode(string filePath)//questiones

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

                    var cityName = columns[0].Trim().Trim('\''); // Remove quotes
                    var postalCode = columns[1].Trim();
                    var nisCode = columns[2].Trim();
                    var province = columns[3].Trim();
                    var main = byte.Parse(columns[4].Trim());//change to bool

                    // Validate required fields before adding
                    if (!string.IsNullOrWhiteSpace(cityName) &&
                        !string.IsNullOrWhiteSpace(postalCode) &&
                        !string.IsNullOrWhiteSpace(nisCode) &&
                        !string.IsNullOrWhiteSpace(province))
                        //based on the presumption the csv is perfect, in future make it more dynamic
                    {
                        zipCodes.Add(new ZipCode
                        {
                            CityName = cityName,
                            PostalCode = postalCode,
                            NisCode = nisCode,
                            Province = province,
                            Main = main
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
