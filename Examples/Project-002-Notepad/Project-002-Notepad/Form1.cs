using Project_002_Notepad.Data;
using Project_002_Notepad.Data.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Project_002_Notepad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NotepadInfoRepository notepadInfoRepository = new NotepadInfoRepository();
            var infos = notepadInfoRepository.GetInfos();
            listBox1.Items.Clear();
            foreach (var item in infos)
            {
                listBox1.Items.Add($"【{item.CreateTime.ToString("yyyy-MM-dd HH:mm:ss")}】{item.NotepadContent}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text)) {
                NotepadInfoRepository notepadInfoRepository = new NotepadInfoRepository();
                notepadInfoRepository.SetInfo(textBox1.Text);
                button1_Click(null, null);
            }
            else
            {
                MessageBox.Show("大兄dei，你得写字啊", "系统提示");
            }
            textBox1.Clear();
        }
    }
}
