using System;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoogleSearchBar.Scripts.Misc
{
    [ContentProperty(nameof(source))]
    public class CustomImage: IMarkupExtension
    {
        public string source { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (source == null)
                return null;

            var imageSource = ImageSource.FromResource(source, typeof(CustomImage).GetTypeInfo().Assembly);


            return imageSource;
        }
    }
}
