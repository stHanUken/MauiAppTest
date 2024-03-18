// 以下代码仅供参考:)
// 无注释警告:)

namespace my
{
    using Android.Hardware.Camera2;
    using Android.Content;
    using Java.Util.Concurrent;
    using Android.Runtime;
    using Android.Graphics;
    using Android.Views;

    public partial class CPCamera
    {
        class DualCamera
        {
            string logicalId;
            string physicalId1;
            string physicalId2;

            public DualCamera(string logicalId, string physicalId1, string physicalId2)
            {
                this.logicalId = logicalId;
                this.physicalId1 = physicalId1;
                this.physicalId2 = physicalId2;
            }

            public static void OpenDualCamera(CameraManager cameraManager, DualCamera dualCamera, Java.Util.Concurrent.IExecutor executor, CameraDevice.StateCallback stateCallback)
            {
                cameraManager.OpenCamera(dualCamera.physicalId1, executor, stateCallback);
                cameraManager.OpenCamera(dualCamera.physicalId2, executor, stateCallback);
            }

            public static void SetDualCameraOutput(CameraManager cameraManager, DualCamera dualCamera)
            {
                
            }
        }
        class CameraCaptureSessionStateCallback : CameraCaptureSession.StateCallback
        {
            public override void OnConfigured(CameraCaptureSession session)
            {
                throw new NotImplementedException();
            }
            public override void OnConfigureFailed(CameraCaptureSession session)
            {
                throw new NotImplementedException();
            }
        }
        class CameraDeviceStateCallback : CameraDevice.StateCallback
        {
            public override void OnOpened(CameraDevice camera)
            {
                Console.WriteLine("Camera opened");
                var surface = new Surface(new SurfaceTexture(0));
                camera.CreateCaptureSession(new List<Surface>() { surface }, new CameraCaptureSessionStateCallback(), null);
                var builder = camera.CreateCaptureRequest(CameraTemplate.Record);
                builder.AddTarget(surface);
            }
            public override void OnClosed(CameraDevice camera)
            {
                Console.WriteLine("Camera closed");
            }
            public override void OnDisconnected(CameraDevice camera)
            {
                Console.WriteLine("Camera disconnected");
            }
            public override void OnError(CameraDevice camera, [GeneratedEnum] CameraError error)
            {
                throw new NotImplementedException();
            }
        }
        public static partial void RecordVideo()
        {
            CameraManager cameraManager = Android.App.Application.Context.GetSystemService(Context.CameraService) as CameraManager;
            string[] cameraIds = cameraManager.GetCameraIdList();
            if (cameraIds.Length < 2)
            {
                Console.WriteLine("No dual cameras available");
                return;
            }
            DualCamera dualCamera = new DualCamera("0", cameraIds[0], cameraIds[1]);
            IExecutor executor = Java.Util.Concurrent.Executors.NewSingleThreadExecutor();
            CameraDevice.StateCallback stateCallback = new CameraDeviceStateCallback();
            DualCamera.OpenDualCamera(cameraManager, dualCamera, executor, stateCallback);
            
        }
    }
}
