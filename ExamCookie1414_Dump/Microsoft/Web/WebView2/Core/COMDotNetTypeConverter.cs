// Decompiled with JetBrains decompiler
// Type: Microsoft.Web.WebView2.Core.COMDotNetTypeConverter
// Assembly: ExamCookie.WinClient, Version=1.4.1.4, Culture=neutral, PublicKeyToken=null
// MVID: E12BE1F8-B6E0-4BF5-B308-166F0E938C4B
// Assembly location: C:\Users\oskar\Downloads\ExamCookie1414.WinClient.exe

using Microsoft.Web.WebView2.Core.Raw;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Drawing;
using System.Runtime.InteropServices.ComTypes;

#nullable disable
namespace Microsoft.Web.WebView2.Core
{
  internal static class COMDotNetTypeConverter
  {
    public static Rectangle RectangleCOMToNet(tagRECT rect)
    {
      // ISSUE: reference to a compiler-generated field
      int left = rect.left;
      // ISSUE: reference to a compiler-generated field
      int top = rect.top;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      int num1 = rect.right - rect.left;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      int num2 = rect.bottom - rect.top;
      int y = top;
      int width = num1;
      int height = num2;
      return new Rectangle(left, y, width, height);
    }

    public static tagRECT RectangleNetToCOM(Rectangle dotNetRect)
    {
      // ISSUE: object of a compiler-generated type is created
      return new tagRECT()
      {
        top = dotNetRect.Top,
        left = dotNetRect.Left,
        right = dotNetRect.Right,
        bottom = dotNetRect.Bottom
      };
    }

    public static List<CoreWebView2Cookie> CookieListCOMToNet(ICoreWebView2CookieList rawCookieList)
    {
      List<CoreWebView2Cookie> net = new List<CoreWebView2Cookie>(Convert.ToInt32(rawCookieList.Count));
      for (uint index = 0; index < rawCookieList.Count; ++index)
      {
        // ISSUE: reference to a compiler-generated method
        net.Add(new CoreWebView2Cookie((object) rawCookieList.GetValueAtIndex(index)));
      }
      return net;
    }

    public static IReadOnlyList<CoreWebView2FrameInfo> CoreWebView2FrameInfoCollectionCOMToNet(
      ICoreWebView2FrameInfoCollection rawFrameInfoCollection)
    {
      if (rawFrameInfoCollection == null)
        return (IReadOnlyList<CoreWebView2FrameInfo>) null;
      List<CoreWebView2FrameInfo> list = new List<CoreWebView2FrameInfo>();
      // ISSUE: reference to a compiler-generated method
      // ISSUE: variable of a compiler-generated type
      ICoreWebView2FrameInfoCollectionIterator iterator = rawFrameInfoCollection.GetIterator();
      while (iterator.HasCurrent != 0)
      {
        // ISSUE: reference to a compiler-generated method
        list.Add(new CoreWebView2FrameInfo((object) iterator.GetCurrent()));
        // ISSUE: reference to a compiler-generated method
        iterator.MoveNext();
      }
      return (IReadOnlyList<CoreWebView2FrameInfo>) new ReadOnlyCollection<CoreWebView2FrameInfo>((IList<CoreWebView2FrameInfo>) list);
    }

    public static Color ColorCOMToNet(COREWEBVIEW2_COLOR color)
    {
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      return Color.FromArgb((int) color.A, (int) color.R, (int) color.G, (int) color.B);
    }

    public static COREWEBVIEW2_COLOR ColorNetToCOM(Color dotNetColor)
    {
      // ISSUE: object of a compiler-generated type is created
      return new COREWEBVIEW2_COLOR()
      {
        A = dotNetColor.A,
        R = dotNetColor.R,
        G = dotNetColor.G,
        B = dotNetColor.B
      };
    }

    public static Point PointCOMToNet(tagPOINT point) => new Point(point.x, point.y);

