namespace GoogleSearchBar.Scripts.Misc
{
    public class GoogleCallParameters
    {
        /// <summary>
        /// Required Paramater
        /// </summary>
        public string Input { get; private set; }
        /// <summary>
        /// This is a required paramater
        /// Please keep in mind that the API key here is visible to anyone who has yoru code
        /// In other words, don't use the API key on the client side, use it on the server side
        /// </summary>
        public string APIKey { get; private set; }
        /// <summary>
        /// Optional parameter
        /// </summary>
        public string SessionToken { get; private set; }
        /// <summary>
        /// Optional parameter
        /// </summary>
        public string Language { get; private set; }
        /// <summary>
        /// Optional parameter
        /// </summary>
        public string Components { get; private set; }

        /// <summary>
        /// Constructor for required parameters only
        /// </summary>
        /// <param name="Input">The input from the searchbar</param>
        /// <param name="APIKey">The API key needed, you'll have to get this one from google https://developers.google.com/places/web-service/get-api-key
        /// </param>
        public GoogleCallParameters(string Input, string APIKey)
        {
            this.Input = Input;
            this.APIKey = APIKey;
        }

        /// <summary>
        /// Constructor with additional optional parameters
        /// </summary>
        /// <param name="Input"> Input from the searchbar</param>
        /// <param name="APIKey">API from google, specified above</param>
        /// <param name="SessionToken">
        /// The session token is needed for billing purpose. If you do not have one, you will be charged per character, if you have one you will be charged per session. See https://developers.google.com/places/web-service/session-tokens
        /// </param>
        /// <param name="Language">The language in which info will be returned
        /// if this is not set, the info will be in EN </param>
        /// <param name="Components">Specific country|countries in which you want to search any address</param>
        public GoogleCallParameters 
            (
            string Input,
            string APIKey,
            string SessionToken,
            string Language,
            string Components
            )
        {
            this.Input = Input;
            this.APIKey = APIKey;
            this.SessionToken = SessionToken;
            this.Language = Language;
            this.Components = Components;
        }
    }
}
