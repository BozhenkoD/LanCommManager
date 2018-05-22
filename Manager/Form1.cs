using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

using System.Windows;
using System.Windows.Input;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Net;
using Protocols;
using System.Threading;
using System.Net.NetworkInformation;

namespace Manager
{
    public partial class Form1 : Form
    {
        private Thread StartThread;

        public List<string> Clients = new List<string>();

        public Form1()
        {
            InitializeComponent();

            var picture = new PictureBox
            {
                Name = "pictureBox",
                Size = new Size(282, 179),
                Image = Image.FromFile(@"C:\Ptoject\Manager\Manager\mono.jpg"),

            };
            panelcard.Controls.Add(picture);

            cbCard.SelectedIndex = 0;
        }

        public void StartWork()
        {
                StartThread = new Thread(FindClients);
                StartThread.IsBackground = true;
                StartThread.Name = "FindClients";
                StartThread.Start();
        }

        private void FindClients()
        {
            try
            {
                    IPAddress ipAddress = IPAddress.Parse(tbMyIp.Text);

                    TcpListener listener = new TcpListener(ipAddress, 4568);

                    listener.Start();

                    TcpClient clientSocket = listener.AcceptTcpClient();

                    string point = ((IPEndPoint)clientSocket.Client.RemoteEndPoint).Address.ToString();

                    if (!Clients.Contains(point))
                        Clients.Add(point);

                    clientSocket.Close();

                foreach (var item in Clients)
                {
                    this.Invoke((MethodInvoker)(() => lbComps.Items.Add(item)));
                }
            }
            catch (SocketException ex)
            {
                // Trace.TraceError(String.Format("QuoteServer {0}", ex.Message));
            }

        }

        private void OnGetQuote()
        {
            const int bufferSize = 1024;

            string serverName = Properties.Settings.Default.ServerName;
            int port = Properties.Settings.Default.PortNumber;

            TcpClient client = new TcpClient();
            NetworkStream stream = null;
            try
            {
                client.Connect(serverName, port);
                stream = client.GetStream();
                byte[] buffer = new Byte[bufferSize];
                int received = stream.Read(buffer, 0, bufferSize);
                if (received <= 0)
                {
                    return;
                }
                var textQuote = Encoding.Unicode.GetString(buffer).Trim('\0');
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при выдаче цитаты");
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }

                if (client.Connected)
                {
                    client.Close();
                }
            }

        }

        private void OnSetQuote(string ServerName,int Port, Packet Pak)
        {
            string serverName = ServerName;
            int port = Port;

            TcpClient client = new TcpClient();
            NetworkStream stream = null;
            try
            {
                client.Connect(serverName, port);

                stream = client.GetStream();

                byte[] buffer = ToByteArray<Packet>(Pak);

                stream.Write(buffer, 0, buffer.Length);
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка при выдаче цитаты");
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }

                if (client.Connected)
                {
                    client.Close();
                }
            }

        }

        public byte[] ToByteArray<T>(T obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        public T FromByteArray<T>(byte[] data)
        {
            if (data == null)
                return default(T);
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(data))
            {
                object obj = bf.Deserialize(ms);
                return (T)obj;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

            //IPEndPoint point = new IPEndPoint(IPAddress.Parse(lbComps.SelectedItem.ToString()), 4567);
            Packet pak = new Packet
            {
                CardType = cbCard.SelectedItem.ToString(),
                CVV = chbCVV.Checked,
                MSOffice = cbOffice.Checked,
                Rar = cbRar.Checked
            };

            OnSetQuote(lbComps.SelectedItem.ToString(),4567, pak);
            
        }

        private void Start_Click(object sender, EventArgs e)
        {
            StartWork();
        }
    }
}