    public static tagPOINT PointNetToCOM(Point dotNetPoint)
    {
      // ISSUE: object of a compiler-generated type is created
      return new tagPOINT()
      {
        x = Convert.ToInt32(dotNetPoint.X),
        y = Convert.ToInt32(dotNetPoint.Y)
      };
    }

    public static IReadOnlyList<CoreWebView2ClientCertificate> CoreWebView2ClientCertificateCollectionCOMToNet(
      ICoreWebView2ClientCertificateCollection rawClientCertificateCollection)
    {
      if (rawClientCertificateCollection == null)
        return (IReadOnlyList<CoreWebView2ClientCertificate>) null;
      List<CoreWebView2ClientCertificate> list = new List<CoreWebView2ClientCertificate>(Convert.ToInt32(rawClientCertificateCollection.Count));
      for (uint index = 0; index < rawClientCertificateCollection.Count; ++index)
      {
        // ISSUE: reference to a compiler-generated method
        list.Add(new CoreWebView2ClientCertificate((object) rawClientCertificateCollection.GetValueAtIndex(index)));
      }
      return (IReadOnlyList<CoreWebView2ClientCertificate>) new ReadOnlyCollection<CoreWebView2ClientCertificate>((IList<CoreWebView2ClientCertificate>) list);
    }

    public static IReadOnlyList<string> CoreWebView2StringCollectionCOMToNet(
      ICoreWebView2StringCollection rawStringCollection)
    {
      if (rawStringCollection == null)
        return (IReadOnlyList<string>) null;
      List<string> list = new List<string>(Convert.ToInt32(rawStringCollection.Count));
      for (uint index = 0; index < rawStringCollection.Count; ++index)
      {
        // ISSUE: reference to a compiler-generated method
        list.Add(rawStringCollection.GetValueAtIndex(index));
      }
      return (IReadOnlyList<string>) new ReadOnlyCollection<string>((IList<string>) list);
    }

    public static IReadOnlyList<object> CoreWebView2ObjectCollectionViewCOMToNet(
      ICoreWebView2ObjectCollectionView rawObjectCollection)
    {
      if (rawObjectCollection == null)
        return (IReadOnlyList<object>) null;
      List<object> list = new List<object>(Convert.ToInt32(rawObjectCollection.Count));
      for (uint index = 0; index < rawObjectCollection.Count; ++index)
      {
        // ISSUE: reference to a compiler-generated method
        object obj = rawObjectCollection.GetValueAtIndex(index);
        if (obj != null)
        {
          if (obj is ICoreWebView2File rawCoreWebView2File)
            obj = (object) new CoreWebView2File((object) rawCoreWebView2File);
          else
            continue;
        }
        list.Add(obj);
      }
      return (IReadOnlyList<object>) new ReadOnlyCollection<object>((IList<object>) list);
    }

