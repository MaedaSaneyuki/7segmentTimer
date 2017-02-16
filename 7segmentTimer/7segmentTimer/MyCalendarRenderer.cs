using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using System.ComponentModel;

[assembly: ExportRenderer(
  typeof(_7segmentTimer.ClockXamarineView),
  typeof(_7segmentTimer.MyCalendarRenderer))] // 

namespace _7segmentTimer
{
    class MyCalendarRenderer : ViewRenderer<_7segmentTimer.ClockXamarineView, CalendarView>//2
  {
    protected override void OnElementChanged(
      ElementChangedEventArgs<_7segmentTimer.ClockXamarineView> e)
        {
            base.OnElementChanged(e);
            SetNativeControl(new CalendarView(this.Context));
        }

        protected override void OnElementPropertyChanged( // <--3
          object sender,
          PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (this.Element == null || this.Control == null)
            {
                return;
            }

            //if (e.PropertyName == MyCalendar.CurrentDateProperty.PropertyName)
            {
                var start = new DateTime(1970, 1, 1); // <--4
                //var diff = Element.CurrentDate - start;
                var diff = DateTime.Today - start;
                Control.Date = Convert.ToInt64(diff.TotalMilliseconds);
            }
        }
    }
}