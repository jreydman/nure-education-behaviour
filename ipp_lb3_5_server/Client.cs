using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ipp_lb3_5_server;

public class Client
{
    public string ID { get; private set; }
    public IPEndPoint EndPoint { get; private set; }
    public Socket socket { get; private set; }

    public Client(Socket acceptedSocket)
    {
        this.socket = acceptedSocket;
        ID = Guid.NewGuid().ToString();
        EndPoint = (IPEndPoint)this.socket.RemoteEndPoint;
        socket.BeginReceive(new byte[] { 0 }, 0, 0, 0, callback, null);
    }

    void callback(IAsyncResult ar) {
        try {
            this.socket.EndReceive(ar);
            byte[] buffer = new byte[8192];
            int receive = socket.Receive(buffer, buffer.Length, 0);
            if(receive<buffer.Length) { Array.Resize<byte>(ref buffer,receive); }
            if (Received != null) { Received(this, buffer); }
            this.socket.BeginReceive(new byte[] { 0 }, 0, 0, 0, callback, null);
        }
        catch (Exception e) { 
            Console.WriteLine(e.Message.ToString()); 
            if (Disconnected != null) Disconnected(this);
            Close();
        }
    }
    public string parseString() {
        StringBuilder sb = new StringBuilder();
        sb.Append($"|[{ID}]({EndPoint})|");
        return sb.ToString();
    }
    public void Close() { socket.Close(); socket.Dispose();}

    public delegate void ClientReceivedHandler(Client sender, byte[] data);

    public delegate void ClientDisconnectedHandler(Client sender);

    public event ClientReceivedHandler Received;
    public event ClientDisconnectedHandler Disconnected;
}