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
  typeof(_7segmentTimer.ClockXamarineFormsView),
  typeof(_7segmentTimer.ClockRenderer))] // 

namespace _7segmentTimer
{
    class ClockRenderer : ViewRenderer<_7segmentTimer.ClockXamarineFormsView, ViewGroupSub>//2
    {
        protected override void OnElementChanged(ElementChangedEventArgs<_7segmentTimer.ClockXamarineFormsView> e)
        {
            base.OnElementChanged(e);
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
        private ClockAndroidView clockView;

        public ViewGroupSub(Context context): base(context)
        {
            clockView = new ClockAndroidView(context);
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