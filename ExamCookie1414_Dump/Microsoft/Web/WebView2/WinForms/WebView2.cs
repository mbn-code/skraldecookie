// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.WinForms.WebView2
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using Microsoft.Web.WebView2.Core;
using NativeWifi;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

#nullable disable
namespace Microsoft.Web.WebView2.WinForms
{
  [ComVisible(true)]
  public class WebView2 : Control, ISupportInitialize
  {
    private const string _designText = "WebView2";
    private const int _designBorderWidth = 2;
    private CoreWebView2CreationProperties _creationProperties;
    internal Task _initTask;
    private bool _browserHitTransparent;
    private bool _isExplicitEnvironment;
    private bool _isExplicitControllerOptions;
    private CoreWebView2MoveFocusReason _lastMoveFocusReason;
    private Form _parentForm;
    private CoreWebView2Controller _coreWebView2Controller;
    private double _zoomFactor = 1.0;
    private bool _allowExternalDrop = true;
    private bool _inInit;
    private Uri _source;
    private Color _defaultBackgroundColor = Color.White;
    private bool _browserCrashed;
    private IContainer components;

    [ToolboxItem(true)]
    public WebView2()
    {
      this.InitializeComponent();
      this.SetStyle(ControlStyles.UserPaint, true);
      this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
    }

