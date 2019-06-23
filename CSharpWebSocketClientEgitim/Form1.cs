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

            socket.On("login", data =>
            {
                User user = JsonConvert.DeserializeObject<User>(data.ToString());
                MessageBox.Show("Kullanıcı: " + user.name + "\nYaş: " + user.old + "\nbağlandı!");
            });
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            socket.Emit("login", JsonConvert.SerializeObject(new { name = textBox1.Text.Trim(), old = int.Parse(textBox2.Text.Trim()) }));
        }
    }
}
