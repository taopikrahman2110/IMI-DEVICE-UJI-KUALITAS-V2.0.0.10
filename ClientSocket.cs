using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MRZReader
{
    internal class ClientSocket
    {
        public delegate void MessageEventHandler(object sender, MessageEventArgs e);

        public class MessageEventArgs : EventArgs
        {
            public string Message { get; private set; }

            public MessageEventArgs(string message)
            {
                this.Message = message;
            }
        }

        public event MessageEventHandler MessageReceived;
        public event EventHandler Disconnected;
        private readonly TcpClient socket;
        private readonly Stream stream;
        public string Username { get; set; } = null;

        public ClientSocket(TcpClient socket)
        {
            this.socket = socket;
            this.stream = socket.GetStream();
        }

        public void Send(string message)
        {
            byte[] byteMessage = Encoding.UTF8.GetBytes(message);
            byte[] byteLen = BitConverter.GetBytes(byteMessage.Length);
            byte[] buffer = new byte[byteLen.Length + byteMessage.Length];
            Array.Copy(byteLen, 0, buffer, 0, byteLen.Length);
            Array.Copy(byteMessage, 0, buffer, byteLen.Length, byteMessage.Length);
            stream.Write(buffer, 0, buffer.Length);
        }

        public void Start()
        {
            new Thread(Run).Start();
            new Thread(HeartBeat).Start();
        }

        private void Run()
        {
            byte[] buffer = new byte[2048];
            try
            {
                while (true)
                {
                    int receivedBytes = stream.Read(buffer, 0, buffer.Length);
                    if (receivedBytes < 1)
                        break;
                    string message = Encoding.UTF8.GetString(buffer, 0, receivedBytes);
                    //if (Username == null)
                    //    Username = message;
                    //else
                    MessageReceived?.Invoke(this, new MessageEventArgs(message));
                }
            }
            catch (IOException) { }
            catch (ObjectDisposedException) { }
            Disconnected?.Invoke(this, EventArgs.Empty);
        }

        private void HeartBeat()
        {
            try
            {
                int iCount = 0;
                while (true)
                {
                    Thread.Sleep(1000);
                    iCount++;
                    if (iCount == 30)
                    {
                        iCount = 0;
                        byte[] byteMessage = Encoding.UTF8.GetBytes("Heart Beat");
                        byte[] byteLen = BitConverter.GetBytes(byteMessage.Length);
                        byte[] buffer = new byte[byteLen.Length + byteMessage.Length];
                        Array.Copy(byteLen, 0, buffer, 0, byteLen.Length);
                        Array.Copy(byteMessage, 0, buffer, byteLen.Length, byteMessage.Length);
                        stream.Write(buffer, 0, buffer.Length);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Close()
        {
            socket.Close();
        }
    }
}
