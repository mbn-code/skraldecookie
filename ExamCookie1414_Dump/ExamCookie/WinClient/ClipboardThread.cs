// Decompiled with JetBrains decompiler
// Type: ExamCookie.WinClient.ClipboardThread
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using ExamCookie.Library;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

#nullable disable
namespace ExamCookie.WinClient
{
  public class ClipboardThread
  {
    private int Polltime;
    private IntPtr Handle;
    private Stopwatch Delay1;
    private Stopwatch Delay2;
    private bool _Started;
    private float _ImageScaling;

    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool AddClipboardFormatListener(IntPtr hWnd);

    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool RemoveClipboardFormatListener(IntPtr hWnd);

    [DllImport("user32.dll")]
    private static extern IntPtr GetOpenClipboardWindow();

    [DllImport("user32.dll")]
    private static extern bool OpenClipboard(IntPtr hWndNewOwner);

    [DllImport("user32.dll")]
    private static extern bool EmptyClipboard();

    [DllImport("user32.dll", SetLastError = true)]
    private static extern bool CloseClipboard();

    public event ClipboardThread.OnClipboardChangedEventHandler OnClipboardChanged;

    public event ClipboardThread.OnDebugEventHandler OnDebug;

    public event ClipboardThread.OnExceptionEventHandler OnException;

    public ClipboardThread()
    {
      this.Polltime = 0;
      this.Handle = IntPtr.Zero;
      this.Delay1 = new Stopwatch();
      this.Delay2 = new Stopwatch();
      this._Started = false;
      this._ImageScaling = 0.6f;
    }

    public ClipboardThread(int polltime, IntPtr handle)
    {
      this.Polltime = 0;
      this.Handle = IntPtr.Zero;
      this.Delay1 = new Stopwatch();
      this.Delay2 = new Stopwatch();
      this._Started = false;
      this._ImageScaling = 0.6f;
      if (polltime <= 0)
        return;
      this.Polltime = Conversions.ToInteger(Interaction.IIf(polltime < 500, (object) 500, (object) polltime));
      this.Handle = handle;
      ClipboardThread.OpenClipboard(IntPtr.Zero);
      ClipboardThread.EmptyClipboard();
      ClipboardThread.CloseClipboard();
      ClipboardThread.AddClipboardFormatListener(handle);
      this.Started = true;
      this.Delay1.Start();
      this.Delay2.Start();
    }

    public bool Started
    {
      get => this._Started;
      set
      {
        if (!value)
        {
          this.Delay1.Stop();
          ClipboardThread.RemoveClipboardFormatListener(this.Handle);
        }
        this._Started = value;
      }
    }

    public float ImageScaling
    {
      get => this._ImageScaling;
      set
      {
        if ((double) value < 0.5)
          this._ImageScaling = 0.5f;
        else if ((double) value > 1.0)
          this._ImageScaling = 1f;
        else
          this._ImageScaling = value;
      }
    }

