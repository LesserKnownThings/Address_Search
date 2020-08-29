using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace GoogleSearchBar.Scripts.Misc
{
    /// <summary>
    /// This class contains the info returned from google
    /// </summary>
    public class AutocompleteResult
    {
        /// <summary>
        /// The status of the API call
        /// https://developers.google.com/places/web-service/autocomplete#place_autocomplete_status_codes
        /// </summary>
        public string status { get; private set; }
        /// <summary>
        /// The list of locations returned by the API call
        /// </summary>
        public List<StructuredFormating> FormatedAddress { get; private set; }

        public AutocompleteResult (JArray json, string status)
        {
            this.status = status;
            FormatedAddress = new List<StructuredFormating>();

            foreach (var item in json)
            {
                string mainText = string.Empty;
                string secondaryText = string.Empty;

                if (item["structured_formatting"]["main_text"] != null)
                    mainText = item["structured_formatting"]["main_text"].Value<string>();
                else mainText = json["description"].Value<string>();

                if (item["structured_formatting"]["secondary_text"] != null)
                    secondaryText = item["structured_formatting"]["secondary_text"].Value<string>();

                StructuredFormating formated = new StructuredFormating
                    (                    
                    mainText,
                    secondaryText
                    );
                FormatedAddress.Add(formated);
            }
        }

        /// <summary>
        /// This constructor is initiated only when the status code is an error
        /// </summary>
        public AutocompleteResult()
        {
            FormatedAddress = null;
        }
    }
}
