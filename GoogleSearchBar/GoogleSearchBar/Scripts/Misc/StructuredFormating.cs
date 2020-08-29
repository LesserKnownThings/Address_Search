namespace GoogleSearchBar.Scripts.Misc
{
    /// <summary>
    /// This class contains the structured_fromating section from the json returned by the API call
    /// It has 2 elements: 1.The main text and 2.the secondary text
    /// </summary>
    public class StructuredFormating
    {
        /// <summary>
        /// Usually the name of the place
        /// </summary>
        public string MainText { get; private set; }
        /// <summary>
        /// Usually the location of the place
        /// </summary>
        public string SecondaryText { get; private set; }

        public StructuredFormating (string MainText, string SecondaryText)
        {
            this.MainText = MainText;
            this.SecondaryText = SecondaryText;
        }
    }
}
