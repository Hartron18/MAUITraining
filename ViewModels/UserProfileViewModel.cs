using CommunityToolkit.Mvvm.Input;
using System;
using MAUITraining;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MAUITraining.Views;

namespace MAUITraining.ViewModels
{
    public partial class UserProfileViewModel : UserProfilePage
    {
        public UserProfileViewModel()
        {

        }

        //[RelayCommand]
        //public async Task SnapPictureCommand()
        //{
        //    HttpClient client = new HttpClient();

        //    Uri uri = "";
        //    bool isCamEnabled = MediaPicker.Default.IsCaptureSupported;
        //    if (isCamEnabled)
        //    { 
        //        FileResult photo = await MediaPicker.CapturePhotoAsync();


        //        client.PostAsync(uri, photo)
        //    }
        //}

        [RelayCommand]
        public async Task TakePhoto()
        {
            
            bool isCamEnabled = MediaPicker.Default.IsCaptureSupported;
            if (isCamEnabled)
            {
                FileResult photo = await MediaPicker.CapturePhotoAsync();

                if(photo != null)
                {
                    string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

                    using Stream sourceStream = await photo.OpenReadAsync();

                    using FileStream localFileStream = File.OpenWrite(localFilePath);

                    await sourceStream.CopyToAsync(localFileStream);


                    //Image image = (Image)FindByName("ProfileImage");
                    //image.Source = ImageSource.FromStream(() => localFileStream);

                    Image imag = (Image)Shell.Current.CurrentPage.FindByName("ProfileImage");
                    
                    Image imagee = imag;
                    imagee.Source = ImageSource.FromStream(() => localFileStream);


                    

                   
                }
                
            }
        }
    }
}
