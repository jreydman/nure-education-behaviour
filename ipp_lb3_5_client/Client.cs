using System;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ipp_lb3_5_client;

struct Connection {
    public string Host;
    public int Port;
    public ProtocolType Type;
    public Connection(string Host, int Port, ProtocolType Type) {
        this.Host = Host;
        this.Port = Port;
        this.Type = Type;
    } }

class Client {
    public Dictionary<string, List<KeyValuePair<DateTime, string>>> DataPool;

    protected int msgLENGTH = 8192;
    public bool Connected { get; private set; }
    public string ID { get; private set; }
    public IPEndPoint EndPoint { get; private set; }
    public Socket socket { get; private set; }
    public Connection pipe { get; private set;}
    
    
    public Client(Connection connection) {
        this.pipe = connection;
        this.socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, connection.Type);
        ID = Guid.NewGuid().ToString();
        EndPoint = (IPEndPoint)socket.LocalEndPoint;
        DataPool = new Dictionary<string, List<KeyValuePair<DateTime, string>>>();
    }
    
    public string parseString() {
        StringBuilder sb = new StringBuilder();
        sb.Append($"|[{ID}]({EndPoint})|");
        return sb.ToString();
    }

    public void DataPoolPrint() {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("===\tDATA\t===");
        foreach (var authorPosts in DataPool) {
            foreach (var post in authorPosts.Value) {
                sb.AppendLine($"{authorPosts.Key}\t{post.Key}\t{post.Value}"); } }
        sb.Append("===========================");
        Console.WriteLine(sb.ToString());
    }
    
    public void Start() {
        try {
            if (Connected) return;
            socket.Connect(pipe.Host,pipe.Port);
            this.socket.BeginReceive(new byte[] { 0 }, 0, 0, 0, callback, null);
            Connected = true;
        }
        catch (Exception e) { Console.WriteLine(e.Message); throw; }
    }
    public void Stop() {
        if(!Connected) return;
        socket.Close(); 
        socket.Dispose();
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
            Stop();
        }
    }
    
    public string Send(string message) {
        byte[] buffer = new byte[msgLENGTH];
        byte[] msg = Encoding.ASCII.GetBytes(message);
        int bytesSent = socket.Send(msg);
        return null;
    }
    public delegate void pipeReceivedHandler(Client sender, byte[] data);

    public event pipeReceivedHandler Received;
}