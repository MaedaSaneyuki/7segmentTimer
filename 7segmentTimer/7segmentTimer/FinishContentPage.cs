using System;
using Xamarin.Forms;

namespace _7segmentTimer
{
    public class FinishContentPage : ContentPage
    {
        public FinishContentPage()
        {
            this.BackgroundColor = Color.White;

            var closeBtn = new Button
            {
                Text = "close",
                FontAttributes = FontAttributes.None,
                FontSize = 20,
            };

            closeBtn.Clicked += (s, e) =>
            {
                Navigation.PopAsync();
            };


            Image clockImage = new Image
            {
                Source = Device.OnPlatform(
                    ImageSource.FromUri(new Uri("https://www.xamarin.com/content/images/pages/branding/assets/xamagon.png")),
                    ImageSource.FromFile("drawable/addummy.png"),
                    ImageSource.FromUri(new Uri("https://www.xamarin.com/content/images/pages/branding/assets/xamagon.png"))),
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            Image senntakuki = new Image();
            senntakuki.Source = "sentaku.jpg";

            Content = new StackLayout
            {
                Spacing = 40,
                VerticalOptions = LayoutOptions.Start,
                Children = {
                    new Label {
                        Text = "êÙëÛäÆóπ",
                        FontAttributes = FontAttributes.None,
                        FontSize = 40,
                        TextColor = Color.Black,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        HorizontalOptions = LayoutOptions.CenterAndExpand
                    },
                    senntakuki,
                    clockImage,
                    closeBtn,
                },


            };

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

        }


    }
}