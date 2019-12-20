using nSbllWeight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace weight
{
    public partial class Form1 : Form
    {
        public static SerialPort com = new SerialPort();
        public Form1()
        {
            InitializeComponent();
            string[] names = SerialPort.GetPortNames(); // 获取所有可用串口的名字
            comboBox_com.Items.AddRange(names);
            comboBox_com.SelectedIndex = 0;
            string[] bps = new string[6] { "2400", "4800", "9600", "19200", "38400" ,"115200"};
            comboBox_bps.Items.AddRange(bps);
            comboBox_bps.SelectedIndex = 2;
            com.DataReceived += new SerialDataReceivedEventHandler(dataRecv);
            textBox_weigh.KeyPress += new KeyPressEventHandler(textBox_weigh_KeyPress);
        }

        private void textBox_weigh_KeyPress(object sender, KeyPressEventArgs e)
        {
            //throw new NotImplementedException();
            //if ((e.KeyChar < '0') || (e.KeyChar > '9'))//这是允许输入0-9数字  
            //{
            //    e.Handled = true;
            //}

            //if ((e.KeyChar == '.') || (e.KeyChar == '\b'))//这是允许输入0-9数字  
            //{
            //    e.Handled = true;
            //}
            if (e.KeyChar == '.' && this.textBox_weigh.Text.IndexOf(".") != -1)
            {
                e.Handled = true;
            }

            if (!((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == '.' || e.KeyChar == 8))
            {
                e.Handled = true;
            }
        }

        private void dataRecv(object sender, SerialDataReceivedEventArgs e)
        {
            
            if(textBox_weigh.Text.Length>0)
            {
                bllWeight.f_weight = float.Parse(textBox_weigh.Text);
                int point = textBox_weigh.Text.IndexOf('.');
                if(point<0)
                {
                    bllWeight.l_weight = uint.Parse(textBox_weigh.Text);
                    bllWeight.short_point = 0;
                    bllWeight.short_w = 1;
                }
                else
                {
                    string[] s_l = textBox_weigh.Text.Split('.');
                    uint u_10_count = 1;


                    if(s_l.Length>=2)
                    {
                        for (int i=0;i< s_l[1].Length; i++)
                        {
                            u_10_count *= 10;
                        }
                        bllWeight.l_weight = u_10_count*uint.Parse(s_l[0]) + uint.Parse(s_l[1]);
                        bllWeight.short_point = (ushort)s_l[1].Length;
                        bllWeight.short_w = 1;
                    }
                    
                }
            }
            else
            {
                bllWeight.f_weight = 0;
            }
            //throw new NotImplementedException();
            byte[] buffer = new byte[com.BytesToRead];//sp.BytesToRead
            com.Read(buffer, 0, buffer.Length);
            bllWeight.parse_comData(buffer,buffer.Length);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            string port = (string)comboBox_com.SelectedItem;
            string bps = (string)comboBox_bps.SelectedItem;

            if(!com.IsOpen)
            {
                com.PortName = port;
                com.BaudRate = int.Parse(bps);
                com.DataBits = 8;
                com.StopBits = (StopBits)1;
                com.ReadTimeout = 3000;
                com.Open();

            }
            button_comopen.Enabled = false;
            button_comclose.Enabled = true;
            button_comupdate.Enabled = false;

        }

        private void button_comclose_Click(object sender, EventArgs e)
        {
            com.Close();
            button_comopen.Enabled = true;
            button_comclose.Enabled = false;
            button_comupdate.Enabled = true;
        }

        private void button_comupdate_Click(object sender, EventArgs e)
        {
            string[] names = SerialPort.GetPortNames(); // 获取所有可用串口的名字
            comboBox_com.Items.Clear();
            comboBox_com.Items.AddRange(names);
            comboBox_com.SelectedIndex = 0;
        }
    }
}