    public void GetClipboardData()
    {
      try
      {
        if (!this.Started | this.Polltime == 0 | this.Delay1.ElapsedMilliseconds < (long) this.Polltime | this.Delay2.ElapsedMilliseconds < 3000L)
          return;
        this.Delay1.Restart();
        this.Delay2.Restart();
        ClipboardThread.ClipboardChanged sender = new ClipboardThread.ClipboardChanged();
        if (System.Windows.Forms.Clipboard.ContainsData(DataFormats.CommaSeparatedValue))
        {
          using (StreamReader streamReader = new StreamReader((Stream) System.Windows.Forms.Clipboard.GetData(DataFormats.CommaSeparatedValue)))
          {
            string end = streamReader?.ReadToEnd();
            sender.Data = Encoding.UTF8.GetBytes(end);
          }
          sender.Format = eDataFormat.CSV;
        }
        else if (System.Windows.Forms.Clipboard.ContainsData(DataFormats.Bitmap))
        {
          using (MemoryStream memoryStream = new MemoryStream())
          {
            ((Image) System.Windows.Forms.Clipboard.GetData(DataFormats.Bitmap)).Save((Stream) memoryStream, ImageFormat.Jpeg);
            sender.Data = memoryStream?.ToArray();
          }
          sender.Format = eDataFormat.IMAGE;
        }
        else if (System.Windows.Forms.Clipboard.ContainsImage())
        {
          using (MemoryStream memoryStream = new MemoryStream())
          {
            System.Windows.Forms.Clipboard.GetImage().Save((Stream) memoryStream, ImageFormat.Jpeg);
            sender.Data = memoryStream?.ToArray();
          }
          sender.Format = eDataFormat.IMAGE;
        }
        else if (System.Windows.Forms.Clipboard.ContainsData(DataFormats.FileDrop))
        {
          List<string> stringList = new List<string>();
          foreach (string fileDrop in System.Windows.Forms.Clipboard.GetFileDropList())
          {
            if (fileDrop != null)
              stringList.Add(fileDrop);
          }
          sender.Data = Encoding.UTF8.GetBytes(Strings.Join(stringList.ToArray(), "\r\n"));
          sender.Format = eDataFormat.FILE_LIST;
        }
        else if (System.Windows.Forms.Clipboard.ContainsFileDropList())
        {
          List<string> stringList = new List<string>();
          foreach (string fileDrop in System.Windows.Forms.Clipboard.GetFileDropList())
          {
            if (fileDrop != null)
              stringList.Add(fileDrop);
          }
          sender.Data = Encoding.UTF8.GetBytes(Strings.Join(stringList.ToArray(), "\r\n"));
          sender.Format = eDataFormat.FILE_LIST;
        }
        else if (System.Windows.Forms.Clipboard.ContainsData(DataFormats.Rtf))
        {
          sender.Data = (byte[]) NewLateBinding.LateGet((object) Encoding.UTF8, (Type) null, "GetBytes", new object[1]
          {
            System.Windows.Forms.Clipboard.GetData(DataFormats.Rtf)
          }, (string[]) null, (Type[]) null, (bool[]) null);
          sender.Format = eDataFormat.RTF;
        }
        else if (System.Windows.Forms.Clipboard.ContainsData(DataFormats.Text))
        {
          sender.Data = Encoding.UTF8.GetBytes(System.Windows.Forms.Clipboard.GetText());
          sender.Format = eDataFormat.TEXT;
        }
        else if (System.Windows.Forms.Clipboard.ContainsText())
        {
          sender.Data = Encoding.UTF8.GetBytes(System.Windows.Forms.Clipboard.GetText());
          sender.Format = eDataFormat.TEXT;
        }
        else if (System.Windows.Forms.Clipboard.ContainsData(DataFormats.Dib))
          Module1.DebugPrint("ContainsData.Dib");
        else if (System.Windows.Forms.Clipboard.ContainsData(DataFormats.Dif))
          Module1.DebugPrint("ContainsData.Dif");
        else if (System.Windows.Forms.Clipboard.ContainsData(DataFormats.EnhancedMetafile))
          Module1.DebugPrint("ContainsData.EnhancedMetafile");
        else if (System.Windows.Forms.Clipboard.ContainsData(DataFormats.Html))
          Module1.DebugPrint("ContainsData.Html");
        else if (System.Windows.Forms.Clipboard.ContainsData(DataFormats.MetafilePict))
          Module1.DebugPrint("ContainsData.MetafilePict");
        else if (System.Windows.Forms.Clipboard.ContainsData(DataFormats.Palette))
          Module1.DebugPrint("ContainsData.Palette");
        else if (System.Windows.Forms.Clipboard.ContainsData(DataFormats.PenData))
          Module1.DebugPrint("ContainsData.PenData");
        else if (System.Windows.Forms.Clipboard.ContainsData(DataFormats.Riff))
          Module1.DebugPrint("ContainsData.Riff");
        else if (System.Windows.Forms.Clipboard.ContainsData(DataFormats.Serializable))
          Module1.DebugPrint("ContainsData.Serializable");
        else if (System.Windows.Forms.Clipboard.ContainsData(DataFormats.StringFormat))
          Module1.DebugPrint("ContainsData.StringFormat");
        else if (System.Windows.Forms.Clipboard.ContainsData(DataFormats.SymbolicLink))
          Module1.DebugPrint("ContainsData.SymbolicLink");
        else if (System.Windows.Forms.Clipboard.ContainsData(DataFormats.Tiff))
          Module1.DebugPrint("ContainsData.Tiff");
        else if (System.Windows.Forms.Clipboard.ContainsData(DataFormats.UnicodeText))
          Module1.DebugPrint("ContainsData.UnicodeText");
        else if (System.Windows.Forms.Clipboard.ContainsData(DataFormats.WaveAudio))
        {
          Module1.DebugPrint("ContainsData.WaveAudio");
        }
        else
        {
          sender.Data = (byte[]) null;
          sender.Format = eDataFormat.NONE;
        }
        // ISSUE: reference to a compiler-generated field
        ClipboardThread.OnDebugEventHandler onDebugEvent = this.OnDebugEvent;
        if (onDebugEvent != null)
          onDebugEvent("CLIPBOARD: " + sender.Format.ToString());
        // ISSUE: reference to a compiler-generated field
        ClipboardThread.OnClipboardChangedEventHandler clipboardChangedEvent = this.OnClipboardChangedEvent;
        if (clipboardChangedEvent != null)
          clipboardChangedEvent(sender);
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        Exception exception = ex;
        Module1.Log(Module1.LogType.ERROR, (object) MethodBase.GetCurrentMethod(), exception.ToString());
        ProjectData.ClearProjectError();
      }
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

    public delegate void OnClipboardChangedEventHandler(ClipboardThread.ClipboardChanged sender);

    public delegate void OnDebugEventHandler(string message);

    public delegate void OnExceptionEventHandler(Exception ex);

    [Serializable]
    public class ClipboardChanged
    {
      public string Reference;
      public string Token;
      public DateTime CanSend;
      public DateTime TimeStamp;
      public eDataFormat Format;
      public byte[] Data;

      public ClipboardChanged()
      {
        this.Reference = Guid.NewGuid().ToString();
        this.Token = "";
        this.CanSend = DateTime.MinValue;
        this.TimeStamp = DateTime.MinValue;
        this.Format = eDataFormat.NONE;
        this.Data = (byte[]) null;
      }

      public ClipboardChanged(eDataFormat format, byte[] data)
      {
        this.Reference = Guid.NewGuid().ToString();
        this.Token = "";
        this.CanSend = DateTime.MinValue;
        this.TimeStamp = DateTime.MinValue;
        this.Format = eDataFormat.NONE;
        this.Data = (byte[]) null;
        this.Format = format;
        this.Data = data;
      }
    }
  }
}
