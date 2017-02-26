
using System;
using Xamarin.Forms;

namespace _7segmentTimer
{
    public class ClockXamarineFormsView : View
    {
        public static readonly BindableProperty PeriodEndPropaty = BindableProperty.Create(
            propertyName: "PeriodEnd",
            returnType: typeof(DateTime),
            declaringType: typeof(ClockXamarineFormsView),
            defaultValue: DateTime.MinValue);

        public DateTime PeriodEnd
        {
            get { return (DateTime)GetValue(PeriodEndPropaty); }
            set { SetValue(PeriodEndPropaty, value); }
        }

        public static readonly BindableProperty DebuggerDoruckingPropaty = BindableProperty.Create(
            propertyName: "DebuggerDorucking",
            returnType: typeof(bool),
            declaringType: typeof(ClockXamarineFormsView),
            defaultValue: false);

        public bool DebuggerDorucking
        {
            get { return (bool)GetValue(DebuggerDoruckingPropaty); }
            set { SetValue(DebuggerDoruckingPropaty, value); }
        }




    }








}