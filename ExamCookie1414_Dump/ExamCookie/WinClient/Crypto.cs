// Decompiled with JetBrains decompiler
// Type: ExamCookie.WinClient.Crypto
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

#nullable disable
namespace ExamCookie.WinClient
{
  public class Crypto
  {
    private static TripleDESCryptoServiceProvider DES = new TripleDESCryptoServiceProvider();
    private static MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();

    public static byte[] MD5Hash(string value)
    {
      return Crypto.MD5.ComputeHash(Encoding.ASCII.GetBytes(value));
    }

    public static string Encrypt(string stringToEncrypt, string key)
    {
      string str;
      try
      {
        Crypto.DES.Key = Crypto.MD5Hash(key);
        Crypto.DES.Mode = CipherMode.ECB;
        byte[] bytes = Encoding.ASCII.GetBytes(stringToEncrypt);
        str = Convert.ToBase64String(Crypto.DES.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) MessageBox.Show("Invalid Key", "Decryption Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        str = (string) null;
        ProjectData.ClearProjectError();
      }
      return str;
    }

    public static string Decrypt(string encryptedString, string key)
    {
      string str;
      try
      {
        Crypto.DES.Key = Crypto.MD5Hash(key);
        Crypto.DES.Mode = CipherMode.ECB;
        byte[] inputBuffer = Convert.FromBase64String(encryptedString);
        str = Encoding.ASCII.GetString(Crypto.DES.CreateDecryptor().TransformFinalBlock(inputBuffer, 0, inputBuffer.Length));
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        int num = (int) MessageBox.Show("Invalid Key", "Decryption Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        str = (string) null;
        ProjectData.ClearProjectError();
      }
      return str;
    }
  }
}
