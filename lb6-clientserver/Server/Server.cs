using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Listener
{
    Socket s;
    public bool Listening { get; private set; }
    public int Port { get; private set; }
    
    public List<KeyValuePair<Client, DateTime>> Connections { get; private set; }
    public Dictionary<string, List<KeyValuePair<DateTime, string>>> DataPool;
    public Listener(int port) {
        Port = port;
        s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        Connections = new List<KeyValuePair<Client,DateTime>>();
        DataPool = new Dictionary<string, List<KeyValuePair<DateTime, string>>>();
    }

    public void Print()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("===\tCONNECTIONS\t===");
        foreach (var connection in Connections)
        {
            sb.AppendLine($"{connection.Key.parseString()}\t {connection.Value}");
        }
        sb.Append("===========================");
        Console.WriteLine(sb.ToString());
        sb.Clear();
        sb.AppendLine("===\tDATA\t===");
        foreach (var authorPosts in DataPool) {
            foreach (var post in authorPosts.Value) {
                sb.AppendLine($"{authorPosts.Key}\t{post.Key}\t{post.Value}");
            }
        }
        sb.Append("===========================");
        Console.WriteLine(sb.ToString());
    }
    
    public void Start() {
        if (Listening) return;
 
        s.Bind(new IPEndPoint(0, Port));
        s.Listen(0);
 
        s.BeginAccept(callback, null);
        Listening = true;
    }
 
    public void Stop() {
        if (!Listening) return;
        s.Close();
        s.Dispose();
    }
 
    void callback(IAsyncResult ar) {
        try {
            Socket s = this.s.EndAccept(ar);
            if (SocketAccepted != null) SocketAccepted(s);
            this.s.BeginAccept(callback, null);
        }
        catch(Exception ex) { Console.WriteLine(ex.Message.ToString()); }
    }

    public delegate void SocketAcceptedHandler(Socket e);
    public event SocketAcceptedHandler SocketAccepted;
}

