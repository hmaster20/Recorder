using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Collections;

namespace WindowsApplication2
{
    class clsRecDevices
    {      
        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        public struct WaveInCaps
        {
            public short wMid;
            public short wPid;
            public int vDriverVersion;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public char[] szPname;
            public uint dwFormats;
            public short wChannels;
            public short wReserved1;
        }

        //return total Sound Recording Devices
        [DllImport("winmm.dll")]
        public static extern int waveInGetNumDevs();

        //return spesific Sound Recording Devices spec
        [DllImport("winmm.dll", EntryPoint = "waveInGetDevCaps")]
        public static extern int waveInGetDevCapsA(int uDeviceID, ref WaveInCaps lpCaps, int uSize);

        //using to store all sound recording devices strings 
        ArrayList arrLst = new ArrayList();

        int position = -1;

        //to return total sound recording devices found
        public int Count
        {            
            get {return arrLst.Count;}
        }

        //return spesipic sound recording device name
        public string this[int indexer]
        {
            get{return (string)arrLst[indexer];}
        }

        //fill sound recording devices array
        public clsRecDevices()
        {
            int waveInDevicesCount = waveInGetNumDevs();//get total
            if (waveInDevicesCount > 0)
            {
                for (int uDeviceID = 0; uDeviceID < waveInDevicesCount; uDeviceID++)
                {
                    WaveInCaps waveInCaps = new WaveInCaps();
                    waveInGetDevCapsA(uDeviceID,ref waveInCaps,Marshal.SizeOf(typeof(WaveInCaps)));
                    arrLst.Add(new string(waveInCaps.szPname).Remove(new string(waveInCaps.szPname).IndexOf('\0')).Trim());
                    //clean garbage                  
                }
            }
        }        
    }
}

//This class can be used as follows:
//Hide Copy Code

//clsRecDevices recDev = new clsRecDevices();
//for (int i = 0; i<recDev.Count; i++){
//    MessageBox.Show(recDev[i]);
//}