    public static IList<CoreWebView2ContextMenuItem> CoreWebView2ContextMenuItemCollectionCOMToNet(
      ICoreWebView2ContextMenuItemCollection rawContextMenuCollection)
    {
      if (rawContextMenuCollection == null)
        return (IList<CoreWebView2ContextMenuItem>) null;
      List<CoreWebView2ContextMenuItem> list = new List<CoreWebView2ContextMenuItem>(Convert.ToInt32(rawContextMenuCollection.Count));
      for (uint index = 0; index < rawContextMenuCollection.Count; ++index)
      {
        // ISSUE: reference to a compiler-generated method
        list.Add(new CoreWebView2ContextMenuItem((object) rawContextMenuCollection.GetValueAtIndex(index)));
      }
      ObservableCollection<CoreWebView2ContextMenuItem> collection = new ObservableCollection<CoreWebView2ContextMenuItem>(list);
      collection.CollectionChanged += (NotifyCollectionChangedEventHandler) ((sender, args) =>
      {
        switch (args.Action)
        {
          case NotifyCollectionChangedAction.Add:
            // ISSUE: reference to a compiler-generated method
            rawContextMenuCollection.InsertValueAtIndex((uint) args.NewStartingIndex, ((CoreWebView2ContextMenuItem) args.NewItems[0])._nativeICoreWebView2ContextMenuItem);
            break;
          case NotifyCollectionChangedAction.Remove:
            // ISSUE: reference to a compiler-generated method
            rawContextMenuCollection.RemoveValueAtIndex((uint) args.OldStartingIndex);
            break;
          case NotifyCollectionChangedAction.Replace:
            // ISSUE: reference to a compiler-generated method
            rawContextMenuCollection.RemoveValueAtIndex((uint) args.OldStartingIndex);
            // ISSUE: reference to a compiler-generated method
            rawContextMenuCollection.InsertValueAtIndex((uint) args.NewStartingIndex, ((CoreWebView2ContextMenuItem) args.NewItems[0])._nativeICoreWebView2ContextMenuItem);
            break;
          case NotifyCollectionChangedAction.Move:
          case NotifyCollectionChangedAction.Reset:
            uint count = rawContextMenuCollection.Count;
            for (uint index = 0; index < count; ++index)
            {
              // ISSUE: reference to a compiler-generated method
              rawContextMenuCollection.RemoveValueAtIndex(0U);
            }
            for (int index = 0; index < collection.Count; ++index)
            {
              // ISSUE: reference to a compiler-generated method
              rawContextMenuCollection.InsertValueAtIndex((uint) index, collection[index]._nativeICoreWebView2ContextMenuItem);
            }
            break;
        }
      });
      return (IList<CoreWebView2ContextMenuItem>) collection;
    }

    public static IReadOnlyList<CoreWebView2ProcessInfo> ProcessInfoCollectionCOMToNet(
      ICoreWebView2ProcessInfoCollection rawCoreWebView2ProcessInfoCollection)
    {
      if (rawCoreWebView2ProcessInfoCollection == null)
        return (IReadOnlyList<CoreWebView2ProcessInfo>) null;
      List<CoreWebView2ProcessInfo> list = new List<CoreWebView2ProcessInfo>(Convert.ToInt32(rawCoreWebView2ProcessInfoCollection.Count));
      for (uint index = 0; index < rawCoreWebView2ProcessInfoCollection.Count; ++index)
      {
        // ISSUE: reference to a compiler-generated method
        list.Add(new CoreWebView2ProcessInfo((object) rawCoreWebView2ProcessInfoCollection.GetValueAtIndex(index)));
      }
      return (IReadOnlyList<CoreWebView2ProcessInfo>) new ReadOnlyCollection<CoreWebView2ProcessInfo>((IList<CoreWebView2ProcessInfo>) list);
    }

    public static COMStreamWrapper StreamCOMToNet(IStream stream)
    {
      return stream == null ? (COMStreamWrapper) null : new COMStreamWrapper(stream);
    }

    public static IReadOnlyList<CoreWebView2PermissionSetting> CoreWebView2PermissionSettingCollectionViewCOMToNet(
      ICoreWebView2PermissionSettingCollectionView rawPermissionSettingCollectionView)
    {
      if (rawPermissionSettingCollectionView == null)
        return (IReadOnlyList<CoreWebView2PermissionSetting>) null;
      List<CoreWebView2PermissionSetting> list = new List<CoreWebView2PermissionSetting>(Convert.ToInt32(rawPermissionSettingCollectionView.Count));
      for (uint index = 0; index < rawPermissionSettingCollectionView.Count; ++index)
      {
        // ISSUE: reference to a compiler-generated method
        list.Add(new CoreWebView2PermissionSetting((object) rawPermissionSettingCollectionView.GetValueAtIndex(index)));
      }
      return (IReadOnlyList<CoreWebView2PermissionSetting>) new ReadOnlyCollection<CoreWebView2PermissionSetting>((IList<CoreWebView2PermissionSetting>) list);
    }
  }
}
