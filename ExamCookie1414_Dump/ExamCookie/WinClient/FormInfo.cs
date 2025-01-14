// Decompiled with JetBrains decompiler
// Type: ExamCookie.WinClient.FormInfo
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using ExamCookie.Library;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

#nullable disable
namespace ExamCookie.WinClient
{
  [DesignerGenerated]
  public class FormInfo : Form
  {
    private IContainer components;
    private ParameterOut _Config;

    public FormInfo()
    {
      this.Load += new EventHandler(this.FormInfo_Load);
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
      this.PicLogo = new PictureBox();
      this.btnYes = new Button();
      this.btnNo = new Button();
      this.lblInfo2 = new Label();
      this.lblInfo1 = new Label();
      ((ISupportInitialize) this.PicLogo).BeginInit();
      this.SuspendLayout();
      this.PicLogo.Image = (Image) ExamCookie.WinClient.My.Resources.Resources.ec_blue;
      this.PicLogo.Location = new Point(14, 30);
      this.PicLogo.Margin = new Padding(3, 4, 3, 4);
      this.PicLogo.Name = "PicLogo";
      this.PicLogo.Size = new Size(72, 80);
      this.PicLogo.SizeMode = PictureBoxSizeMode.StretchImage;
      this.PicLogo.TabIndex = 0;
      this.PicLogo.TabStop = false;
      this.btnYes.DialogResult = DialogResult.Yes;
      this.btnYes.Font = new Font("Microsoft Sans Serif", 7.8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnYes.Location = new Point(433, 298);
      this.btnYes.Margin = new Padding(3, 4, 3, 4);
      this.btnYes.Name = "btnYes";
      this.btnYes.Size = new Size(394, 52);
      this.btnYes.TabIndex = 2;
      this.btnYes.Text = "JA - Luk og afslut ExamCookie";
      this.btnYes.UseVisualStyleBackColor = true;
      this.btnNo.DialogResult = DialogResult.No;
      this.btnNo.Font = new Font("Microsoft Sans Serif", 7.8f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.btnNo.Location = new Point(14, 298);
      this.btnNo.Margin = new Padding(3, 4, 3, 4);
      this.btnNo.Name = "btnNo";
      this.btnNo.Size = new Size(394, 52);
      this.btnNo.TabIndex = 3;
      this.btnNo.Text = "NEJ - Fortsæt med at bruge ExamCookie";
      this.btnNo.UseVisualStyleBackColor = true;
      this.lblInfo2.Font = new Font("Consolas", 11f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
      this.lblInfo2.ForeColor = Color.DarkSlateGray;
      this.lblInfo2.Location = new Point(107, 70);
      this.lblInfo2.Name = "lblInfo2";
      this.lblInfo2.Size = new Size(567, 194);
      this.lblInfo2.TabIndex = 4;
      this.lblInfo2.Text = "Label1\r\nLabel2\r\nLabel3\r\nLabel31\r\n\r\nLabel4\r\nLabel5";
      this.lblInfo2.TextAlign = ContentAlignment.MiddleLeft;
      this.lblInfo1.AutoSize = true;
      this.lblInfo1.Font = new Font("Microsoft Sans Serif", 10.2f, FontStyle.Bold, GraphicsUnit.Point, (byte) 0);
      this.lblInfo1.Location = new Point(107, 30);
      this.lblInfo1.Name = "lblInfo1";
      this.lblInfo1.Size = new Size(83, 25);
      this.lblInfo1.TabIndex = 5;
      this.lblInfo1.Text = "Label1";
      this.AcceptButton = (IButtonControl) this.btnNo;
      this.AutoScaleDimensions = new SizeF(9f, 20f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ClientSize = new Size(840, 365);
      this.Controls.Add((Control) this.lblInfo1);
      this.Controls.Add((Control) this.lblInfo2);
      this.Controls.Add((Control) this.btnNo);
      this.Controls.Add((Control) this.btnYes);
      this.Controls.Add((Control) this.PicLogo);
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Margin = new Padding(3, 4, 3, 4);
      this.Name = nameof (FormInfo);
      this.ShowIcon = false;
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = "Fortsæt eller Afslut eksamen";
      ((ISupportInitialize) this.PicLogo).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    [field: AccessedThroughProperty("PicLogo")]
    internal virtual PictureBox PicLogo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("btnYes")]
    internal virtual Button btnYes { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("btnNo")]
    internal virtual Button btnNo { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("lblInfo2")]
    internal virtual Label lblInfo2 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    [field: AccessedThroughProperty("lblInfo1")]
    internal virtual Label lblInfo1 { get; [MethodImpl(MethodImplOptions.Synchronized)] set; }

    public ParameterOut Config
    {
      get => this._Config;
      set => this._Config = value;
    }

    private void FormInfo_Load(object sender, EventArgs e)
    {
      StringBuilder stringBuilder = new StringBuilder();
      this.lblInfo1.Text = "Vil du stoppe og afslutte ExamCookie?";
      stringBuilder.AppendFormat("Eksamen: {0}", (object) this.Config.Exam.Description).AppendLine();
      stringBuilder.AppendFormat("Starter: {0}", (object) Strings.Format((object) this.Config.Exam.TimeBegin, "dd-MM-yyyy HH:mm")).AppendLine();
      stringBuilder.AppendFormat("Slutter: {0}", (object) Module1.FormatExamEndTime(this.Config.Exam.TimeEnd, this.Config.Exam.TimeEndExt, "dd-MM-yyyy HH:mm")).AppendLine();
      stringBuilder.AppendFormat("Ekstra elev tid: {0} minutter.", (object) this.Config.Exam.StudentTimeExt).AppendLine();
      stringBuilder.AppendLine();
      stringBuilder.AppendFormat("Elev: {0}", (object) this.Config.Student.Name).AppendLine();
      stringBuilder.AppendFormat("Klasse: {0}", (object) this.Config.Student.Classname).AppendLine();
      this.lblInfo2.Text = stringBuilder.ToString();
      this.btnNo.Select();
    }
  }
}
