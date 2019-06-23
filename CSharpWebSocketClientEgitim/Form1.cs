using Newtonsoft.Json;
using Quobject.SocketIoClientDotNet.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpWebSocketClientEgitim
{
    delegate void ChangeTextDel(string text);
    delegate void AddItemDel(string text);
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Socket socket;

        private void Form1_Load(object sender, EventArgs e)
        {
            socket = IO.Socket("http://localhost:3000");

            socket.On("message", data =>
            {
                ChangeText(data.ToString());
                AddItem(data.ToString());
            });
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            socket.Emit("message", textBox1.Text);
        }

        private void ChangeText(string text)
        {
            if (label1.InvokeRequired)
            {
                ChangeTextDel del = new ChangeTextDel(ChangeText);
                Invoke(del, new object[] { text });
            }
            else
            {
                label1.Text = text;
            }
        }

        private void AddItem(string text)
        {
            if (listBox1.InvokeRequired)
            {
                AddItemDel del = new AddItemDel(AddItem);
                Invoke(del, new object[] { text });
            }
            else
            {
                listBox1.Items.Add(text);
            }
        }
    }
}
