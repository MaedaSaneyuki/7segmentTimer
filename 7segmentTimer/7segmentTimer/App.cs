using Xamarin.Forms;

namespace _7segmentTimer
{
    public class App : Application
    {
        public static int LastReadLED;

        public App()
        {
            LastReadLED = -1;
            MainPage = new NavigationPage(new MainContentPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
