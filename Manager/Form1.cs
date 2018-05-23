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
using System.Collections.ObjectModel;

namespace Manager
{
    public partial class Form1 : Form
    {
        private Thread StartThread;
        private Thread UpdateThread;

        ObservableCollection<Packet> Proccess = new ObservableCollection<Packet>();

        public Form1()
        {
            InitializeComponent();

            var picture = new PictureBox
            {
                Name = "pictureBox",
                Size = new Size(282, 179),
                
                Image = Image.FromFile("mono.jpg"),

            };
            panelcard.Controls.Add(picture);

            cbCard.SelectedIndex = 0;

            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    tbMyIp.Text = ip.ToString();
                }
            }

        }

        public void StartWork()
        {
            StartThread = new Thread(FindClients);
            StartThread.IsBackground = true;
            StartThread.Name = "FindClients";
            StartThread.Start();
        }

        public void UpdateProgress()
        {
            UpdateThread = new Thread(UpdateProg);
            UpdateThread.IsBackground = true;
            UpdateThread.Name = "UpdateProgress";
            UpdateThread.Start();
        }

        private TcpListener listener;

        public Packet Packet { get;  set; }

        protected void UpdateProg()
        {
            try
            {
                IPAddress ipAddress = IPAddress.Parse(tbMyIp.Text);

                listener = new TcpListener(ipAddress, 4567);

                listener.Start();

                while (true)
                {
                    Socket clientSocket = listener.AcceptSocket();

                    byte[] buffer = new byte[65000];

                    int res = clientSocket.Receive(buffer);

                    if (res > 1)
                    {
                        byte[] buf = new byte[res];

                        Array.Copy(buffer, buf, res);

                        Packet = FromByteArray<Packet>(buf);

                        foreach (var Paks in Proccess)
                        {
                            if (Paks.IPAdress.Equals(Packet.IPAdress))
                            {
                                Paks.CardType = Packet.CardType;
                                Paks.CountFiles = Packet.CountFiles;
                                Paks.FileInfo = Packet.FileInfo;
                            }
                        }
                    }

                    clientSocket.Close();
                }
            }
            catch (SocketException ex)
            {
                //Trace.TraceError(String.Format("QuoteServer {0}", ex.Message));
            }
        }

        private void FindClients()
        {
            try
            {
                IPAddress ipAddress = IPAddress.Parse(tbMyIp.Text);

                listener = new TcpListener(ipAddress, 4568);

                listener.Start();

                while (true)
                {
                    Socket clientSocket = listener.AcceptSocket();

                    string point = ((IPEndPoint)clientSocket.RemoteEndPoint).Address.ToString();

                    if (Proccess.Count == 0)
                    {
                        Packet pak = new Packet
                        {
                            CardType = "",
                            CVV = chbCVV.Checked,
                            MSOffice = cbOffice.Checked,
                            Rar = cbRar.Checked,
                            Directory = tbDirectory.Text,
                            IPAdress = ""
                        };
                        Proccess.Add(pak);
                    }

                    foreach (var item in Proccess)
                    {
                        if (!item.IPAdress.Equals(point))
                            item.IPAdress = point;
                    }

                    clientSocket.Close();

                    Proccess.CollectionChanged += Proccess_CollectionChanged;

                    //Thread.Sleep(5000);
                }
            }
            catch (SocketException ex)
            {
                // Trace.TraceError(String.Format("QuoteServer {0}", ex.Message));
            }

        }

        private void Proccess_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this.Invoke((MethodInvoker)(() => lbComps.Items.Clear()));

            foreach (var item in Proccess)
            {
                this.Invoke((MethodInvoker)(() => lbComps.Items.Add(item.IPAdress)));
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

            Packet pak = new Packet
            {
                CardType = cbCard.SelectedItem.ToString(),
                CVV = chbCVV.Checked,
                MSOffice = cbOffice.Checked,
                Rar = cbRar.Checked,
                Directory = tbDirectory.Text,
                IPAdress = "127.0.0.1"
            };

            //OnSetQuote(lbComps.SelectedItem.ToString(),4567, pak);
            Proccess.Add(pak);
            Proccess.Add(pak);
            Proccess.Add(pak);
            Proccess.Add(pak);
            Proccess.Add(pak);

            lvProccess.Items.Clear();

            foreach (var item in Proccess)
            {
                ListViewItem items = new ListViewItem();
                items.Text = item.IPAdress;
                items.SubItems.Add(item.CardType);
                items.SubItems.Add(Convert.ToString(item.CVV));
                items.SubItems.Add(Convert.ToString(item.MSOffice));
                items.SubItems.Add(Convert.ToString(item.Rar));
                items.SubItems.Add(item.Directory);
                items.SubItems.Add("Progress");

                this.Invoke((MethodInvoker)(() => lvProccess.Items.Add(items)));

                ProgressBar pb = new ProgressBar();

                Rectangle r = items.SubItems[6].Bounds;

                pb.SetBounds(r.X, r.Y, r.Width, r.Height);
                pb.Minimum = 0;
                pb.Maximum = 100;
                pb.Value = Convert.ToInt32(item.CurrentFile);
                pb.Name = "Progress";                   // use the key as the name

                this.Invoke((MethodInvoker)(() => lvProccess.Controls.Add(pb)));
            }


        }

        private void Start_Click(object sender, EventArgs e)
        {
            StartWork();

            UpdateProgress();
        }
    }
}
