using System.Threading.Tasks;

namespace JobManager.Services
{
    public interface IMediaService
    {
        Task<byte[]> CapturePhotoAsync(); //Opens the camera to take a photo.

    }
}