using System;
using System.Collections.Generic;
using System.IO;
using Examen.Advanced.Csharp.Contracts.Models;

namespace Examen.Advanced.Csharp.CsvReader
{
    public static class CsvParser
    {
        public static List<ZipCode> ParseCsvToZipCode(string filePath)
        {
            var zipCodes = new List<ZipCode>();

            // Ensure the file exists
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"File not found: {filePath}");

            // Open the file using a FileStream
            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            using (var reader = new StreamReader(fileStream))
            {
                // Read the header line and skip it
                var headerLine = reader.ReadLine();
                if (headerLine == null)
                    throw new Exception("The CSV file is empty or missing headers.");

                // Read each line
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    try
                    {
                        var columns = line.Split(',');

                        var cityName = columns[0].Trim().Trim('\''); // Removes the quotes
                        var postalCode = columns[1].Trim();
                        var nisCode = columns[2].Trim();
                        var province = columns[3].Trim();
                        var main = columns[4].Trim() == "1";

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
            }

            return zipCodes;
        }
    }// presuming our csv file is perfect without any corrupt data
}
