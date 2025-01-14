// Decompiled with JetBrains decompiler
// Type: ExamCookie.WinClient.FormNotify
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

#nullable disable
namespace ExamCookie.WinClient
{
  [DesignerGenerated]
  public class FormNotify : Form
  {
    private IContainer components;

    public FormNotify()
    {
      this.Load += new EventHandler(this.FormNotify_Load);
      this.InitializeComponent();
    }

    [DebuggerNonUserCode]
    protected override void Dispose(bool disposing)
    {
      try
      {
        if (!disposing || this.components == null)
          return;
        this.components.Dispose();
      }
      finally
      {
        base.Dispose(disposing);
      }
    }

    [DebuggerStepThrough]
    private void InitializeComponent()
    {
      this.components = (IContainer) new System.ComponentModel.Container();
      this.Timer1 = new Timer(this.components);
      this.PictureBox1 = new PictureBox();
      this.lblMessage = new Label();
      this.lblHeader = new Label();
      ((ISupportInitialize) this.PictureBox1).BeginInit();
      this.SuspendLayout();
      this.PictureBox1.Image = (Image) ExamCookie.WinClient.My.Resources.Resources.ec_blue;
      this.PictureBox1.Location = new Point(0, 0);
      this.PictureBox1.Margin = new Padding(3, 4, 3, 4);
      this.PictureBox1.Name = "PictureBox1";
      this.PictureBox1.Size = new Size(52, 59);
      this.PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
      this.PictureBox1.TabIndex = 0;
      this.PictureBox1.TabStop = false;
      this.lblMessage.AutoSize = true;
      this.lblMessage.BackColor = Color.Transparent;
      this.lblMessage.Font = new Font("Calibri", 11f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblMessage.ForeColor = Color.LightGray;
      this.lblMessage.Location = new Point(63, 52);
      this.lblMessage.Name = "lblLine1";
      this.lblMessage.Size = new Size(60, 81);
      this.lblMessage.TabIndex = 1;
      this.lblMessage.Text = "Line1\r\nLine2\r\nLine3";
      this.lblHeader.AutoSize = true;
      this.lblHeader.BackColor = Color.Transparent;
      this.lblHeader.Font = new Font("Calibri", 13.8f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblHeader.ForeColor = Color.White;
      this.lblHeader.Location = new Point(62, 6);
      this.lblHeader.Name = "lblHeader";
      this.lblHeader.Size = new Size(98, 35);
      this.lblHeader.TabIndex = 2;
      this.lblHeader.Text = "Header";
      this.AutoScaleDimensions = new SizeF(9f, 20f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.FromArgb((int) byte.MaxValue, 35, 35, 35);
      this.ClientSize = new Size(530, 140);
      this.Controls.Add((Control) this.lblHeader);
      this.Controls.Add((Control) this.lblMessage);
      this.Controls.Add((Control) this.PictureBox1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.Margin = new Padding(3, 4, 3, 4);
      this.Name = nameof (FormNotify);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.Text = "ExamCookie";
      ((ISupportInitialize) this.PictureBox1).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    internal virtual Timer Timer1
    {
      get => this._Timer1;
      [MethodImpl(MethodImplOptions.Synchronized)] set
      {
        EventHandler eventHandler = new EventHandler(this.Timer1_Tick);
        Timer timer1_1 = this._Timer1;
        if (timer1_1 != null)
          timer1_1.Tick -= eventHandler;
        this._Timer1 = value;
        Timer timer1_2 = this._Timer1;
        if (timer1_2 == null)
          return;
        timer1_2.Tick += eventHandler;
      }
    }

    [field: AccessedThroughProperty("PictureBox1")]
    internal virtual PictureBox PictureBox1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("lblMessage")]
    internal virtual Label lblMessage { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("lblHeader")]
    internal virtual Label lblHeader { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public void Notify(string header, string[] message, int timeout)
    {
      if (message == null)
      {
        this.Close();
      }
      else
      {
        this.lblHeader.Text = header;
        this.lblMessage.Text = Strings.Join(message, "\r\n");
        this.Timer1.Interval = timeout;
      }
    }

    private void FormNotify_Load(object sender, EventArgs e)
    {
      this.ShowInTaskbar = false;
      this.CustomNotify();
    }

    private void CustomNotify()
    {
      this.BackColor = Color.FromArgb((int) byte.MaxValue, 35, 35, 35);
      this.Location = new Point(checked (Screen.PrimaryScreen.WorkingArea.Width - this.Width), checked (Screen.PrimaryScreen.WorkingArea.Height - 100));
      this.TopMost = true;
      this.Refresh();
      this.Timer1.Start();
    }

    private void ToastNotify()
    {
    }

    private void Timer1_Tick(object sender, EventArgs e)
    {
      this.Timer1.Stop();
      this.Close();
    }
  }
}
