using CEPLibrary.Exceptions;
using CEPLibrary.Model;
using CEPLibrary.Services;
using CEPLibrary.Types;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CEPLibrary
{
    public class Search
    {
        /// <summary>
        /// Search address by Zip Code
        /// </summary>
        /// <param name="zipCode">Zip code value</param>
        /// <param name="type">The type to search address. Use ViaCEPTypes object to help. Possible values include: 'json', 'xml', 'piped' and 'querty'</param>
        /// <returns>String with result in type selected</returns>
        /// 
        public static string ByZipCode(int zipCode, string type)
        {
            try
            {
                var result = ViaCEPServices.GetAddressByCEP(zipCode, type);

                return result;
            }
            catch (CEPLibraryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new CEPLibraryException(ex.Message);
            }
        }

        /// <summary>
        /// Search address by Zip Code
        /// </summary>
        /// <param name="zipCode">Zip code value</param>
        /// <returns>Object with address result</returns>
        public static ViaCEPModel ByZipCode(int zipCode)
        {
            try
            {
                var jsonResult = ViaCEPServices.GetAddressByCEP(zipCode, ViaCEPTypes.Json);

                var objectResult = JsonConvert.DeserializeObject<ViaCEPModel>(jsonResult);

                return objectResult;
            }
            catch (CEPLibraryException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new CEPLibraryException(ex.Message);
            }
        }
    }
}
