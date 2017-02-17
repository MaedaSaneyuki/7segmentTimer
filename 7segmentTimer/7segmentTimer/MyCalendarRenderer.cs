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
    class MyCalendarRenderer : ViewRenderer<_7segmentTimer.ClockXamarineView, ViewGroupSub>//2
    {
        protected override void OnElementChanged(ElementChangedEventArgs<_7segmentTimer.ClockXamarineView> e)
        {
            base.OnElementChanged(e);
            //Set

            //(new ClockView(this.Context));

            
            if (Control == null)
            {
                var cameraPreview = new ViewGroupSub(Context); 
                SetNativeControl(cameraPreview);
            }
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
            //    var start = new ClockView(Context); // <--4
                
            }
        }
    }

    public sealed class ViewGroupSub : ViewGroup
    {
        private ClockView clockView;

        public ViewGroupSub(Context context): base(context)
        {
            clockView = new ClockView(context);
            AddView(clockView);
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            var msw = MeasureSpec.MakeMeasureSpec(r - l, MeasureSpecMode.Exactly);
            var msh = MeasureSpec.MakeMeasureSpec(b - t, MeasureSpecMode.Exactly);

            clockView.Measure(msw, msh);
            clockView.Layout(0, 0, r - l, b - t);
        }


    }

}