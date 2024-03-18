namespace MauiAppTest
{
    public partial class MainPage : ContentPage
    {
        // int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            /*
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
            */
            // my.CPCamera.RecordVideo();
            RecordVideo();
        }
        // 这是调用摄像头（默认后置）进行录像的方法（异步）
        // 核心方法：MediaPicker.Default.CaptureVideoAsync()
        // 应该会存储到cache文件夹中
        public async static void RecordVideo()
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult? video = await MediaPicker.Default.CaptureVideoAsync();
                if (video != null)
                {
                    string localFilePath = Path.Combine(FileSystem.CacheDirectory, video.FileName);
                    using Stream sourceStream = await video.OpenReadAsync();
                    using FileStream localFileStream = File.OpenWrite(localFilePath);
                    await sourceStream.CopyToAsync(localFileStream);
                }
            }
        }
    }
}
