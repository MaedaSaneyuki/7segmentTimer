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

            if (e.PropertyName == ClockXamarineFormsView.PeriodEndPropaty.PropertyName)
            {

                ((ViewGroupSub)this.Control).PeriodEnd = Element.PeriodEnd;
                
            }
        }
    }

    public sealed class ViewGroupSub : ViewGroup
    {
        private ClockAndroidView clockAndroidView;

        public ViewGroupSub(Context context): base(context)
        {
            clockAndroidView = new ClockAndroidView(context);
            AddView(clockAndroidView);

            clockAndroidView.Touch += (s, e) =>
            {
                if (e.Event.Action == MotionEventActions.Down)
                {
                    clockAndroidView.drucking = true;
                }
                else if (e.Event.Action == MotionEventActions.Up)
                {
                    clockAndroidView.drucking = false;
                }

                //System.Diagnostics.Debug.WriteLine("e.Event = {0}", e.Event);

            };
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            var msw = MeasureSpec.MakeMeasureSpec(r - l, MeasureSpecMode.Exactly);
            var msh = MeasureSpec.MakeMeasureSpec(b - t, MeasureSpecMode.Exactly);

            clockAndroidView.Measure(msw, msh);
            clockAndroidView.Layout(0, 0, r - l, b - t);
        }

        public DateTime PeriodEnd
        {
            get { return clockAndroidView.periodEnd; }
            set {
                clockAndroidView.periodEnd = value;
                clockAndroidView.incleaseMinutes = 0;
            }
        }
       


    }




}