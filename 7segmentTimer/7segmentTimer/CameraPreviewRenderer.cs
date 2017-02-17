using System;
using Android.Hardware;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer (typeof(_7segmentTimer.CameraXamarineView), typeof(_7segmentTimer.CameraPreviewRenderer))]
namespace _7segmentTimer
{
	public class CameraPreviewRenderer : ViewRenderer<_7segmentTimer.CameraXamarineView, _7segmentTimer.CameraPreviewGroup>
	{
		CameraPreviewGroup cameraPreview;

        protected override void OnElementChanged(ElementChangedEventArgs<CameraXamarineView> e)
		{
			base.OnElementChanged (e);

			if (Control == null) {
				cameraPreview = new CameraPreviewGroup (Context);
				SetNativeControl (cameraPreview);
			}

			if (e.OldElement != null) {
				// Unsubscribe
				cameraPreview.Click -= OnCameraPreviewClicked;
			}
			if (e.NewElement != null) {
				Control.Preview = Camera.Open ((int)e.NewElement.Camera);

				// Subscribe
				cameraPreview.Click += OnCameraPreviewClicked;
			}
		}

		void OnCameraPreviewClicked (object sender, EventArgs e)
		{
			if (cameraPreview.IsPreviewing) {
				cameraPreview.Preview.StopPreview ();
				cameraPreview.IsPreviewing = false;
			} else {
				cameraPreview.Preview.StartPreview ();
				cameraPreview.IsPreviewing = true;
			}
		}

		protected override void Dispose (bool disposing)
		{
			if (disposing) {
				Control.Preview.Release ();
			}
			base.Dispose (disposing);
		}
	}
}
