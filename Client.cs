using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PickingTheStones
{
    public class Client
    {
        StartGame start;

        TcpClient clnt;
        NetworkStream stream;
        BinaryFormatter bf = new BinaryFormatter();

        public string Ip { get; private set; }
        //public string GetMove { get; private set; }

        public Client(string ip)
        {
            this.Ip = ip;

            start = new StartGame(null, null, null, null, 0, null, 0);

            clnt = new TcpClient(this.Ip, 1453); // add tcp ip
            stream = clnt.GetStream();
            Thread listener = new Thread(ListenConnect);
            listener.Start();

            MainPage main = new MainPage(10, 1,1);
            main.Text = "CLIENT MAIN PAGE";
            main.ShowDialog();
        }
        
        void ListenConnect()
        {
            while (true)
            {
                string get = (string)bf.Deserialize(stream);
                //this.GetMove = get;
                start.MakeAMove(get);

            }
        }

        public void SendMove(string send)
        {
            bf.Serialize(stream, send);
            stream.Flush();
        }

    }
}

//******************************************************************CLIENT
/*
 * public client()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        TcpClient clnt;
        NetworkStream stream;

        private void btnCnt_Click(object sender, EventArgs e)
        {
            clnt = new TcpClient(tbxCnt.Text, 1453);
            stream = clnt.GetStream();
            Thread listener = new Thread(ListenConnect);
            listener.Start();
        }

        BinaryFormatter bf = new BinaryFormatter();

        void ListenConnect()
        {
            while (true)
            {
                string get = (string)bf.Deserialize(stream);
                lbxChats.Items.Add(get);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            lbxChats.Items.Add(tbxMess.Text);
            bf.Serialize(stream, tbxMess.Text.ToString());
            stream.Flush();

            tbxMess.Clear();
            tbxMess.Focus();
        }


*/