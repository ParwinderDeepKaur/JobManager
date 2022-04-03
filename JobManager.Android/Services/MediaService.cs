using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using JobManager.Droid.Services;
using JobManager.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(MediaService))]

// Needed for Picking photo/video
[assembly: UsesPermission(Android.Manifest.Permission.ReadExternalStorage)]

// Needed for Taking photo/video
[assembly: UsesPermission(Android.Manifest.Permission.WriteExternalStorage)]
[assembly: UsesPermission(Android.Manifest.Permission.Camera)]

// Add these properties if you would like to filter out devices that do not have cameras, or set to false to make them optional.
[assembly: UsesFeature("android.hardware.camera", Required = true)]
[assembly: UsesFeature("android.hardware.camera.autofocus", Required = true)]

namespace JobManager.Droid.Services
{
    public class MediaService : IMediaService
    {
        public async Task<byte[]> CapturePhotoAsync()
        {
            try
            {
                FileResult result = await MediaPicker.CapturePhotoAsync();

                Stream stream = await result.OpenReadAsync();

                MemoryStream memoryStream = new MemoryStream();
                stream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
            catch (FeatureNotSupportedException ex)
            {
            }
            catch (PermissionException ex)
            {
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
            }

            return null;
        }
    }
}