    protected override void Dispose(bool disposing)
    {
      if (!disposing || this.IsDisposed)
        return;
      if (this.IsInitialized)
        this.UnsubscribeHandlersAndCloseController();
      if (this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void UnsubscribeHandlersAndCloseController(bool browserCrashed = false)
    {
      this.IsInitialized = false;
      this._browserCrashed = browserCrashed;
      this.HandleDestroyed -= new EventHandler(this.WebView2_HandleDestroyed);
      this.HandleCreated -= new EventHandler(this.WebView2_HandleCreated);
      if (this._parentForm != null)
        this._parentForm.LocationChanged -= new EventHandler(this.WebView2_WindowPositionChanged);
      if (!this._browserCrashed)
      {
        this.CoreWebView2.NavigationCompleted -= new EventHandler<CoreWebView2NavigationCompletedEventArgs>(this.CoreWebView2_NavigationCompleted);
        this.CoreWebView2.NavigationStarting -= new EventHandler<CoreWebView2NavigationStartingEventArgs>(this.CoreWebView2_NavigationStarting);
        this.CoreWebView2.SourceChanged -= new EventHandler<CoreWebView2SourceChangedEventArgs>(this.CoreWebView2_SourceChanged);
        this.CoreWebView2.WebMessageReceived -= new EventHandler<CoreWebView2WebMessageReceivedEventArgs>(this.CoreWebView2_WebMessageReceived);
        this.CoreWebView2.ContentLoading -= new EventHandler<CoreWebView2ContentLoadingEventArgs>(this.CoreWebView2_ContentLoading);
        this.CoreWebView2.ProcessFailed -= new EventHandler<CoreWebView2ProcessFailedEventArgs>(this.CoreWebView2_ProcessFailed);
        try
        {
          this.RegisterProfileDeletedEvent(false);
        }
        catch (Exception ex)
        {
        }
        this._coreWebView2Controller.ZoomFactorChanged -= new EventHandler<object>(this._coreWebView2Controller_ZoomFactorChanged);
        this._coreWebView2Controller.MoveFocusRequested -= new EventHandler<CoreWebView2MoveFocusRequestedEventArgs>(this.CoreWebView2Controller_MoveFocusRequested);
        if (!this._browserHitTransparent)
          this._coreWebView2Controller.AcceleratorKeyPressed -= new EventHandler<CoreWebView2AcceleratorKeyPressedEventArgs>(this._coreWebView2Controller_AcceleratorKeyPressed);
        else
          this._coreWebView2Controller.KeyPressed -= new EventHandler<CoreWebView2PrivateKeyPressedEventArgs>(this._coreWebView2Controller_KeyPressed);
        this._coreWebView2Controller.Close();
      }
      this._coreWebView2Controller = (CoreWebView2Controller) null;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);
      if (!this.IsInDesignMode)
        return;
      e.Graphics.FillRectangle((Brush) new SolidBrush(this.BackColor), this.ClientRectangle);
      e.Graphics.DrawRectangle(new Pen((Brush) new SolidBrush(this.ForeColor), 2f), this.ClientRectangle);
      SizeF sizeF = e.Graphics.MeasureString(nameof (WebView2), this.Font);
      if (this.BackgroundImage != null)
        e.Graphics.DrawImage(this.BackgroundImage, new Rectangle(Point.Empty, this.ClientSize));
      e.Graphics.DrawString(nameof (WebView2), this.Font, (Brush) new SolidBrush(this.ForeColor), (float) (this.ClientSize.Width / 2) - sizeF.Width / 2f, (float) (this.ClientSize.Height / 2) - sizeF.Height / 2f);
    }

    protected override void WndProc(ref Message m)
    {
      if (m.Msg == 15 && !this.IsInDesignMode)
      {
        Microsoft.Web.WebView2.WinForms.WebView2.NativeMethods.PaintStruct lpPaint;
        Microsoft.Web.WebView2.WinForms.WebView2.NativeMethods.BeginPaint(m.HWnd, out lpPaint);
        Microsoft.Web.WebView2.WinForms.WebView2.NativeMethods.EndPaint(m.HWnd, ref lpPaint);
        m.Result = IntPtr.Zero;
      }
      else
        base.WndProc(ref m);
    }

    [Browsable(false)]
    public CoreWebView2CreationProperties CreationProperties
    {
      get => this._creationProperties;
      set
      {
        if (this._initTask != null)
          throw new InvalidOperationException("CreationProperties cannot be modified after the initialization of CoreWebView2 has begun.");
        this._creationProperties = value;
      }
    }

    private CoreWebView2Environment Environment { get; set; }

    private CoreWebView2ControllerOptions ControllerOptions { get; set; }

    public Task EnsureCoreWebView2Async(
      CoreWebView2Environment environment = null,
      CoreWebView2ControllerOptions controllerOptions = null)
    {
      if (this.IsInDesignMode)
        return (Task) Task.FromResult<int>(0);
      this.VerifyNotClosedGuard();
      this.VerifyBrowserNotCrashedGuard();
      if (this.InvokeRequired)
        throw new InvalidOperationException("The method EnsureCoreWebView2Async can be invoked only from the UI thread.");
      if (this._initTask == null || this._initTask.IsFaulted)
      {
        this._initTask = this.InitCoreWebView2Async(environment, controllerOptions);
      }
      else
      {
        if (!this._isExplicitEnvironment && environment != null || this._isExplicitEnvironment && environment != null && this.Environment != environment)
          throw new ArgumentException("WebView2 was already initialized with a different CoreWebView2Environment. Check to see if the Source property was already set or EnsureCoreWebView2Async was previously called with different values.");
        if (!this._isExplicitControllerOptions && controllerOptions != null || this._isExplicitControllerOptions && controllerOptions != null && this.ControllerOptions != controllerOptions)
          throw new ArgumentException("WebView2 was already initialized with a different CoreWebView2ControllerOptions. Check to see if the Source property was already set or EnsureCoreWebView2Async was previously called with different values.");
      }
      return this._initTask;
    }

    public Task EnsureCoreWebView2Async(CoreWebView2Environment environment)
    {
      return this.EnsureCoreWebView2Async(environment, (CoreWebView2ControllerOptions) null);
    }

    private void RegisterProfileDeletedEvent(bool register)
    {
      if (register)
        ((WlanClient.WlanInterface.WlanReasonNotificationEventHandler) this.CoreWebView2.Profile).add_Deleted(new EventHandler<object>(this.Profile_Deleted));
      else
        ((WlanClient.WlanInterface.WlanReasonNotificationEventHandler) this.CoreWebView2.Profile).remove_Deleted(new EventHandler<object>(this.Profile_Deleted));
    }

    private async Task InitCoreWebView2Async(
      CoreWebView2Environment environment = null,
      CoreWebView2ControllerOptions controllerOptions = null)
    {
      Microsoft.Web.WebView2.WinForms.WebView2 sender = this;
      try
      {
        if (environment != null)
        {
          sender.Environment = environment;
          sender._isExplicitEnvironment = true;
        }
        else if (sender.CreationProperties != null)
        {
          CoreWebView2Environment environmentAsync = await sender.CreationProperties.CreateEnvironmentAsync();
          sender.Environment = environmentAsync;
        }
        if (sender.Environment == null)
        {
          CoreWebView2Environment async = await CoreWebView2Environment.CreateAsync();
          sender.Environment = async;
        }
        if (controllerOptions != null)
        {
          sender.ControllerOptions = controllerOptions;
          sender._isExplicitControllerOptions = true;
        }
        else if (sender.CreationProperties != null)
          sender.ControllerOptions = sender.CreationProperties.CreateCoreWebView2ControllerOptions(sender.Environment);
        if (sender._defaultBackgroundColor != Color.White)
          System.Environment.SetEnvironmentVariable("WEBVIEW2_DEFAULT_BACKGROUND_COLOR", Color.FromArgb(sender.DefaultBackgroundColor.ToArgb()).Name);
        if (sender.ControllerOptions != null)
        {
          // ISSUE: explicit non-virtual call
          CoreWebView2Controller view2ControllerAsync = await sender.Environment.CreateCoreWebView2ControllerAsync(__nonvirtual (sender.Handle), sender.ControllerOptions);
          sender._coreWebView2Controller = view2ControllerAsync;
        }
        else
        {
          // ISSUE: explicit non-virtual call
          CoreWebView2Controller view2ControllerAsync = await sender.Environment.CreateCoreWebView2ControllerAsync(__nonvirtual (sender.Handle));
          sender._coreWebView2Controller = view2ControllerAsync;
        }
        try
        {
          sender._browserHitTransparent = sender._coreWebView2Controller.IsBrowserHitTransparent;
        }
        catch (NotImplementedException ex)
        {
        }
        sender._coreWebView2Controller.ZoomFactor = sender._zoomFactor;
        sender._coreWebView2Controller.DefaultBackgroundColor = sender._defaultBackgroundColor;
        sender._coreWebView2Controller.Bounds = new Rectangle(0, 0, sender.Width, sender.Height);
        sender._coreWebView2Controller.IsVisible = sender.Visible;
        try
        {
          sender._coreWebView2Controller.AllowExternalDrop = sender._allowExternalDrop;
        }
        catch (NotImplementedException ex)
        {
        }
        sender._coreWebView2Controller.MoveFocusRequested += new EventHandler<CoreWebView2MoveFocusRequestedEventArgs>(sender.CoreWebView2Controller_MoveFocusRequested);
        if (!sender._browserHitTransparent)
          sender._coreWebView2Controller.AcceleratorKeyPressed += new EventHandler<CoreWebView2AcceleratorKeyPressedEventArgs>(sender._coreWebView2Controller_AcceleratorKeyPressed);
        else
          sender._coreWebView2Controller.KeyPressed += new EventHandler<CoreWebView2PrivateKeyPressedEventArgs>(sender._coreWebView2Controller_KeyPressed);
        sender._coreWebView2Controller.ZoomFactorChanged += new EventHandler<object>(sender._coreWebView2Controller_ZoomFactorChanged);
        sender.CoreWebView2.NavigationCompleted += new EventHandler<CoreWebView2NavigationCompletedEventArgs>(sender.CoreWebView2_NavigationCompleted);
        sender.CoreWebView2.NavigationStarting += new EventHandler<CoreWebView2NavigationStartingEventArgs>(sender.CoreWebView2_NavigationStarting);
        sender.CoreWebView2.SourceChanged += new EventHandler<CoreWebView2SourceChangedEventArgs>(sender.CoreWebView2_SourceChanged);
        sender.CoreWebView2.WebMessageReceived += new EventHandler<CoreWebView2WebMessageReceivedEventArgs>(sender.CoreWebView2_WebMessageReceived);
        sender.CoreWebView2.ContentLoading += new EventHandler<CoreWebView2ContentLoadingEventArgs>(sender.CoreWebView2_ContentLoading);
        sender.CoreWebView2.ProcessFailed += new EventHandler<CoreWebView2ProcessFailedEventArgs>(sender.CoreWebView2_ProcessFailed);
        try
        {
          sender.RegisterProfileDeletedEvent(true);
        }
        catch (Exception ex)
        {
        }
        sender.HandleDestroyed += new EventHandler(sender.WebView2_HandleDestroyed);
        sender.HandleCreated += new EventHandler(sender.WebView2_HandleCreated);
        if (sender.Focused)
          sender._coreWebView2Controller.MoveFocus(CoreWebView2MoveFocusReason.Programmatic);
        int num = sender._source != (Uri) null ? 1 : 0;
        if (sender._source == (Uri) null)
          sender._source = new Uri(sender.CoreWebView2.Source);
        sender.IsInitialized = true;
        EventHandler<CoreWebView2InitializationCompletedEventArgs> initializationCompleted = sender.CoreWebView2InitializationCompleted;
        if (initializationCompleted != null)
          initializationCompleted((object) sender, new CoreWebView2InitializationCompletedEventArgs());
        if (num == 0)
          return;
        sender.CoreWebView2.Navigate(sender._source.AbsoluteUri);
      }
      catch (Exception ex)
      {
        EventHandler<CoreWebView2InitializationCompletedEventArgs> initializationCompleted = sender.CoreWebView2InitializationCompleted;
        if (initializationCompleted != null)
          initializationCompleted((object) sender, new CoreWebView2InitializationCompletedEventArgs(ex));
        throw;
      }
    }

    private void Profile_Deleted(object sender, object e)
    {
      this.UnsubscribeHandlersAndCloseController();
    }

    private void WebView2_HandleCreated(object sender, EventArgs e)
    {
      this._coreWebView2Controller.ParentWindow = this.Handle;
      this._coreWebView2Controller.IsVisible = this.Visible;
    }

    private void WebView2_HandleDestroyed(object sender, EventArgs e)
    {
      this._coreWebView2Controller.IsVisible = false;
      this._coreWebView2Controller.ParentWindow = IntPtr.Zero;
    }

    private void WebView2_WindowPositionChanged(object sender, EventArgs e)
    {
      this._coreWebView2Controller?.NotifyParentWindowPositionChanged();
    }

    protected override CreateParams CreateParams
    {
      get
      {
        CreateParams createParams = base.CreateParams;
        createParams.ExStyle |= 32;
        return createParams;
      }
    }

    private void _coreWebView2Controller_KeyPressed(
      object sender,
      CoreWebView2PrivateKeyPressedEventArgs e)
    {
      switch (e.KeyEventKind)
      {
        case CoreWebView2KeyEventKind.KeyDown:
        case CoreWebView2KeyEventKind.SystemKeyDown:
          KeyEventArgs e1 = new KeyEventArgs((Keys) e.VirtualKey);
          this.OnKeyDown(e1);
          e.Handled = e1.Handled;
          break;
        case CoreWebView2KeyEventKind.KeyUp:
        case CoreWebView2KeyEventKind.SystemKeyUp:
          KeyEventArgs e2 = new KeyEventArgs((Keys) e.VirtualKey);
          this.OnKeyUp(e2);
          e.Handled = e2.Handled;
          break;
      }
    }

    private void _coreWebView2Controller_AcceleratorKeyPressed(
      object sender,
      CoreWebView2AcceleratorKeyPressedEventArgs e)
    {
      switch (e.KeyEventKind)
      {
        case CoreWebView2KeyEventKind.KeyDown:
        case CoreWebView2KeyEventKind.SystemKeyDown:
          KeyEventArgs e1 = new KeyEventArgs((Keys) e.VirtualKey);
          this.OnKeyDown(e1);
          e.Handled = e1.Handled;
          break;
        case CoreWebView2KeyEventKind.KeyUp:
        case CoreWebView2KeyEventKind.SystemKeyUp:
          KeyEventArgs e2 = new KeyEventArgs((Keys) e.VirtualKey);
          this.OnKeyUp(e2);
          e.Handled = e2.Handled;
          break;
      }
    }

    private void CoreWebView2Controller_MoveFocusRequested(
      object sender,
      CoreWebView2MoveFocusRequestedEventArgs e)
    {
      bool forward = e.Reason == CoreWebView2MoveFocusReason.Next || e.Reason == CoreWebView2MoveFocusReason.Programmatic;
      Control control = (Control) this.FindForm() ?? this.Parent;
      Control ctl = control.GetNextControl((Control) this, forward) != this.Parent || forward ? (Control) this : this.Parent;
      e.Handled = control == null || control.SelectNextControl(ctl, forward, true, true, true);
      if (this._lastMoveFocusReason == CoreWebView2MoveFocusReason.Programmatic)
        return;
      this._coreWebView2Controller.MoveFocus(this._lastMoveFocusReason);
      this._lastMoveFocusReason = CoreWebView2MoveFocusReason.Programmatic;
    }

    protected override void OnVisibleChanged(EventArgs e)
    {
      base.OnVisibleChanged(e);
      if (!this.IsInitialized || this._browserCrashed)
        return;
      this._coreWebView2Controller.IsVisible = this.Visible;
    }

    protected override void OnSizeChanged(EventArgs e)
    {
      base.OnSizeChanged(e);
      if (!this.IsInitialized || this._browserCrashed)
        return;
      this._coreWebView2Controller.Bounds = new Rectangle(0, 0, this.Width, this.Height);
    }

    protected override void Select(bool directed, bool forward)
    {
      if (directed)
        this._lastMoveFocusReason = forward ? CoreWebView2MoveFocusReason.Next : CoreWebView2MoveFocusReason.Previous;
      base.Select(directed, forward);
    }

    protected override void OnGotFocus(EventArgs e)
    {
      base.OnGotFocus(e);
      if (this.IsInitialized)
      {
        if (!this._browserCrashed)
        {
          try
          {
            this._coreWebView2Controller.MoveFocus(this._lastMoveFocusReason);
          }
          catch (InvalidOperationException ex)
          {
            if (ex.InnerException.HResult != -2147019873)
              throw ex;
          }
        }
      }
      this._lastMoveFocusReason = CoreWebView2MoveFocusReason.Programmatic;
    }

    protected override void OnParentChanged(EventArgs e)
    {
      base.OnParentChanged(e);
      Form form = this.FindForm();
      if (form == null || form == this._parentForm)
        return;
      form.LocationChanged += new EventHandler(this.WebView2_WindowPositionChanged);
      if (this._parentForm != null)
        this._parentForm.LocationChanged -= new EventHandler(this.WebView2_WindowPositionChanged);
      this._parentForm = form;
    }

    private bool IsInitialized { get; set; }

    private bool IsInDesignMode
    {
      get
      {
        ISite sitedParentSite = this.GetSitedParentSite((Control) this);
        return sitedParentSite != null && sitedParentSite.DesignMode;
      }
    }

    private ISite GetSitedParentSite(Control control)
    {
      if (control == null)
        throw new ArgumentNullException(nameof (control));
      return control.Site == null && control.Parent != null ? this.GetSitedParentSite(control.Parent) : control.Site;
    }

    public CoreWebView2 CoreWebView2
    {
      get
      {
        try
        {
          return this._coreWebView2Controller?.CoreWebView2;
        }
        catch (Exception ex)
        {
          if (this.InvokeRequired)
            throw new InvalidOperationException("CoreWebView2 can only be accessed from the UI thread.", ex);
          throw;
        }
      }
    }

    public double ZoomFactor
    {
      get
      {
        return this._coreWebView2Controller != null ? this._coreWebView2Controller.ZoomFactor : this._zoomFactor;
      }
      set
      {
        this._zoomFactor = value;
        if (this._coreWebView2Controller == null)
          return;
        this._coreWebView2Controller.ZoomFactor = value;
      }
    }

    public bool AllowExternalDrop
    {
      get
      {
        return this._coreWebView2Controller != null ? this._coreWebView2Controller.AllowExternalDrop : this._allowExternalDrop;
      }
      set
      {
        this._allowExternalDrop = value;
        if (this._coreWebView2Controller == null)
          return;
        this._coreWebView2Controller.AllowExternalDrop = value;
      }
    }

    void ISupportInitialize.BeginInit() => this._inInit = true;

    void ISupportInitialize.EndInit()
    {
      this._inInit = false;
      if (this._source == (Uri) null)
        return;
      if (!this.IsInitialized)
        this.EnsureCoreWebView2Async();
      else
        this.CoreWebView2.Navigate(this._source.AbsoluteUri);
    }

    [Browsable(true)]
    public Uri Source
    {
      get => this._source;
      set
      {
        if (value == (Uri) null)
        {
          if (!(this._source == (Uri) null))
            throw new NotImplementedException("Setting Source to null is not implemented yet.");
        }
        else
        {
          if (!value.IsAbsoluteUri)
            throw new ArgumentException("Only absolute URI is allowed", nameof (Source));
          if (this.IsInitialized && this._source != (Uri) null && this._source.AbsoluteUri == value.AbsoluteUri)
            return;
          this._source = value;
          if (this._inInit)
            return;
          if (!this.IsInitialized)
            this.EnsureCoreWebView2Async();
          else
            this.CoreWebView2.Navigate(value.AbsoluteUri);
        }
      }
    }

    private bool ShouldSerializeSource()
    {
      return this._source?.AbsoluteUri?.Length.GetValueOrDefault() > 0;
    }

    private void ResetSource() => this._source = (Uri) null;

    [Browsable(false)]
    public bool CanGoForward
    {
      get
      {
        CoreWebView2 coreWebView2 = this.CoreWebView2;
        return coreWebView2 != null && coreWebView2.CanGoForward;
      }
    }

    [Browsable(false)]
    public bool CanGoBack
    {
      get
      {
        CoreWebView2 coreWebView2 = this.CoreWebView2;
        return coreWebView2 != null && coreWebView2.CanGoBack;
      }
    }

    public Color DefaultBackgroundColor
    {
      get
      {
        return this._coreWebView2Controller != null ? this._coreWebView2Controller.DefaultBackgroundColor : this._defaultBackgroundColor;
      }
      set
      {
        if (this._coreWebView2Controller != null)
          this._coreWebView2Controller.DefaultBackgroundColor = value;
        else
          this._defaultBackgroundColor = value;
      }
    }

    public async Task<string> ExecuteScriptAsync(string script)
    {
      this.VerifyInitializedGuard();
      this.VerifyBrowserNotCrashedGuard();
      return await this.CoreWebView2.ExecuteScriptAsync(script);
    }

    public void Reload()
    {
      this.VerifyInitializedGuard();
      this.VerifyBrowserNotCrashedGuard();
      this.CoreWebView2.Reload();
    }

    public void GoForward() => this.CoreWebView2?.GoForward();

    public void GoBack() => this.CoreWebView2?.GoBack();

    public void NavigateToString(string htmlContent)
    {
      this.VerifyInitializedGuard();
      this.VerifyBrowserNotCrashedGuard();
      this.CoreWebView2.NavigateToString(htmlContent);
    }

    public void Stop() => this.CoreWebView2?.Stop();

    private void VerifyInitializedGuard()
    {
      if (!this.IsInitialized)
        throw new InvalidOperationException("The instance of CoreWebView2 is uninitialized and unable to complete this operation. See EnsureCoreWebView2Async.");
    }

    private void VerifyNotClosedGuard()
    {
      if (this.IsDisposed)
        throw new InvalidOperationException("The instance of CoreWebView2 is disposed and unable to complete this operation.");
    }

    private void VerifyBrowserNotCrashedGuard()
    {
      if (this._browserCrashed)
        throw new InvalidOperationException("The instance of CoreWebView2 is no longer valid because the browser process crashed.To work around this, please listen for the ProcessFailed event to explicitly manage the lifetime of the WebView2 control in the event of a browser failure.https://docs.microsoft.com/en-us/dotnet/api/microsoft.web.webview2.core.corewebview2.processfailed");
    }

    public event EventHandler<CoreWebView2InitializationCompletedEventArgs> CoreWebView2InitializationCompleted;

    public event EventHandler<CoreWebView2NavigationStartingEventArgs> NavigationStarting;

    public event EventHandler<CoreWebView2NavigationCompletedEventArgs> NavigationCompleted;

    public event EventHandler<CoreWebView2WebMessageReceivedEventArgs> WebMessageReceived;

    public event EventHandler<CoreWebView2SourceChangedEventArgs> SourceChanged;

    public event EventHandler<CoreWebView2ContentLoadingEventArgs> ContentLoading;

    public event EventHandler<EventArgs> ZoomFactorChanged;

    private void CoreWebView2_NavigationStarting(
      object sender,
      CoreWebView2NavigationStartingEventArgs e)
    {
      EventHandler<CoreWebView2NavigationStartingEventArgs> navigationStarting = this.NavigationStarting;
      if (navigationStarting == null)
        return;
      navigationStarting((object) this, e);
    }

    private void CoreWebView2_NavigationCompleted(
      object sender,
      CoreWebView2NavigationCompletedEventArgs e)
    {
      EventHandler<CoreWebView2NavigationCompletedEventArgs> navigationCompleted = this.NavigationCompleted;
      if (navigationCompleted == null)
        return;
      navigationCompleted((object) this, e);
    }

    private void CoreWebView2_WebMessageReceived(
      object sender,
      CoreWebView2WebMessageReceivedEventArgs e)
    {
      EventHandler<CoreWebView2WebMessageReceivedEventArgs> webMessageReceived = this.WebMessageReceived;
      if (webMessageReceived == null)
        return;
      webMessageReceived((object) this, e);
    }

    private void CoreWebView2_SourceChanged(object sender, CoreWebView2SourceChangedEventArgs e)
    {
      this._source = new Uri(this.CoreWebView2.Source);
      EventHandler<CoreWebView2SourceChangedEventArgs> sourceChanged = this.SourceChanged;
      if (sourceChanged == null)
        return;
      sourceChanged((object) this, e);
    }

    private void CoreWebView2_ContentLoading(object sender, CoreWebView2ContentLoadingEventArgs e)
    {
      EventHandler<CoreWebView2ContentLoadingEventArgs> contentLoading = this.ContentLoading;
      if (contentLoading == null)
        return;
      contentLoading((object) this, e);
    }

    private void CoreWebView2_ProcessFailed(object sender, CoreWebView2ProcessFailedEventArgs e)
    {
      if (e.ProcessFailedKind != CoreWebView2ProcessFailedKind.BrowserProcessExited)
        return;
      this.UnsubscribeHandlersAndCloseController(true);
    }

    private void _coreWebView2Controller_ZoomFactorChanged(object sender, object e)
    {
      this._zoomFactor = this._coreWebView2Controller.ZoomFactor;
      EventHandler<EventArgs> zoomFactorChanged = this.ZoomFactorChanged;
      if (zoomFactorChanged == null)
        return;
      zoomFactorChanged((object) this, EventArgs.Empty);
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new Font Font => base.Font;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new string Text => base.Text;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new bool AllowDrop => base.AllowDrop;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new ContextMenuStrip ContextMenuStrip => base.ContextMenuStrip;

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public new ContextMenu ContextMenu => base.ContextMenu;

    private void InitializeComponent() => this.components = (IContainer) new System.ComponentModel.Container();

    private static class NativeMethods
    {
      [DllImport("user32.dll", SetLastError = true)]
      public static extern IntPtr BeginPaint(
        IntPtr hwnd,
        out Microsoft.Web.WebView2.WinForms.WebView2.NativeMethods.PaintStruct lpPaint);

      [DllImport("user32.dll", SetLastError = true)]
      public static extern bool EndPaint(
        IntPtr hwnd,
        ref Microsoft.Web.WebView2.WinForms.WebView2.NativeMethods.PaintStruct lpPaint);

      [Flags]
      public enum WS_EX : uint
      {
        None = 0,
        TRANSPARENT = 32, // 0x00000020
      }

      public enum WM : uint
      {
        PAINT = 15, // 0x0000000F
      }

      public struct Rect
      {
        public int left;
        public int top;
        public int right;
        public int bottom;
      }

      public struct PaintStruct
      {
        public IntPtr hdc;
        public bool fErase;
        public Microsoft.Web.WebView2.WinForms.WebView2.NativeMethods.Rect rcPaint;
        public bool fRestore;
        public bool fIncUpdate;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] rgbReserved;
      }
    }
  }
}
