// Decompiled with JetBrains decompiler
// Type: ExamCookie.Library.Extensions
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

#nullable disable
namespace ExamCookie.Library
{
  [StandardModule]
  public sealed class Extensions
  {
    public static int ToInt(this string value)
    {
      int num1;
      try
      {
        switch (value)
        {
          case null:
            num1 = 0;
            break;
          case "":
            num1 = 0;
            break;
          default:
            string InputStr = "";
            value = value.Split(',')[0];
            int num2 = checked (value.Length - 1);
            int startIndex = 0;
            while (startIndex <= num2)
            {
              if (Versioned.IsNumeric((object) value.Substring(startIndex, 1)))
                InputStr += value.Substring(startIndex, 1);
              checked { ++startIndex; }
            }
            num1 = checked ((int) Math.Round(Conversion.Val(InputStr)));
            break;
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        num1 = 0;
        ProjectData.ClearProjectError();
      }
      return num1;
    }

    public static string SerializeToXmlString(object obj, bool utf8encoding)
    {
      string xmlString;
      try
      {
        if (utf8encoding)
        {
          XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
          namespaces.Add("", "");
          Extensions.Utf8StringWriter utf8StringWriter = new Extensions.Utf8StringWriter();
          new XmlSerializer(obj.GetType(), "").Serialize((TextWriter) utf8StringWriter, RuntimeHelpers.GetObjectValue(obj), namespaces);
          xmlString = utf8StringWriter.ToString();
        }
        else
        {
          StringWriter stringWriter = new StringWriter();
          new XmlSerializer(obj.GetType()).Serialize((TextWriter) stringWriter, RuntimeHelpers.GetObjectValue(obj));
          xmlString = stringWriter.ToString();
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        xmlString = (string) null;
        ProjectData.ClearProjectError();
      }
      return xmlString;
    }

    public static object DeSerializeFromXmlString(string obj, Type type)
    {
      object obj1;
      try
      {
        if (Operators.CompareString(obj, "", false) == 0)
        {
          obj1 = (object) null;
        }
        else
        {
          using (StringReader stringReader = new StringReader(obj))
            obj1 = new XmlSerializer(type).Deserialize((TextReader) stringReader);
        }
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        obj1 = (object) null;
        ProjectData.ClearProjectError();
      }
      return obj1;
    }

    public static int SerializeToXmlFile(string filename, object obj, bool utf8encoding)
    {
      int xmlFile;
      try
      {
        string xmlString = Extensions.SerializeToXmlString(RuntimeHelpers.GetObjectValue(obj), utf8encoding);
        if (xmlString != null)
        {
          using (StreamWriter streamWriter = new StreamWriter(filename))
          {
            streamWriter.Write(xmlString);
            xmlFile = 0;
          }
        }
        else
          xmlFile = 1;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        xmlFile = -1;
        ProjectData.ClearProjectError();
      }
      return xmlFile;
    }

    public static int DeserializeFromXmlFile(string filename, ref object obj)
    {
      return obj == null ? 1 : Extensions.DeserializeFromXmlFile(filename, obj.GetType(), ref obj);
    }

    public static int DeserializeFromXmlFile(string filename, Type type, ref object obj)
    {
      int num;
      try
      {
        if (File.Exists(filename))
        {
          using (StreamReader streamReader = new StreamReader(filename))
          {
            if (!streamReader.EndOfStream)
            {
              obj = RuntimeHelpers.GetObjectValue(Extensions.DeSerializeFromXmlString(streamReader.ReadToEnd(), type));
              num = obj == null ? 3 : 0;
            }
            else
              num = 2;
          }
        }
        else
          num = 1;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        num = -1;
        ProjectData.ClearProjectError();
      }
      return num;
    }

    public static int SerializeToFile(string filename, object obj)
    {
      int file;
      try
      {
        using (FileStream serializationStream = new FileStream(filename, FileMode.Create))
          new BinaryFormatter().Serialize((Stream) serializationStream, RuntimeHelpers.GetObjectValue(obj));
        file = 0;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        file = -1;
        ProjectData.ClearProjectError();
      }
      return file;
    }

    public static int DeserializeFromFile(string filename, ref object obj)
    {
      int num;
      try
      {
        if (File.Exists(filename))
        {
          using (FileStream serializationStream = new FileStream(filename, FileMode.Open))
          {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            obj = RuntimeHelpers.GetObjectValue(binaryFormatter.Deserialize((Stream) serializationStream));
          }
          num = 0;
        }
        else
          num = 1;
      }
      catch (Exception ex)
      {
        ProjectData.SetProjectError(ex);
        num = -1;
        ProjectData.ClearProjectError();
      }
      return num;
    }

    public static string GetMD5Hash(string value)
    {
      using (MD5 md5 = MD5.Create())
      {
        StringBuilder stringBuilder = new StringBuilder();
        byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(value));
        int index = 0;
        while (index < hash.Length)
        {
          byte num = hash[index];
          stringBuilder.Append(num.ToString("X2"));
          checked { ++index; }
        }
        return stringBuilder.ToString().ToLower();
      }
    }

    public class Utf8StringWriter : StringWriter
    {
      public override Encoding Encoding => Encoding.UTF8;
    }
  }
}
