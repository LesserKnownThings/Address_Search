using GoogleSearchBar.Scripts.Misc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace GoogleSearchBar.Scripts.GoogleAPIActions
{
    public static class AutocompleteSearch
    {

        /// <summary>
        /// This function returns an object AutocompleteResults, which contains all the results from the google API call
        /// </summary>
        /// <param name="parameters">The parameters needed to make the API call</param>
        /// <returns></returns>
        public static async Task<AutocompleteResult> GetAddressLis (GoogleCallParameters parameters)
        {
            var client = new HttpClient();
            string url = URL_Constructor(parameters);
            
            var result = await client.GetAsync(url);

            AutocompleteResult results = new AutocompleteResult();

            if (result.IsSuccessStatusCode)
            {
                var jsonString = await result.Content.ReadAsStringAsync();

                var json = JObject.Parse(jsonString);

                results = new AutocompleteResult(json["predictions"].Value<JArray>(), json["status"].Value<string>());

                return results;
            }
            else return results;
        }


        /// <summary>
        /// This builds the URL which we can use to get data from Google
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private static string URL_Constructor(GoogleCallParameters parameters)
        {
            var url = "https://maps.googleapis.com/maps/api/place/autocomplete/json";

            url += $"?input={Uri.EscapeUriString(parameters.Input)}";
            

            if (!string.IsNullOrEmpty(parameters.Language))
                url += $"&language={parameters.Language}";

            if (!string.IsNullOrEmpty(parameters.Components))
                url += $"&components={Uri.EscapeUriString(parameters.Components)}";

            url += $"&key={parameters.APIKey}";

            if (!string.IsNullOrEmpty(parameters.SessionToken))
                url += $"&sessiontoken={parameters.SessionToken}";


            Debug.WriteLine(url);
            return url;
        }
    }
}
