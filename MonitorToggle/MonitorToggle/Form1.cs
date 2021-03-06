﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices; //to DllImport


namespace MonitorToggle
{
    [Flags()]
    public enum DisplayDeviceStateFlags : int
    {
        /// <summary>The device is part of the desktop.</summary>
        AttachedToDesktop = 0x1,
        MultiDriver = 0x2,
        /// <summary>The device is part of the desktop.</summary>
        PrimaryDevice = 0x4,
        /// <summary>Represents a pseudo device used to mirror application drawing for remoting or other purposes.</summary>
        MirroringDriver = 0x8,
        /// <summary>The device is VGA compatible.</summary>
        VGACompatible = 0x10,
        /// <summary>The device is removable; it cannot be the primary display.</summary>
        Removable = 0x20,
        /// <summary>The device has more display modes than its output devices support.</summary>
        ModesPruned = 0x8000000,
        Remote = 0x4000000,
        Disconnect = 0x2000000
    }

    //[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    //public struct DISPLAY_DEVICE
    //{
    //    [MarshalAs(UnmanagedType.U4)]
    //    public int cb;
    //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
    //    public string DeviceName;
    //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    //    public string DeviceString;
    //    [MarshalAs(UnmanagedType.U4)]
    //    public DisplayDeviceStateFlags StateFlags;
    //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    //    public string DeviceID;
    //    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    //    public string DeviceKey;
    //}
    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi)]
    public struct DEVMODE
    {
        public const int CCHDEVICENAME = 32;
        public const int CCHFORMNAME = 32;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHDEVICENAME)]
        [System.Runtime.InteropServices.FieldOffset(0)]
        public string dmDeviceName;
        [System.Runtime.InteropServices.FieldOffset(32)]
        public Int16 dmSpecVersion;
        [System.Runtime.InteropServices.FieldOffset(34)]
        public Int16 dmDriverVersion;
        [System.Runtime.InteropServices.FieldOffset(36)]
        public Int16 dmSize;
        [System.Runtime.InteropServices.FieldOffset(38)]
        public Int16 dmDriverExtra;
        [System.Runtime.InteropServices.FieldOffset(40)]
        public DM dmFields;
        [System.Runtime.InteropServices.FieldOffset(44)]
        Int16 dmOrientation;
        [System.Runtime.InteropServices.FieldOffset(46)]
        Int16 dmPaperSize;
        [System.Runtime.InteropServices.FieldOffset(48)]
        Int16 dmPaperLength;
        [System.Runtime.InteropServices.FieldOffset(50)]
        Int16 dmPaperWidth;
        [System.Runtime.InteropServices.FieldOffset(52)]
        Int16 dmScale;
        [System.Runtime.InteropServices.FieldOffset(54)]
        Int16 dmCopies;
        [System.Runtime.InteropServices.FieldOffset(56)]
        Int16 dmDefaultSource;
        [System.Runtime.InteropServices.FieldOffset(58)]
        Int16 dmPrintQuality;

        [System.Runtime.InteropServices.FieldOffset(44)]
        public POINTL dmPosition;
        [System.Runtime.InteropServices.FieldOffset(52)]
        public Int32 dmDisplayOrientation;
        [System.Runtime.InteropServices.FieldOffset(56)]
        public Int32 dmDisplayFixedOutput;

        [System.Runtime.InteropServices.FieldOffset(60)]
        public short dmColor;
        [System.Runtime.InteropServices.FieldOffset(62)]
        public short dmDuplex;
        [System.Runtime.InteropServices.FieldOffset(64)]
        public short dmYResolution;
        [System.Runtime.InteropServices.FieldOffset(66)]
        public short dmTTOption;
        [System.Runtime.InteropServices.FieldOffset(68)]
        public short dmCollate;
        [System.Runtime.InteropServices.FieldOffset(72)]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHFORMNAME)]
        public string dmFormName;
        [System.Runtime.InteropServices.FieldOffset(102)]
        public Int16 dmLogPixels;
        [System.Runtime.InteropServices.FieldOffset(104)]
        public Int32 dmBitsPerPel;
        [System.Runtime.InteropServices.FieldOffset(108)]
        public Int32 dmPelsWidth;
        [System.Runtime.InteropServices.FieldOffset(112)]
        public Int32 dmPelsHeight;
        [System.Runtime.InteropServices.FieldOffset(116)]
        public Int32 dmDisplayFlags;
        [System.Runtime.InteropServices.FieldOffset(116)]
        public Int32 dmNup;
        [System.Runtime.InteropServices.FieldOffset(120)]
        public Int32 dmDisplayFrequency;

    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct DISPLAY_DEVICE
    {
        [MarshalAs(UnmanagedType.U4)]
        public int cb;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string DeviceName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string DeviceString;
        [MarshalAs(UnmanagedType.U4)]
        public DisplayDeviceStateFlags StateFlags;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string DeviceID;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string DeviceKey;
    }

    //[Flags()]
    //public enum DisplayDeviceStateFlags : int
    //{
    //    AttachedToDesktop = 0x1,
    //    MultiDriver = 0x2,
    //    PrimaryDevice = 0x4,
    //    MirroringDriver = 0x8,
    //    VGACompatible = 0x16,
    //    Removable = 0x20,
    //    ModesPruned = 0x8000000,
    //    Remote = 0x4000000,
    //    Disconnect = 0x2000000
    //}

    [Flags()]
    public enum DM : int
    {
        Orientation = 0x1,
        PaperSize = 0x2,
        PaperLength = 0x4,
        PaperWidth = 0x8,
        Scale = 0x10,
        Position = 0x20,
        NUP = 0x40,
        DisplayOrientation = 0x80,
        Copies = 0x100,
        DefaultSource = 0x200,
        PrintQuality = 0x400,
        Color = 0x800,
        Duplex = 0x1000,
        YResolution = 0x2000,
        TTOption = 0x4000,
        Collate = 0x8000,
        FormName = 0x10000,
        LogPixels = 0x20000,
        BitsPerPixel = 0x40000,
        PelsWidth = 0x80000,
        PelsHeight = 0x100000,
        DisplayFlags = 0x200000,
        DisplayFrequency = 0x400000,
        ICMMethod = 0x800000,
        ICMIntent = 0x1000000,
        MediaType = 0x2000000,
        DitherType = 0x4000000,
        PanningWidth = 0x8000000,
        PanningHeight = 0x10000000,
        DisplayFixedOutput = 0x20000000
    }

    public enum DISP_CHANGE : int
    {
        Successful = 0,
        Restart = 1,
        Failed = -1,
        BadMode = -2,
        NotUpdated = -3,
        BadFlags = -4,
        BadParam = -5,
        BadDualView = -1
    }

    public  struct POINTL
    {
        public long x;
        public long y;
    }

    public enum CDSFlags
    {
        CDS_RESET = 0x40000000,
        CDS_UPDATEREGISTRY = 0x00000001,
        CDS_SET_PRIMARY = 0x00000010
    };

    public partial class Form1 : Form
    {


        DEVMODE ddActive = new DEVMODE();
        DEVMODE ddInactive = new DEVMODE();
        string szActiveDeviceName = string.Empty;
        string szInactiveDeviceName = string.Empty;
        const int ENUM_REGISTRY_SETTINGS = -2;  

        public int WM_SYSCOMMAND = 0x0112;
public int SC_MONITORPOWER = 0xF170; //Using the system pre-defined MSDN constants that can be used by the SendMessage() function .

        [DllImport("user32.dll")]
private static extern int SendMessage(int hWnd, int hMsg, int wParam, int lParam);
//To call a DLL function from C#, you must provide this declaration .

        
        [DllImport("user32.dll")]
        static extern bool EnumDisplayDevices(string lpDevice,
               uint iDevNum, ref DISPLAY_DEVICE lpDisplayDevice, uint dwFlags);

        [DllImport("user32.dll")]
        public static extern bool EnumDisplaySettings(string deviceName,
               int modeNum, ref DEVMODE devMode);

        [DllImport("user32.dll")]
        static extern DISP_CHANGE ChangeDisplaySettingsEx(string lpszDeviceName,
               ref DEVMODE lpDevMode, IntPtr hwnd, uint dwflags, IntPtr lParam);


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // SendMessage( this.Handle.ToInt32() , WM_SYSCOMMAND , SC_MONITORPOWER ,2 );//DLL function //go to powersave.

            DISPLAY_DEVICE d = new DISPLAY_DEVICE();
            d.cb = Marshal.SizeOf(d);
            try
            {
                for (uint id = 0; EnumDisplayDevices(null, id, ref d, 0); id++)
                {
                    MessageBox.Show(
                        String.Format("{0}, {1}, {2}, {3}, {4}, {5}",
                                 id,
                                 d.DeviceName,
                                 d.DeviceString,
                                 d.StateFlags,
                                 d.DeviceID,
                                 d.DeviceKey
                                 )
                                  );
                    d.cb = Marshal.SizeOf(d);
               
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("{0}", ex.ToString()));
            }
            GetDisplayInfo();
            ddInactive.dmPosition.x = 0;
            ddInactive.dmPosition.y = 0;
            ddInactive.dmFields = DM.Position;
            if (DISP_CHANGE.Successful == ChangeDisplaySettingsEx(szInactiveDeviceName,
                ref ddInactive, IntPtr.Zero,
                (int)(CDSFlags.CDS_RESET | CDSFlags.CDS_UPDATEREGISTRY |
                 CDSFlags.CDS_SET_PRIMARY), IntPtr.Zero))
            {
                ddActive.dmPosition.x = 0;
                ddActive.dmPosition.y = 0;
                ddActive.dmPelsHeight = 0;
                ddActive.dmPelsWidth = 0;
                ddActive.dmFields = DM.PelsHeight | DM.PelsWidth | DM.Position;

                ChangeDisplaySettingsEx(szActiveDeviceName, ref ddActive,
                  IntPtr.Zero, (int)(CDSFlags.CDS_RESET |
                  CDSFlags.CDS_UPDATEREGISTRY), IntPtr.Zero);
            }
        }


        public void GetDisplayInfo()
        {
            ddActive.dmSize = (short)Marshal.SizeOf(ddActive);
            ddInactive.dmSize = (short)Marshal.SizeOf(ddInactive);
            uint iDeviceCntr = 0;
            DISPLAY_DEVICE dd = new DISPLAY_DEVICE();
            dd.cb = Marshal.SizeOf(dd);
            while (EnumDisplayDevices(null, iDeviceCntr, ref dd, 0))
            {
                DEVMODE dMode = new DEVMODE();
                dMode.dmSize = (short)Marshal.SizeOf(dMode);
                if (EnumDisplaySettings(dd.DeviceName, ENUM_REGISTRY_SETTINGS, ref dMode))
                {
                    if (dMode.dmPelsHeight > 0 && dMode.dmPelsWidth > 0)
                    {
                        if ((dd.StateFlags & DisplayDeviceStateFlags.PrimaryDevice) ==
                             DisplayDeviceStateFlags.PrimaryDevice)
                        {
                            ddActive = dMode;
                            szActiveDeviceName = dd.DeviceName;
                        }
                        else
                        {
                            ddInactive = dMode;
                            szInactiveDeviceName = dd.DeviceName;
                        }
                    }
                }
                iDeviceCntr++;
            }
        }



        private void ChangeToSingleDisplay()
        {
            GetDisplayInfo();

            ddInactive.dmPosition.x = 0;
            ddInactive.dmPosition.y = 0;
            ddInactive.dmPelsHeight = 0;
            ddInactive.dmPelsWidth = 0;
            ddInactive.dmFields = DM.PelsHeight | DM.PelsWidth | DM.Position;

            ChangeDisplaySettingsEx(szInactiveDeviceName, ref ddInactive,
              IntPtr.Zero, (int)(CDSFlags.CDS_RESET | CDSFlags.CDS_UPDATEREGISTRY), IntPtr.Zero);
        }



    }
}




