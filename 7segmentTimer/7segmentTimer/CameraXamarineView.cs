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

        public static readonly BindableProperty IsPreviewingProperty = BindableProperty.Create(
            propertyName: "IsPreviewing",
            returnType: typeof(bool),
            declaringType: typeof(CameraXamarineView),
            defaultValue: false);

        public bool IsPreviewing
            {
                get { return (bool)GetValue(IsPreviewingProperty); }
                set { SetValue(IsPreviewingProperty, value); }
            }
    }

    public enum CameraOptions
    {
        Rear,
        Front
    }
}