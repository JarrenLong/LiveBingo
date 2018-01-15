using AForge.Video;
using AForge.Video.DirectShow;
using LongTech.UI.Controls;
using System.Drawing;

namespace LongTech.Apps
{
  public partial class CameraVideo : UserControl
  {
    public CameraVideo()
    {
      InitializeComponent();
    }

    private bool _CameraOn = false;
    public bool CameraOn
    {
      get
      {
        return _CameraOn;
      }
      set
      {
        _CameraOn = value;
        SetState(value);
      }
    }

    #region Camera
    private static int fps = 0;
    private FilterInfoCollection videoDevices = null;
    private VideoCaptureDevice videoSource = null;
    private static Bitmap frame = null;

    private void SetState(bool serverOn)
    {
      if (serverOn)
      {
        bool DeviceExist = false;
        //Get a list of available video devices
        try
        {
          videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
          //if (videoDevices.Count == 0)
          //throw new ApplicationException();
          DeviceExist = (videoDevices.Count > 0);
        }
        catch
        {
          // FileLogger.Log("Error fetching list of video devices");
        }

        // If we have at least one camera, turn it on
        if (DeviceExist)
        {
          videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
          videoSource.NewFrame += new NewFrameEventHandler(Video_NewFrame);
          videoSource.Start();
        }
      }
      else
      {
        if (videoSource != null && videoSource.IsRunning)
          videoSource.SignalToStop();
        videoSource = null;
      }
    }

    private void Video_NewFrame(object sender, NewFrameEventArgs eventArgs)
    {
      try
      {
        frame = (Bitmap)eventArgs.Frame.Clone();
        if (frame != null)
        {
          PictureBox1.Image = frame;
          frame = null;
          fps++;
        }
      }
      catch
      {
        // FileLogger.Log("Error reading video frame");
      }
    }
    #endregion
  }
}
