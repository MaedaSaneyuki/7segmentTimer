using System;
using Xamarin.Forms;

namespace _7segmentTimer
{
    class MainContentPage : ContentPage
    {
        private ClockXamarineFormsView clock;

        public MainContentPage()
        {
            var label = new Label
            {
                Text = "コインランドリータイマー",
                FontAttributes = FontAttributes.None,
                FontSize = 20,
                TextColor = Color.Black
            };

            var button = new Button
            {
                Text = "カメラ読み取り",
                FontAttributes = FontAttributes.None,
                FontSize = 18
            };

            button.Clicked += (s, e) => 
            {
                Navigation.PushAsync(new CameraPreviewContentPage());
            };

            clock = new ClockXamarineFormsView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                PeriodEnd = DateTime.MinValue,
                DebuggerDorucking = false
            };
            
            this.BackgroundColor = Color.White;
            
            Content = new StackLayout
            {
                Spacing = 3,
                VerticalOptions = LayoutOptions.Start,
                Children = {
                    label,
                    button,
                    clock
                },
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Random rnd = new Random((int)DateTime.Now.Ticks);
            var nextPeriod = rnd.Next() % 60;

            System.Diagnostics.Debug.WriteLine("MainContentPage - OnAppearing nextPeriod={0}", args: nextPeriod);

            clock.PeriodEnd = DateTime.Now.AddMinutes(nextPeriod);
        }




    }
}
