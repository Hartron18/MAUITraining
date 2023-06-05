using Camera.MAUI;
using Camera.MAUI.ZXingHelper;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUITraining.ViewModels
{
    partial class TrainingViewModel:ObservableObject
    {
        [ObservableProperty]
        Label labell;

        [ObservableProperty]
        CameraView cameraView;

        

        public TrainingViewModel()
        {
            CameraView.ControlBarcodeResultDuplicate = true;
            CameraView.BarCodeOptions = new()
            {
                AutoRotate = true
            };
            
        }

        
        public void OnCameraLoaded(object sender, EventArgs args)
        {
            
            if(CameraView.Cameras.Count > 0)
            {
                CameraView.Camera = CameraView.Cameras.First();
                MainThread.InvokeOnMainThreadAsync(async () =>
                {
                    await CameraView.StartCameraAsync();
                    await CameraView.StopCameraAsync();
                });
            }
        }

        
        public void BarCodeDetected(object sender, BarcodeEventArgs args)
        {

            MainThread.BeginInvokeOnMainThread(() =>
            {
                Labell.Text = $"{args.Result[0].BarcodeFormat}:{args.Result[0].Text}";
            });
        }
    }
}
