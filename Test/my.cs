// 测试使用不同平台的框架同时调用两个摄像头
// CPCamera means Cross-Platform Camera
// 目前仅实现了Android平台调用摄像头，尚未实现录制
// 各平台实现应当在Platforms/*/my.cs中（虽然这不符合命名规范）

namespace my
{
    public partial class CPCamera
    {
        public static partial void RecordVideo();
    }
}