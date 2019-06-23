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
                MessageBox.Show(data.ToString(), "Mesaj");
            });
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            socket.Emit("message", textBox1.Text.Trim());
        }
    }
}
