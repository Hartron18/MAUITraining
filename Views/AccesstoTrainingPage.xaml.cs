using Camera.MAUI;
using Camera.MAUI.ZXingHelper;

namespace MAUITraining.Views;

public partial class AccesstoTrainingPage : ContentPage
{
	public AccesstoTrainingPage()
	{
		InitializeComponent();
     
        BarCodecam.BarCodeOptions = new()
        {
            AutoRotate= true
            
        };
        
    }

    public void CameraLoaded(object sender, EventArgs args)
    {
        

        if (BarCodecam.Cameras.Count > 0)
        {
            BarCodecam.Camera = BarCodecam.Cameras.First();
            MainThread.InvokeOnMainThreadAsync(async () => 
            {
                
                await BarCodecam.StartCameraAsync();
                
                await BarCodecam.StopCameraAsync();
            });
        }
    }

    public void BarCodeDetected(object sender, BarcodeEventArgs args)
    {

        MainThread.BeginInvokeOnMainThread(() =>
        {
            BarCodeDiplay.Text = $"{args.Result[0].BarcodeFormat}:{args.Result[0].Text}";
        });
    }
}