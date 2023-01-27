using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Memory;

namespace PlantsVs.ZombiesTools
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        private static extern int FindWindow(string lpClassName, string lpWindowName);

        // 遊戲程序名字
        private readonly string processName = "popcapgame1";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (CheckGameStart(processName))
            {
                GetSunValue();
                GetMoneyValue();
                GetCDValue();
                GetZombiesAttackPower();
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (CheckGameStart(processName))
            {
                GetSunValue();
                GetMoneyValue();
                GetCDValue();
                GetZombiesAttackPower();
            }
            else
            {
                SunValue.Text = "未啟動遊戲";
                MoneyValue.Text = "未啟動遊戲";
                CDValue.Text = "未啟動遊戲";
            }
        }

        private void GetSunValue()
        {
            // 遊戲陽光基址 + 偏移量1&2
            int[] address = new int[] { 0x006A9EC0, 0x768, 0x5560 };
            try
            {
                EditorMemory em = new EditorMemory(address, processName);
                SunValue.Text = em.Value.ToString();
            }
            catch { }
        }

        private void GetMoneyValue()
        {
            // 遊戲金幣基址 + 偏移量1&2
            int[] address = new int[] { 0x006A9EC0, 0x82c, 0x28 };
            try
            {
                EditorMemory em = new EditorMemory(address, processName);
                MoneyValue.Text = em.Value.ToString() + "0";
            }
            catch { }
        }

        private void GetCDValue()
        {
            try
            {
                // 判斷CD func記憶位置
                EditorMemory em = new EditorMemory(0x488e73, processName);
                byte[] rv1 = em.ReadData();
                byte[] rv2 = new byte[] { 0xc6, 0x45, 0x48, 0x00 };
                bool isSame = ((IStructuralComparable)rv1).CompareTo(rv2, Comparer<byte>.Default) == 0;
                if (isSame)
                {
                    CDValue.Text = "有";
                    CDOnButton.Enabled = false;
                    CDOffButton.Enabled = true;
                }
                else
                {
                    CDValue.Text = "無";
                    CDOffButton.Enabled = false;
                    CDOnButton.Enabled = true;
                }
            }
            catch { }
        }

        private void GetZombiesAttackPower()
        {
            // 殭屍攻擊力 func記憶位置
            EditorMemory em = new EditorMemory(0x52fcf0, processName);
            byte[] rv1 = em.ReadData();
            byte[] rv2 = new byte[] { 0x83, 0x46, 0x40, 0xfc };
            bool isSame = ((IStructuralComparable)rv1).CompareTo(rv2, Comparer<byte>.Default) == 0;
            if (isSame)
            {
                InvincibleValue.Text = "關";
                InvincibleOffButton.Enabled = false;
                InvincibleOnButton.Enabled = true;
            }
            else
            {
                InvincibleValue.Text = "開";
                InvincibleOnButton.Enabled = false;
                InvincibleOffButton.Enabled = true;
            }
        }

        private void SetSunValueButton_Click(object sender, EventArgs e)
        {
            // 遊戲陽光基址 + 偏移量1&2
            int[] address = new int[] { 0x006A9EC0, 0x768, 0x5560 };
            try
            {
                new EditorMemory(address, processName)
                {
                    Value = GetInt(SetSunValueTextBox.Text)
                };
            }
            catch
            {
                MessageBox.Show("遊戲尚未起動!", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetInt(string s)
        {
            int.TryParse(s, out int n);
            return n;
        }

        private void CDOffButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 判斷CD func記憶位置
                EditorMemory em = new EditorMemory(0x488e73, processName);
                // 強迫回傳true
                em.WriteData(new byte[] { 0xc6, 0x45, 0x48, 0x01 });
            }
            catch
            {
                MessageBox.Show("遊戲尚未起動!", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CDOnButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 判斷CD func記憶位置
                EditorMemory em = new EditorMemory(0x488e73, processName);
                // 改回預設值
                em.WriteData(new byte[] { 0xc6, 0x45, 0x48, 0x00 });
            }
            catch
            {
                MessageBox.Show("遊戲尚未起動!", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetMoneyValueButton_Click(object sender, EventArgs e)
        {
            // 遊戲金幣基址 + 偏移量1&2
            int[] address = new int[] { 0x006A9EC0, 0x82c, 0x28 };
            try
            {
                if (!string.IsNullOrWhiteSpace(SetMoneyValueTextBox.Text))
                {
                    new EditorMemory(address, processName)
                    {
                        Value = GetInt(SetMoneyValueTextBox.Text.Substring(0, SetMoneyValueTextBox.Text.Length - 1))
                    };
                }
            }
            catch
            {
                MessageBox.Show("遊戲尚未起動!", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 確定遊戲有啟動
        /// </summary>
        /// <param name="processName"><processName/param>
        /// <returns>true: 已啟動 false: 未啟動</returns>
        private bool CheckGameStart(string processName)
        {
            Process[] arrayProcess = Process.GetProcessesByName(processName);
            foreach (Process p in arrayProcess)
            {
                return true;
            }
            return false;
        }

        private void InvincibleOnButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 殭屍攻擊力 func記憶位置
                EditorMemory em = new EditorMemory(0x52fcf0, processName);
                // 改0
                em.WriteData(new byte[] { 0x83, 0x46, 0x40, 0x00 });
            }
            catch
            {
                MessageBox.Show("遊戲尚未起動!", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InvincibleOffButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 殭屍攻擊力 func記憶位置
                EditorMemory em = new EditorMemory(0x52fcf0, processName);
                // 改回預設值
                em.WriteData(new byte[] { 0x83, 0x46, 0x40, 0xfc });
            }
            catch
            {
                MessageBox.Show("遊戲尚未起動!", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
