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
                FontSize = 20
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


            if (App.LastReadLED < 1) return;
            
            System.Diagnostics.Debug.WriteLine("MainContentPage - OnAppearing nextPeriod App.LastReadLED={0}", args: App.LastReadLED);
            clock.PeriodEnd = DateTime.Now.AddMinutes(App.LastReadLED);
            clock.OnPeriodEnd = () =>
            {
                Navigation.PushAsync(new FinishContentPage());
            };

            App.LastReadLED = -1;

        }




    }
}
