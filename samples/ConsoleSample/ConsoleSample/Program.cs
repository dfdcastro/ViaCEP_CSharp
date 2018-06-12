using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace ConsoleSample
{
    class Program
    {
        static void Main(string[] args)
        {
            GetZipCode();                
        }

        private static void GetZipCode()
        {
            try
            {
                Console.WriteLine("Informe um CEP no formato 12345678");
                var zipCode = Console.ReadLine();

                int zipCodeInt;

                if (zipCode.Length == 8 && int.TryParse(zipCode, out zipCodeInt))
                {
                    GetSearchType(zipCodeInt);
                }
                else
                {
                    Console.WriteLine("CEP em um formato inválido");
                    Console.WriteLine();
                    GetZipCode();
                }
            }
            catch (CEPLibrary.Exceptions.CEPLibraryException ex)
            {
                // Custom Exception 
                Console.WriteLine($"Erro ao obter dados: {ex.Message}");
                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao obter dados: {ex.Message}");
                Console.Read();
            }
        }

        private static void GetSearchType(int zipCode)
        {
            Console.WriteLine();
            Console.WriteLine("Em qual formato?");
            Console.WriteLine();
            Console.WriteLine("1 - JSON");
            Console.WriteLine("2 - XML");
            Console.WriteLine("3 - Piped");
            Console.WriteLine("4 - Querty");
            Console.WriteLine("5 - Object");
            var type = Console.ReadLine();
            Console.WriteLine();

            // Search address by zip code and type selected
            switch (type)
            {
                case "1":
                    // Search with json result
                    var result = CEPLibrary.Search.ByZipCode(zipCode, CEPLibrary.Types.ViaCEPTypes.Json);

                    Console.WriteLine(Encoding.UTF8.GetString(Encoding.Default.GetBytes(result)));
                    Console.WriteLine();
                    GetZipCode();
                    break;
                case "2":
                    // Search with xml result
                    result = CEPLibrary.Search.ByZipCode(zipCode, CEPLibrary.Types.ViaCEPTypes.Xml);

                    Console.WriteLine(Encoding.UTF8.GetString(Encoding.Default.GetBytes(result)));
                    Console.WriteLine();
                    GetZipCode();
                    break;
                case "3":
                    // Search with piped result
                    result = CEPLibrary.Search.ByZipCode(zipCode, CEPLibrary.Types.ViaCEPTypes.Piped);

                    Console.WriteLine(Encoding.UTF8.GetString(Encoding.Default.GetBytes(result)));
                    Console.WriteLine();
                    GetZipCode();
                    break;
                case "4":
                    // Search with querty result
                    result = CEPLibrary.Search.ByZipCode(zipCode, CEPLibrary.Types.ViaCEPTypes.Querty);

                    Console.WriteLine(Encoding.UTF8.GetString(Encoding.Default.GetBytes(result)));
                    Console.WriteLine();
                    GetZipCode();
                    break;
                case "5":
                    // Search with object result
                    CEPLibrary.Model.ViaCEPModel objectResult = CEPLibrary.Search.ByZipCode(zipCode);

                    foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(objectResult))
                    {
                        string name = descriptor.Name;
                        object value = descriptor.GetValue(objectResult);
                        Console.WriteLine("{0}={1}", name, value);
                    }

                    Console.WriteLine();
                    GetZipCode();
                    break;
                default:
                    Console.WriteLine("Tipo inválido");
                    GetSearchType(zipCode);
                    break;
            }            
        }
    }
}
