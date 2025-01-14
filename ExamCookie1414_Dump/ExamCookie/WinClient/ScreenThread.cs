// Decompiled with JetBrains decompiler
// Type: ExamCookie.WinClient.ScreenThread
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace ExamCookie.WinClient
{
  public class ScreenThread
  {
    private const int THREAD_SLEEP = 500;
    private bool _Started;
    private float _ScreenChangedPercent;
    private int _ImageQuality;
    private int _PostSendDelay;
    private Stopwatch _ForceScreenshotStopwatch;
    private int _ForceScreenshotDelay;
    private bool _TakeScreenshot;
    private Rectangle _TakeScreenshotAtPoint;
    private List<ScreenThread.Monitor> _Monitors;
    [SpecialName]
    private Screen[] \u0024STATIC\u0024ScreenSetupChanged\u00242002\u0024screens;
    [SpecialName]
    private StaticLocalInitFlag \u0024STATIC\u0024ScreenSetupChanged\u00242002\u0024screens\u0024Init;

    public event ScreenThread.OnScreenChangedEventHandler OnScreenChanged;

    public event ScreenThread.OnDebugEventHandler OnDebug;

    public event ScreenThread.OnExceptionEventHandler OnException;

    public ScreenThread()
    {
      this._Started = false;
      this._ScreenChangedPercent = 0.0f;
      this._ImageQuality = 20;
      this._PostSendDelay = 0;
      this._ForceScreenshotStopwatch = new Stopwatch();
      this._ForceScreenshotDelay = 0;
      this._TakeScreenshot = false;
      this.TakeScreenshotDelay = new System.Windows.Forms.Timer();
      this._TakeScreenshotAtPoint = Rectangle.Empty;
      this.TakeScreenshotAtPointDelay = new System.Windows.Forms.Timer();
      this._Monitors = new List<ScreenThread.Monitor>();
    }

    public ScreenThread(int polltime)
    {
      ScreenThread screenThread = this;
      this._Started = false;
      this._ScreenChangedPercent = 0.0f;
      this._ImageQuality = 20;
      this._PostSendDelay = 0;
      this._ForceScreenshotStopwatch = new Stopwatch();
      this._ForceScreenshotDelay = 0;
      this._TakeScreenshot = false;
      this.TakeScreenshotDelay = new System.Windows.Forms.Timer();
      this._TakeScreenshotAtPoint = Rectangle.Empty;
      this.TakeScreenshotAtPointDelay = new System.Windows.Forms.Timer();
      this._Monitors = new List<ScreenThread.Monitor>();
      if (polltime <= 0)
        return;
      if (polltime < 500)
        polltime = 500;
      Thread thread = new Thread((ThreadStart) ([SpecialName] () => screenThread.Main(polltime)));
      this.Started = true;
      thread.Start();
    }

    public bool Started
    {
      get => this._Started;
      set => this._Started = value;
    }

    public float ScreenChangedPercent
    {
      get => this._ScreenChangedPercent;
      set
      {
        if ((double) value != 0.0)
        {
          if ((double) value < 3.0)
            value = 3f;
          else if ((double) value > 50.0)
            value = 50f;
        }
        this._ScreenChangedPercent = value;
      }
    }

    public int ImageQuality
    {
      get => this._ImageQuality;
      set
      {
        if (value < 5)
          this._ImageQuality = 5;
        else if (value > 100)
          this._ImageQuality = 100;
        else
          this._ImageQuality = value;
      }
    }

    public int PostSendDelay
    {
      get => this._PostSendDelay;
      set => this._PostSendDelay = value;
    }

    public int ForceScreenshotDelay
    {
      get => this._ForceScreenshotDelay;
      set
      {
        if (value == 0)
          this._ForceScreenshotStopwatch.Stop();
        else
          this._ForceScreenshotStopwatch.Restart();
        this._ForceScreenshotDelay = value;
      }
    }

    public void TakeScreenshot(int index)
    {
      try
      {
        foreach (ScreenThread.Monitor monitor in this._Monitors)
        {
          if (monitor.Index == index | index == 0)
            monitor.Changed = true;
        }
      }
      finally
      {
        List<ScreenThread.Monitor>.Enumerator enumerator;
        enumerator.Dispose();
      }
      this._TakeScreenshot = true;
    }

    private virtual System.Windows.Forms.Timer TakeScreenshotDelay
    {
      get => this._TakeScreenshotDelay;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.OnTakeScreenshotDelay);
        System.Windows.Forms.Timer takeScreenshotDelay1 = this._TakeScreenshotDelay;
        if (takeScreenshotDelay1 != null)
          takeScreenshotDelay1.Tick -= eventHandler;
        this._TakeScreenshotDelay = value;
        System.Windows.Forms.Timer takeScreenshotDelay2 = this._TakeScreenshotDelay;
        if (takeScreenshotDelay2 == null)
          return;
        takeScreenshotDelay2.Tick += eventHandler;
      }
    }

    public void TakeScreenshot(int index, int delay)
    {
      try
      {
        foreach (ScreenThread.Monitor monitor in this._Monitors)
        {
          if (monitor.Index == index | index == 0)
            monitor.Changed = true;
        }
      }
      finally
      {
        List<ScreenThread.Monitor>.Enumerator enumerator;
        enumerator.Dispose();
      }
      this.TakeScreenshotDelay.Interval = delay;
      this.TakeScreenshotDelay.Start();
    }

    public void TakeScreenshot(Rectangle rectangle) => this._TakeScreenshotAtPoint = rectangle;

    private virtual System.Windows.Forms.Timer TakeScreenshotAtPointDelay
    {
      get => this._TakeScreenshotAtPointDelay;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.OnTakeScreenshotAtPointDelay);
        System.Windows.Forms.Timer screenshotAtPointDelay1 = this._TakeScreenshotAtPointDelay;
        if (screenshotAtPointDelay1 != null)
          screenshotAtPointDelay1.Tick -= eventHandler;
        this._TakeScreenshotAtPointDelay = value;
        System.Windows.Forms.Timer screenshotAtPointDelay2 = this._TakeScreenshotAtPointDelay;
        if (screenshotAtPointDelay2 == null)
          return;
        screenshotAtPointDelay2.Tick += eventHandler;
      }
    }

    public void TakeScreenshot(Rectangle rectangle, int delay)
    {
      this.TakeScreenshotAtPointDelay.Interval = delay;
      this.TakeScreenshotAtPointDelay.Tag = (object) rectangle;
      this.TakeScreenshotAtPointDelay.Start();
    }

    private void Main(int polltime)
    {
      Stopwatch stopwatch = new Stopwatch();
      stopwatch.Start();
      while (this.Started)
      {
        try
        {
          if (stopwatch.ElapsedMilliseconds >= (long) polltime)
          {
            stopwatch.Restart();
            if (((IEnumerable<Screen>) Screen.AllScreens).Count<Screen>() == 0)
              this._Monitors.Clear();
            else if (this.ScreenSetupChanged())
            {
              this.GetMonitors();
              try
              {
                foreach (ScreenThread.Monitor monitor in this._Monitors)
                {
                  monitor.Changed = true;
                  this.CaptureScreen(ref monitor);
                }
              }
              finally
              {
                List<ScreenThread.Monitor>.Enumerator enumerator;
                enumerator.Dispose();
              }
              // ISSUE: reference to a compiler-generated field
              ScreenThread.OnDebugEventHandler onDebugEvent = this.OnDebugEvent;
              if (onDebugEvent != null)
                onDebugEvent("SCREEN_SETUP_CHANGED");
            }
            else if (this._ForceScreenshotStopwatch.ElapsedMilliseconds >= (long) this.ForceScreenshotDelay)
            {
              try
              {
                foreach (ScreenThread.Monitor monitor in this._Monitors)
                {
                  monitor.Changed = true;
                  this.CaptureScreen(ref monitor);
                }
              }
              finally
              {
                List<ScreenThread.Monitor>.Enumerator enumerator;
                enumerator.Dispose();
              }
              // ISSUE: reference to a compiler-generated field
              ScreenThread.OnDebugEventHandler onDebugEvent = this.OnDebugEvent;
              if (onDebugEvent != null)
                onDebugEvent("FORCE_SCREENSHOT_ALL");
            }
            else if (!this._TakeScreenshotAtPoint.IsEmpty)
            {
              try
              {
                foreach (ScreenThread.Monitor monitor in this._Monitors)
                {
                  if (monitor.Bounds().IntersectsWith(this._TakeScreenshotAtPoint))
                  {
                    monitor.Changed = true;
                    this.CaptureScreen(ref monitor);
                    // ISSUE: reference to a compiler-generated field
                    ScreenThread.OnDebugEventHandler onDebugEvent = this.OnDebugEvent;
                    if (onDebugEvent != null)
                      onDebugEvent(string.Format("POINT_SCREENSHOT{0}. X={1}, Y={2}", (object) monitor.Index, (object) this._TakeScreenshotAtPoint.X, (object) this._TakeScreenshotAtPoint.Y));
                  }
                }
              }
              finally
              {
                List<ScreenThread.Monitor>.Enumerator enumerator;
                enumerator.Dispose();
              }
              this._TakeScreenshotAtPoint = Rectangle.Empty;
            }
            else if (this._TakeScreenshot)
            {
              this._TakeScreenshot = false;
              try
              {
                foreach (ScreenThread.Monitor monitor in this._Monitors)
                  this.CaptureScreen(ref monitor);
              }
              finally
              {
                List<ScreenThread.Monitor>.Enumerator enumerator;
                enumerator.Dispose();
              }
              // ISSUE: reference to a compiler-generated field
              ScreenThread.OnDebugEventHandler onDebugEvent = this.OnDebugEvent;
              if (onDebugEvent != null)
                onDebugEvent("MANUEL_SCREENSHOT");
            }
            else
            {
              if ((double) this.ScreenChangedPercent >= 1.0)
              {
                Image image2 = (Image) null;
                try
                {
                  foreach (ScreenThread.Monitor monitor in this._Monitors)
                  {
                    Rectangle rectangle = monitor.Bounds();
                    int x = rectangle.X;
                    rectangle = monitor.Bounds();
                    int y = rectangle.Y;
                    rectangle = monitor.Bounds();
                    int width = rectangle.Width;
                    rectangle = monitor.Bounds();
                    int height = rectangle.Height;
                    ref Image local = ref image2;
                    if (this.CaptureScreen(x, y, width, height, ref local) == 0)
                    {
                      float num = this.CompareImagesPixelBased(monitor.Frame, image2);
                      if ((double) num > (double) this.ScreenChangedPercent)
                      {
                        monitor.Changed = true;
                        monitor.Frame = image2;
                        // ISSUE: reference to a compiler-generated field
                        ScreenThread.OnDebugEventHandler onDebugEvent = this.OnDebugEvent;
                        if (onDebugEvent != null)
                          onDebugEvent(string.Format("SCREEN{0}_DIFFERENCE={1}%", (object) monitor.Index, (object) num));
                      }
                    }
                  }
                }
                finally
                {
                  List<ScreenThread.Monitor>.Enumerator enumerator;
                  enumerator.Dispose();
                }
              }
              Module1.OptimizeMemoryConsumption();
            }
            byte[] compressed = (byte[]) null;
            try
            {
              foreach (ScreenThread.Monitor monitor in this._Monitors)
              {
                if (monitor.Changed)
                {
                  monitor.Changed = false;
                  if (this.CompressImage((long) this.ImageQuality, monitor.Frame, ref compressed) == 0)
                  {
                    // ISSUE: reference to a compiler-generated field
                    ScreenThread.OnScreenChangedEventHandler screenChangedEvent = this.OnScreenChangedEvent;
                    if (screenChangedEvent != null)
                      screenChangedEvent(new ScreenThread.ScreenChanged(monitor.Index, monitor.Bounds(), compressed));
                  }
                  this._ForceScreenshotStopwatch.Restart();
                }
              }
            }
            finally
            {
              List<ScreenThread.Monitor>.Enumerator enumerator;
              enumerator.Dispose();
            }
          }
        }
        catch (Exception ex1)
        {
          ProjectData.SetProjectError(ex1);
          Exception ex2 = ex1;
          // ISSUE: reference to a compiler-generated field
          ScreenThread.OnExceptionEventHandler onExceptionEvent = this.OnExceptionEvent;
          if (onExceptionEvent != null)
            onExceptionEvent(ex2);
          ProjectData.ClearProjectError();
        }
        finally
        {
          Thread.Sleep(500);
        }
      }
    }

    private bool ScreenSetupChanged()
    {
      if (this.\u0024STATIC\u0024ScreenSetupChanged\u00242002\u0024screens\u0024Init == null)
        Interlocked.CompareExchange<StaticLocalInitFlag>(ref this.\u0024STATIC\u0024ScreenSetupChanged\u00242002\u0024screens\u0024Init, new StaticLocalInitFlag(), (StaticLocalInitFlag) null);
      bool lockTaken = false;
      try
      {
        System.Threading.Monitor.Enter((object) this.\u0024STATIC\u0024ScreenSetupChanged\u00242002\u0024screens\u0024Init, ref lockTaken);
        if (this.\u0024STATIC\u0024ScreenSetupChanged\u00242002\u0024screens\u0024Init.State == (short) 0)
        {
          this.\u0024STATIC\u0024ScreenSetupChanged\u00242002\u0024screens\u0024Init.State = (short) 2;
          this.\u0024STATIC\u0024ScreenSetupChanged\u00242002\u0024screens = (Screen[]) null;
        }
        else if (this.\u0024STATIC\u0024ScreenSetupChanged\u00242002\u0024screens\u0024Init.State == (short) 2)
          throw new IncompleteInitialization();
      }
      finally
      {
        this.\u0024STATIC\u0024ScreenSetupChanged\u00242002\u0024screens\u0024Init.State = (short) 1;
        if (lockTaken)
          System.Threading.Monitor.Exit((object) this.\u0024STATIC\u0024ScreenSetupChanged\u00242002\u0024screens\u0024Init);
      }
      bool flag;
      try
      {
        if (this.\u0024STATIC\u0024ScreenSetupChanged\u00242002\u0024screens == null)
        {
          this.\u0024STATIC\u0024ScreenSetupChanged\u00242002\u0024screens = Screen.AllScreens;
          flag = true;
        }
        else if (((IEnumerable<Screen>) this.\u0024STATIC\u0024ScreenSetupChanged\u00242002\u0024screens).Count<Screen>() != ((IEnumerable<Screen>) Screen.AllScreens).Count<Screen>())
        {
          this.\u0024STATIC\u0024ScreenSetupChanged\u00242002\u0024screens = Screen.AllScreens;
          flag = true;
        }
        else
        {
          int num = checked (((IEnumerable<Screen>) Screen.AllScreens).Count<Screen>() - 1);
          int index = 0;
          while (index <= num)
          {
            if (Operators.CompareString(this.\u0024STATIC\u0024ScreenSetupChanged\u00242002\u0024screens[index].ToString(), Screen.AllScreens[index].ToString(), false) != 0)
            {
              this.\u0024STATIC\u0024ScreenSetupChanged\u00242002\u0024screens = Screen.AllScreens;
              flag = true;
              goto label_22;
            }
            else
              checked { ++index; }
          }
          flag = false;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        flag = false;
        ProjectData.ClearProjectError();
      }
label_22:
      return flag;
    }

    private int GetMonitors()
    {
      int count;
      try
      {
        this._Monitors.Clear();
        Screen[] allScreens = Screen.AllScreens;
        int index = 0;
        while (index < allScreens.Length)
        {
          Screen screen = allScreens[index];
          Module1.DEVMODE lpDevMode = new Module1.DEVMODE();
          lpDevMode.dmSize = checked ((short) Marshal.SizeOf(typeof (Module1.DEVMODE)));
          Module1.EnumDisplaySettings(screen.DeviceName, -1, ref lpDevMode);
          this._Monitors.Add(new ScreenThread.Monitor(checked (this._Monitors.Count + 1), Math.Round(Decimal.Divide(new Decimal(lpDevMode.dmPelsWidth), new Decimal(screen.Bounds.Width)), 2), new Point(lpDevMode.dmPositionX, lpDevMode.dmPositionY), screen.Bounds.Size));
          string message = "SCREEN " + this._Monitors.Last<ScreenThread.Monitor>().ToString();
          // ISSUE: reference to a compiler-generated field
          ScreenThread.OnDebugEventHandler onDebugEvent = this.OnDebugEvent;
          if (onDebugEvent != null)
            onDebugEvent(message);
          // ISSUE: reference to a compiler-generated field
          ScreenThread.OnExceptionEventHandler onExceptionEvent = this.OnExceptionEvent;
          if (onExceptionEvent != null)
            onExceptionEvent(new Exception(message));
          checked { ++index; }
        }
        count = this._Monitors.Count;
      }
      catch (Exception ex1)
      {
        ProjectData.SetProjectError(ex1);
        Exception ex2 = ex1;
        // ISSUE: reference to a compiler-generated field
        ScreenThread.OnExceptionEventHandler onExceptionEvent = this.OnExceptionEvent;
        if (onExceptionEvent != null)
          onExceptionEvent(ex2);
        count = this._Monitors.Count;
        ProjectData.ClearProjectError();
      }
      return count;
    }

    private int CaptureScreen(int x, int y, int width, int height, ref Image image)
    {
      int num;
      try
      {
        using (Bitmap bitmap = new Bitmap(width, height))
        {
          using (Graphics graphics = Graphics.FromImage((Image) bitmap))
          {
            graphics.CopyFromScreen(x, y, 0, 0, new Size(width, height));
            image = (Image) bitmap.Clone();
            num = 0;
          }
        }
      }
      catch (Win32Exception ex1)
      {
        ProjectData.SetProjectError((Exception) ex1);
        Win32Exception ex2 = ex1;
        // ISSUE: reference to a compiler-generated field
        ScreenThread.OnExceptionEventHandler onExceptionEvent = this.OnExceptionEvent;
        if (onExceptionEvent != null)
          onExceptionEvent((Exception) ex2);
        num = -2;
        ProjectData.ClearProjectError();
      }
      catch (Exception ex3)
      {
        ProjectData.SetProjectError(ex3);
        Exception ex4 = ex3;
        // ISSUE: reference to a compiler-generated field
        ScreenThread.OnExceptionEventHandler onExceptionEvent = this.OnExceptionEvent;
        if (onExceptionEvent != null)
          onExceptionEvent(ex4);
        num = -1;
        ProjectData.ClearProjectError();
      }
      return num;
    }

    private int CaptureScreen(ref ScreenThread.Monitor monitor)
    {
      int num;
      try
      {
        if (!monitor.Changed)
        {
          num = 0;
        }
        else
        {
          int width1 = monitor.Bounds().Width;
          Rectangle rectangle = monitor.Bounds();
          int height1 = rectangle.Height;
          using (Bitmap bitmap = new Bitmap(width1, height1))
          {
            using (Graphics graphics1 = Graphics.FromImage((Image) bitmap))
            {
              Graphics graphics2 = graphics1;
              rectangle = monitor.Bounds();
              int x = rectangle.X;
              rectangle = monitor.Bounds();
              int y = rectangle.Y;
              rectangle = monitor.Bounds();
              int width2 = rectangle.Width;
              rectangle = monitor.Bounds();
              int height2 = rectangle.Height;
              Size blockRegionSize = new Size(width2, height2);
              graphics2.CopyFromScreen(x, y, 0, 0, blockRegionSize);
              monitor.Frame = (Image) bitmap.Clone();
              num = 0;
            }
          }
        }
      }
      catch (Win32Exception ex1)
      {
        ProjectData.SetProjectError((Exception) ex1);
        Win32Exception ex2 = ex1;
        // ISSUE: reference to a compiler-generated field
        ScreenThread.OnExceptionEventHandler onExceptionEvent = this.OnExceptionEvent;
        if (onExceptionEvent != null)
          onExceptionEvent((Exception) ex2);
        num = -2;
        ProjectData.ClearProjectError();
      }
      catch (Exception ex3)
      {
        ProjectData.SetProjectError(ex3);
        Exception ex4 = ex3;
        // ISSUE: reference to a compiler-generated field
        ScreenThread.OnExceptionEventHandler onExceptionEvent = this.OnExceptionEvent;
        if (onExceptionEvent != null)
          onExceptionEvent(ex4);
        num = -1;
        ProjectData.ClearProjectError();
      }
      return num;
    }

    private int ResizeImage(float scale, Image image, ref Image resized)
    {
      int num;
      try
      {
        int width = checked ((int) Math.Round(unchecked ((double) image.Width * (double) scale)));
        int height = checked ((int) Math.Round(unchecked ((double) image.Height * (double) scale)));
        using (Bitmap bitmap = new Bitmap(width, height))
        {
          using (Graphics graphics = Graphics.FromImage((Image) bitmap))
          {
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBilinear;
            graphics.DrawImage(image, new Rectangle(0, 0, width, height));
            resized = (Image) bitmap.Clone();
            num = 0;
          }
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        num = -1;
        ProjectData.ClearProjectError();
      }
      return num;
    }

    public int CompressImage(long quality, Image image, ref byte[] compressed)
    {
      int num;
      try
      {
        using (MemoryStream memoryStream = new MemoryStream())
        {
          EncoderParameters encoderParams = new EncoderParameters(1);
          encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, quality);
          ImageCodecInfo encoderInfo = this.GetEncoderInfo("image/jpeg");
          if (encoderInfo != null)
          {
            image.Save((Stream) memoryStream, encoderInfo, encoderParams);
            compressed = memoryStream.ToArray();
            num = 0;
          }
          else
          {
            // ISSUE: reference to a compiler-generated field
            ScreenThread.OnExceptionEventHandler onExceptionEvent = this.OnExceptionEvent;
            if (onExceptionEvent != null)
              onExceptionEvent(new Exception("CompressImage, encoder ikke fundet"));
            num = 1;
          }
        }
      }
      catch (Exception ex1)
      {
        ProjectData.SetProjectError(ex1);
        Exception ex2 = ex1;
        // ISSUE: reference to a compiler-generated field
        ScreenThread.OnExceptionEventHandler onExceptionEvent = this.OnExceptionEvent;
        if (onExceptionEvent != null)
          onExceptionEvent(ex2);
        num = -1;
        ProjectData.ClearProjectError();
      }
      return num;
    }

    private ImageCodecInfo GetEncoderInfo(string mimeType)
    {
      return ((IEnumerable<ImageCodecInfo>) ImageCodecInfo.GetImageEncoders()).FirstOrDefault<ImageCodecInfo>((Func<ImageCodecInfo, bool>) ([SpecialName] (codec) => Operators.CompareString(codec.MimeType.ToLower(), mimeType.ToLower(), false) == 0));
    }

    private float CompareImagesPixelBased(Image image1, Image image2, byte threshold = 3)
    {
      byte[,] differences = image1.GetDifferences(image2);
      int num = 0;
      foreach (object obj in (Array) differences)
      {
        if ((uint) Conversions.ToByte(obj) > (uint) threshold)
          checked { ++num; }
      }
      return (float) ((double) num / 256.0 * 100.0);
    }

    private float CompareImagesRgbBased(Image image1, Image image2)
    {
      float num1;
      try
      {
        long[] rgbSum1 = this.CalculateRgbSum(image1);
        long[] rgbSum2 = this.CalculateRgbSum(image2);
        ulong num2 = 0;
        ulong num3 = 0;
        float num4 = 0.0f;
        if (rgbSum1.Length == rgbSum2.Length)
        {
          int num5 = checked (rgbSum1.Length - 1);
          int index = 0;
          while (index <= num5)
          {
            num2 = Convert.ToUInt64(Decimal.Add(new Decimal(num2), new Decimal(Math.Abs(checked (rgbSum1[index] - rgbSum2[index])))));
            num3 = Convert.ToUInt64(Decimal.Add(new Decimal(num3), new Decimal(rgbSum1[index])));
            checked { ++index; }
          }
          num4 = num2 <= num3 ? (num3 <= num2 ? 1f : (float) num2 / (float) num3) : (float) num3 / (float) num2;
        }
        num1 = num4 * 100f;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        num1 = 0.0f;
        ProjectData.ClearProjectError();
      }
      return num1;
    }

    private long[] CalculateRgbSum(Image image)
    {
      long[] rgbSum;
      try
      {
        using (Bitmap bitmap = new Bitmap(image))
        {
          PixelFormat pixelFormat = bitmap.PixelFormat;
          Rectangle rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
          BitmapData bitmapdata = bitmap.LockBits(rect, ImageLockMode.ReadWrite, pixelFormat);
          IntPtr scan0 = bitmapdata.Scan0;
          int length = checked (bitmap.Width * bitmap.Height * 3);
          byte[] destination = new byte[checked (length - 1 + 1)];
          Marshal.Copy(scan0, destination, 0, length);
          long[] numArray = new long[3];
          int num1 = checked (destination.Length - 1);
          int num2 = 0;
          while (num2 <= num1)
          {
            // ISSUE: variable of a reference type
            long& local1;
            // ISSUE: explicit reference operation
            long num3 = checked (^(local1 = ref numArray[0]) + (long) destination[num2 + 0]);
            local1 = num3;
            // ISSUE: variable of a reference type
            long& local2;
            // ISSUE: explicit reference operation
            long num4 = checked (^(local2 = ref numArray[1]) + (long) destination[num2 + 1]);
            local2 = num4;
            // ISSUE: variable of a reference type
            long& local3;
            // ISSUE: explicit reference operation
            long num5 = checked (^(local3 = ref numArray[2]) + (long) destination[num2 + 2]);
            local3 = num5;
            checked { num2 += 3; }
          }
          bitmap.UnlockBits(bitmapdata);
          rgbSum = numArray;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        rgbSum = new long[0];
        ProjectData.ClearProjectError();
      }
      return rgbSum;
    }

    private int ImageToByteArray(Image image, ref byte[] result)
    {
      int byteArray;
      try
      {
        using (MemoryStream memoryStream = new MemoryStream())
        {
          image.Save((Stream) memoryStream, ImageFormat.Jpeg);
          result = memoryStream.ToArray();
          byteArray = 0;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        byteArray = -1;
        ProjectData.ClearProjectError();
      }
      return byteArray;
    }

    private void OnTakeScreenshotDelay(object sender, EventArgs e)
    {
      this.TakeScreenshotDelay.Stop();
      this._TakeScreenshot = true;
    }

    private void OnTakeScreenshotAtPointDelay(object sender, EventArgs e)
    {
      this.TakeScreenshotAtPointDelay.Stop();
      if (!(this.TakeScreenshotAtPointDelay.Tag is Rectangle))
        return;
      object tag = this.TakeScreenshotAtPointDelay.Tag;
      this.TakeScreenshot(tag != null ? (Rectangle) tag : new Rectangle());
      this.TakeScreenshotAtPointDelay.Tag = (object) null;
    }

    public delegate void OnScreenChangedEventHandler(ScreenThread.ScreenChanged sender);

    public delegate void OnDebugEventHandler(string message);

    public delegate void OnExceptionEventHandler(Exception ex);

    private class Monitor
    {
      public int Index;
      public Point Location;
      public Decimal Scale;
      public Size Resolution;
      public Image Frame;
      public bool Changed;

      public Monitor()
      {
        this.Index = 0;
        this.Location = new Point();
        this.Scale = 1M;
        this.Resolution = new Size();
        this.Frame = (Image) null;
        this.Changed = false;
      }

      public Monitor(int index, Decimal scale, Point location, Size resolution)
      {
        this.Index = 0;
        this.Location = new Point();
        this.Scale = 1M;
        this.Resolution = new Size();
        this.Frame = (Image) null;
        this.Changed = false;
        this.Index = index;
        this.Scale = scale;
        this.Location = location;
        this.Resolution = new Size(Convert.ToInt32(Decimal.Multiply(new Decimal(resolution.Width), this.Scale)), Convert.ToInt32(Decimal.Multiply(new Decimal(resolution.Height), this.Scale)));
      }

      public Rectangle Bounds() => new Rectangle(this.Location, this.Resolution);

      public override string ToString()
      {
        return string.Format("{0}: Scale={1}, Resolution={2}, Location={3}", (object) this.Index, (object) this.Scale, (object) this.Resolution.ToString(), (object) this.Location.ToString());
      }
    }

    [Serializable]
    public class ScreenChanged
    {
      public string Reference;
      public string Token;
      public DateTime CanSend;
      public int ScreenNumber;
      public Rectangle Bounds;
      public DateTime TimeStamp;
      public byte[] Data;

      public ScreenChanged()
      {
        this.Reference = Guid.NewGuid().ToString();
        this.Token = "";
        this.CanSend = DateTime.MinValue;
        this.ScreenNumber = 0;
        this.Bounds = new Rectangle();
        this.TimeStamp = DateTime.MinValue;
        this.Data = (byte[]) null;
      }

      public ScreenChanged(int screenNumber, Rectangle bounds, byte[] data)
      {
        this.Reference = Guid.NewGuid().ToString();
        this.Token = "";
        this.CanSend = DateTime.MinValue;
        this.ScreenNumber = 0;
        this.Bounds = new Rectangle();
        this.TimeStamp = DateTime.MinValue;
        this.Data = (byte[]) null;
        this.ScreenNumber = screenNumber;
        this.Bounds = bounds;
        this.Data = data;
      }
    }
  }
}
