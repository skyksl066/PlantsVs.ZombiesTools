using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Memory
{
    public class EditorMemory
    {
        #region API
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int dwSize, IntPtr lpNumberOfBytesRead);
        /// <summary>
        /// 從指定記憶體中讀取位元組集數據
        /// </summary>
        /// <param name="hProcess">Process ID</param>
        /// <param name="lpBaseAddress">地址</param>
        /// <param name="lpBuffer">緩衝</param>
        /// <param name="nSize"></param>
        /// <param name="lpNumberOfBytesRead"></param>
        /// <returns></returns>
        [DllImportAttribute("kernel32.dll", EntryPoint = "ReadProcessMemory")]
        private static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, int nSize, IntPtr lpNumberOfBytesRead);
        /// <summary>
        /// 從指定記憶體中寫入位元組集數據
        /// </summary>
        /// <param name="hProcess">Process ID</param>
        /// <param name="lpBaseAddress">地址</param>
        /// <param name="lpBuffer">資料</param>
        /// <param name="nSize">資料大小</param>
        /// <param name="lpNumberOfBytesWritten"></param>
        /// <returns></returns>
        [DllImport("kernel32.dll", EntryPoint = "WriteProcessMemory")]
        private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, int nSize, IntPtr lpNumberOfBytesWritten);
        /// <summary>
        /// 從指定記憶體中寫入位元組集數據
        /// </summary>
        /// <param name="hProcess">Process ID</param>
        /// <param name="lpBaseAddress">地址</param>
        /// <param name="lpBuffer">資料</param>
        /// <param name="nSize">資料大小</param>
        /// <param name="lpNumberOfBytesWritten"></param>
        /// <returns></returns>
        [DllImportAttribute("kernel32.dll", EntryPoint = "WriteProcessMemory")]
        private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, int[] lpBuffer, int nSize, IntPtr lpNumberOfBytesWritten);
        /// <summary>
        /// 打開一個已存在的進程對象，並返回進程的句柄
        /// </summary>
        /// <param name="dwDesiredAccess">權限</param>
        /// <param name="bInheritHandle"></param>
        /// <param name="dwProcessId">Process ID</param>
        /// <returns>進程的句柄</returns>
        [DllImportAttribute("kernel32.dll", EntryPoint = "OpenProcess")]
        private static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);
        /// <summary>
        /// 關閉一個內核對象。其中包括文件、文件映射、進程、線程、安全和同步對象等。
        /// </summary>
        /// <param name="hObject">進程的句柄</param>
        [DllImport("kernel32.dll")]
        private static extern void CloseHandle(IntPtr hObject);
        #endregion

        /// <summary>
        /// 地址
        /// </summary>
        public int Address
        {
            get
            {
                return P_address;
            }
        }
        private int P_address { get; set; }
        private int ProcessId { get; set; }
        /// <summary>
        /// 數值
        /// </summary>
        public int Value
        {
            get
            {
                return ReadInt();
            }
            set
            {
                WriteInt(value);
            }
        }
        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="address">地址帶偏移</param>
        /// <param name="processName">程序名稱</param>
        public EditorMemory(int[] address, string processName)
        {
            ProcessId = GetPidByProcessName(processName);
            P_address = ReadAddress(address);
        }

        /// <summary>
        /// 建構式
        /// </summary>
        /// <param name="address">地址</param>
        /// <param name="processName">程序名稱</param>
        public EditorMemory(int address, string processName)
        {
            ProcessId = GetPidByProcessName(processName);
            P_address = address;
        }

        /// <summary>
        /// 讀取地址
        /// </summary>
        /// <param name="address">地址帶偏移</param>
        /// <returns>地址</returns>
        private int ReadAddress(int[] address)
        {
            try
            {
                byte[] buffer = new byte[4];
                IntPtr byteAddress;
                int value = 0;
                int addr = 0;
                // 打開一個已存在的進程對象  0x1F0FFF 最高權限
                IntPtr hProcess = OpenProcess(0x1F0FFF, false, ProcessId);
                for (int i = 0; i < address.Length; i++)
                {
                    // 獲取緩沖區地址
                    byteAddress = Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0);
                    if (i == 0)
                    {
                        // 將制定內存中的值讀入緩沖區
                        ReadProcessMemory(hProcess, (IntPtr)address[i], byteAddress, 4, IntPtr.Zero);
                    }
                    else
                    {
                        // 將制定內存中的值讀入緩沖區
                        ReadProcessMemory(hProcess, (IntPtr)(value + address[i]), byteAddress, 4, IntPtr.Zero);
                        addr = value + address[i];
                    }
                    // 從非托管內存中讀取一個 32 位帶符號整數。
                    value = Marshal.ReadInt32(byteAddress);
                }
                // 關閉操作
                CloseHandle(hProcess);
                return addr;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// 讀取內存中的值
        /// </summary>
        /// <returns>0: 讀取失敗 >0:內存值</returns>
        private int ReadInt()
        {
            try
            {
                byte[] buffer = new byte[4];
                // 獲取緩沖區地址
                IntPtr byteAddress = Marshal.UnsafeAddrOfPinnedArrayElement(buffer, 0);
                // 打開一個已存在的進程對象  0x1F0FFF 最高權限
                IntPtr hProcess = OpenProcess(0x1F0FFF, false, ProcessId);
                // 將制定內存中的值讀入緩沖區
                ReadProcessMemory(hProcess, (IntPtr)P_address, byteAddress, 4, IntPtr.Zero);
                // 關閉操作
                CloseHandle(hProcess);
                return Marshal.ReadInt32(byteAddress);
            }
            catch
            {
                return 0;
            }
        }

        public byte[] ReadData()
        {
            try
            {
                byte[] data = new byte[4];
                // 打開一個已存在的進程對象  0x1F0FFF 最高權限
                IntPtr hProcess = OpenProcess(0x1F0FFF, false, ProcessId);
                // 將制定內存中的值讀入緩沖區
                ReadProcessMemory(hProcess, (IntPtr)P_address, data, 4, IntPtr.Zero);
                // 關閉操作
                CloseHandle(hProcess);
                return data;
            }
            catch
            {
                return new byte[] { };
            }
        }

        /// <summary>
        /// 將值寫入指定內存地址中
        /// </summary>
        /// <param name="value">寫入值</param>
        private void WriteInt(int value)
        {
            try
            {
                //打開一個已存在的進程對象  0x1F0FFF 最高許可權
                IntPtr hProcess = OpenProcess(0x1F0FFF, false, ProcessId);
                //從指定記憶體中寫入位元組集數據
                WriteProcessMemory(hProcess, (IntPtr)P_address, new int[] { value }, 4, IntPtr.Zero);
                //關閉操作
                CloseHandle(hProcess);
            }
            catch { }
        }

        /// <summary>
        /// 將值寫入指定內存地址中
        /// </summary>
        /// <param name="value">寫入值</param>
        /// <returns>記憶體位置</returns>
        public bool WriteData(byte[] value)
        {
            try
            {
                // 打開一個已存在的進程對象  0x1F0FFF 最高權限
                IntPtr hProcess = OpenProcess(0x1F0FFF, false, ProcessId);
                // 從指定內存中寫入字節集資料
                WriteProcessMemory(hProcess, (IntPtr)P_address, value, value.Length, IntPtr.Zero);
                // 關閉操作
                CloseHandle(hProcess);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 根據進程名獲取PID
        /// </summary>
        /// <param name="processName">程序名稱</param>
        /// <returns>pid</returns>
        private int GetPidByProcessName(string processName)
        {
            Process[] arrayProcess = Process.GetProcessesByName(processName);
            foreach (Process p in arrayProcess)
            {
                return p.Id;
            }
            throw new Exception("Processes not found");
        }
    }
}
