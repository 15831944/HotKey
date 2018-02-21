using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotKey {
    public partial class Form1 : Form {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("User32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        public Form1() {
            InitializeComponent();
        }

        bool isListEquals(List<Keys> a, List<Keys> b) {
            if (a.Count != b.Count)
                return false;
            for (int i = 0;i < a.Count; i++) {
                if (a[i] != b[i])
                    return false;
            }
            return true;
        }

        void a() {
            MessageBox.Show("按下了热键A\r\n");
        }

        void c() {
            MessageBox.Show("按下了热键Ctrl\r\n");
        }

        void ca() {
            MessageBox.Show("按下了热键Ctrl + A\r\n");
        }

        private void Form1_Load(object sender, EventArgs e) {
            HotKey.initialize();
            HotKey.registetHotKey(new List<Keys> { Keys.A }, a);
            HotKey.registetHotKey(new List<Keys> { Keys.ControlKey }, c);
            HotKey.registetHotKey(new List<Keys> { Keys.ControlKey, Keys.A }, ca);
            //HotKey.bindWindow = FindWindow("地下城与勇士", "地下城与勇士");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            HotKey.release();
        }
    }
}
