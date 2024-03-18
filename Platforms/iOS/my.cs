namespace my
{
    using AVFoundation;
    public partial class CPCamera
    {
        /*async Task AuthorizeCameraUse()
        {
            var status = AVCaptureDevice.GetAuthorizationStatus(AVMediaType.Video);
            if (status != AVAuthorizationStatus.Authorized)
            {
                status = await AVCaptureDevice.RequestAccessForMediaTypeAsync(AVMediaType.Video);
                if (status != AVAuthorizationStatus.Authorized)
                {
                    // Notify the user that the camera is not available
                }
            }
        }*/

        public static partial void RecordVideo()
        {

        }
    }
}