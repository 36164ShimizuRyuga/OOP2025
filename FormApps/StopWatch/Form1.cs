﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Text;

namespace StopWatch {
    public partial class Form1 : Form {

        Stopwatch sw = new Stopwatch();

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            lbTamedisp.Text = "00:00:00.00";
            tmDispTimer.Interval = 1;
        }
        
        //スタートボタンのイベントハンドラ
        private void btStart_Click(object sender, EventArgs e) {
            sw.Start();
            tmDispTimer.Start();  //画面更新用のタイマーをStart
        }

        private void tmDispTimer_Tick(object sender, EventArgs e) {
            lbTamedisp.Text = sw.Elapsed.ToString(@"hh\:mm\:ss\.ff");
        }

        private void btStop_Click(object sender, EventArgs e) {
            sw.Stop();
        }

        private void btReset_Click(object sender, EventArgs e) {
            sw.Reset();
        }
    }
}
