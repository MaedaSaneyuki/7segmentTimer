using System;
using Xamarin.Forms;

namespace _7segmentTimer
{
    class AnylineFormsPage : ContentPage
    {
        public AnylineFormsPage()
        {
            var label = new Label
            {
                Text = "コインランドリータイマー",
                FontAttributes = FontAttributes.None,
                FontSize = 20
            };

            var button = new Button
            {
                Text = "カメラ読み取り",
                FontAttributes = FontAttributes.None,
                FontSize = 18
            };

            //var clockImage = new 

            button.Clicked += (s, e) => 
            {
               // Navigation.PushAsync(new EnergyPage());
            };

            Image clockImage = new Image
            {
                // Some differences with loading images in initial release.
                Source = Device.OnPlatform(
                    ImageSource.FromUri(new Uri("https://www.xamarin.com/content/images/pages/branding/assets/xamagon.png")),
                    ImageSource.FromUri(new Uri("https://www.xamarin.com/content/images/pages/branding/assets/xamagon.png")),
                    ImageSource.FromUri(new Uri("https://www.xamarin.com/content/images/pages/branding/assets/xamagon.png"))),



                //Source = new UriImageSource
                //{
                //    Uri = new Uri("http://xamarin.com/images/index/ide-xamarin-studio.png")
                //},
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            //clockImage.l
            
            Content = new StackLayout
            {
                Spacing = 30,
                VerticalOptions = LayoutOptions.Start,
                Children = {
					label,
                    //clockImage,
                    button,
                                        new ClockXamarineView
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand
                    }

                }
            };
        }

        
    }
}
