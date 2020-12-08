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
    public class Server
    {

        StartGame start;

        Socket socket;
        NetworkStream stream;
        TcpListener listener;

        BinaryFormatter bf = new BinaryFormatter();
        //public string GetMove { get; private set; }

        public Server()
        {
            start = new StartGame(null, null, null, null, 0, null,0);

            listener = new TcpListener(1453);
            listener.Start();

            socket = listener.AcceptSocket();
            stream = new NetworkStream(socket);
            Thread dinle = new Thread(SocketDinle);
            dinle.Start();

            MainPage main = new MainPage(10, 1,0);
            main.Text = "SERVER MAIN PAGE";
            main.ShowDialog();
        }

        public void SocketDinle()
        {
            while (socket.Connected)
            {
                string send = (string)bf.Deserialize(stream);
                //this.GetMove = send;
                //send to start class and make move
                start.MakeAMove(send);
            }
        }

        public void SendMove(string send)
        {
            bf.Serialize(stream, send);
            stream.Flush();
        }



    }
}


//Socket socket;
//NetworkStream stream;
//TcpListener listener;

//private void Form1_Load(object sender, EventArgs e)
//{

//    listener = new TcpListener(1453);
//    listener.Start();

//    socket = listener.AcceptSocket();
//    stream = new NetworkStream(socket);
//    Thread dinle = new Thread(SocketDinle);
//    dinle.Start();

//}
////192.168.43.164
//BinaryFormatter bf = new BinaryFormatter();

//void SocketDinle()
//{
//    while (socket.Connected)
//    {
//        string gonder = (string)bf.Deserialize(stream);
//        lbxChats.Items.Add(gonder);
//    }
//}

//private void btnSend_Click(object sender, EventArgs e)
//{
//    lbxChats.Items.Add(tbxMess.Text);
//    bf.Serialize(stream, tbxMess.Text);
//    stream.Flush();

//    tbxMess.Clear();
//    tbxMess.Focus();
//}



