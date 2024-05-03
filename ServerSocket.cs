using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MRZReader
{
    internal class ServerSocket
    {
        delegate void MessageEventHandler(object sender, MessageEventArgs e);

        class MessageEventArgs : EventArgs
        {
            public string Message { get; private set; }

            public MessageEventArgs(string message)
            {
                this.Message = message;
            }
        }

        private TcpListener serverSocket;
        private List<ClientSocket> workers = new List<ClientSocket>();
        private bool bStart = false;

        public ServerSocket(int port)
        {
            //serverSocket = new TcpListener(port);// deprecated
            // the same way
            bStart = true;
            serverSocket = new TcpListener(IPAddress.Any, port);
            serverSocket.Start();

        }


        public void StopServer()
        {
            bStart = false;
            serverSocket.Stop();
        }

        public void WaitForConnection()
        {
            while (bStart)
            {
                try
                {
                    TcpClient socket = serverSocket.AcceptTcpClient();
                    ClientSocket worker = new ClientSocket(socket);
                    worker.Username = workers.Count + 1.ToString();
                    AddWorker(worker);
                    worker.Start();
                }
                catch { }
            }
        }

        private void Worker_MessageReceived(object sender, ClientSocket.MessageEventArgs e)
        {
            BroadcastMessage(sender as ClientSocket, e.Message);
        }

        private void Worker_Disconnected(object sender, EventArgs e)
        {
            RemoveWorker(sender as ClientSocket);
        }

        private void AddWorker(ClientSocket worker)
        {
            lock (this)
            {
                workers.Add(worker);
                worker.Disconnected += Worker_Disconnected;
                worker.MessageReceived += Worker_MessageReceived;
            }
        }

        private void RemoveWorker(ClientSocket worker)
        {
            lock (this)
            {
                worker.Disconnected -= Worker_Disconnected;
                worker.MessageReceived -= Worker_MessageReceived;
                workers.Remove(worker);
                worker.Close();
            }
        }

        private void BroadcastMessage(ClientSocket from, String message)
        {
            lock (this)
            {
                message = string.Format("{0}: {1}", from.Username, message);
                for (int i = 0; i < workers.Count; i++)
                {
                    ClientSocket worker = workers[i];
                    if (!worker.Equals(from))
                    {
                        try
                        {
                            worker.Send(message);
                        }
                        catch (Exception)
                        {
                            workers.RemoveAt(i--);
                            worker.Close();
                        }
                    }
                }
            }
        }

        public void BroadcastMessage(String message)
        {
            lock (this)
            {
                message = string.Format("{0}", message);
                for (int i = 0; i < workers.Count; i++)
                {
                    ClientSocket worker = workers[i];
                    try
                    {
                        worker.Send(message);
                    }
                    catch (Exception)
                    {
                        workers.RemoveAt(i--);
                        worker.Close();
                    }
                }
            }
        }
    }
}
