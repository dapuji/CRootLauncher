using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CRootLauncher.ApplicationIcons
{
    [StructLayout(LayoutKind.Sequential,CharSet = CharSet.Auto)]
    struct SHFILEINFO
    {
        public IntPtr hIcon;
        public int iIcon;
        public uint dwAttributes;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
        public string szDisplayName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
        public string szTypeName;
    }

    class APIs
    {
        [DllImport("Shell32.dll", EntryPoint = "SHGetFileInfo", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cdFileInfo, uint uFlags);

        [DllImport("User32.dll", EntryPoint = "DestroyIcon")]
        public static extern int DestroyIcon(IntPtr hIcon);
    }

    public enum FileInfoFlags : uint
    {
        SHGFI_ICON = 0x000000100, // get icon
        SHGFI_DISPLAYNAME = 0x000000200, // get display name
        SHGFI_TYPENAME = 0x000000400, // get type name
        SHGFI_ATTRIBUTES = 0x000000800, // get attributes
        SHGFI_ICONLOCATION = 0x000001000, // get icon location
        SHGFI_EXETYPE = 0x000002000, // return exe type
        SHGFI_SYSICONINDEX = 0x000004000, // get system icon index
        SHGFI_LINKOVERLAY = 0x000008000, // put a link overlay on icon
        SHGFI_SELECTED = 0x000010000, // show icon in selected state
        SHGFI_ATTR_SPECIFIED = 0x000020000, // get only specified attributes
        SHGFI_LARGEICON = 0x000000000, // get large icon
        SHGFI_SMALLICON = 0x000000001, // get small icon
        SHGFI_OPENICON = 0x000000002, // get open icon
        SHGFI_SHELLICONSIZE = 0x000000004, // get shell size icon
        SHGFI_PIDL = 0x000000008, // pszPath is a pidl
        SHGFI_USEFILEATTRIBUTES = 0x000000010, // use passed dwFileAttribute
        SHGFI_ADDOVERLAYS = 0x000000020, // apply the appropriate overlays
        SHGFI_OVERLAYINDEX = 0x000000040 // Get the index of the overlay
    }

    public static class IconHelper
    {
        /// <summary>
        /// 获取文件类型的关联图标
        /// </summary>
        /// <param name="fileName">文件类型的扩展名或文件的绝对路径</param>
        /// <param name="isLargeIcon">是否返回大图标</param>
        /// <returns>获取到的图标</returns>
        public static Icon GetIcon(string fileName, bool isLargeIcon)
        {
            SHFILEINFO shfi = new SHFILEINFO();
            IntPtr hI;
            if (isLargeIcon)
                hI = APIs.SHGetFileInfo(fileName, 0, ref shfi, (uint)Marshal.SizeOf(shfi), (uint)FileInfoFlags.SHGFI_ICON | (uint)FileInfoFlags.SHGFI_USEFILEATTRIBUTES | (uint)FileInfoFlags.SHGFI_LARGEICON);
            else
                hI = APIs.SHGetFileInfo(fileName, 0, ref shfi, (uint)Marshal.SizeOf(shfi), (uint)FileInfoFlags.SHGFI_ICON | (uint)FileInfoFlags.SHGFI_USEFILEATTRIBUTES | (uint)FileInfoFlags.SHGFI_SMALLICON);
            Icon icon = Icon.FromHandle(shfi.hIcon).Clone() as Icon;
            APIs.DestroyIcon(shfi.hIcon); //释放资源
            return icon;
        }
        /// <summary> 
        /// 获取文件夹图标
        /// </summary> 
        /// <returns>图标</returns> 
        public static Icon GetDirectoryIcon(bool isLargeIcon)
        {
            SHFILEINFO _SHFILEINFO = new SHFILEINFO();
            IntPtr _IconIntPtr;
            if (isLargeIcon)
            {
                _IconIntPtr = APIs.SHGetFileInfo(@"", 0, ref _SHFILEINFO, (uint)Marshal.SizeOf(_SHFILEINFO), ((uint)FileInfoFlags.SHGFI_ICON | (uint)FileInfoFlags.SHGFI_LARGEICON));
            }
            else
            {
                _IconIntPtr = APIs.SHGetFileInfo(@"", 0, ref _SHFILEINFO, (uint)Marshal.SizeOf(_SHFILEINFO), ((uint)FileInfoFlags.SHGFI_ICON | (uint)FileInfoFlags.SHGFI_SMALLICON));
            }
            if (_IconIntPtr.Equals(IntPtr.Zero)) return null;
            Icon _Icon = System.Drawing.Icon.FromHandle(_SHFILEINFO.hIcon);
            return _Icon;
        }
    }
}
