using System;
using Xamarin.Forms;


namespace _7segmentTimer
{
    public class CameraXamarineView : View
    {
            public static readonly BindableProperty CameraProperty = BindableProperty.Create(
                propertyName: "Camera",
                returnType: typeof(CameraOptions),
                declaringType: typeof(CameraPreviewGroup),
                defaultValue: CameraOptions.Rear);

            public CameraOptions Camera
            {
                get {return (CameraOptions)GetValue(CameraProperty); }
                set {SetValue(CameraProperty, value); }
            }
        }

    public enum CameraOptions
    {
        Rear,
        Front
    }
}