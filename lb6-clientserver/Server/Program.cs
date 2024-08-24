//////////////////////////////////////////
//  Лабораторная работа #3  | Вариант 5 //
//  Студент Киуки-20-5 Мавринский А.Д.  //
//              --Server--              //
//////////////////////////////////////////


using System;
using System.Net;
using System.Text.Json;
using System.Net.Sockets;
using System.Runtime.Intrinsics.X86;
using System.Text;

internal class Program {
    static Listener listener;
    static List<Socket> sockets;
    static void Main(string[] args) {
        listener = new Listener(8);
        listener.SocketAccepted += new Listener.SocketAcceptedHandler(listener_SocketAccepted);
        listener.Start();
        sockets = new List<Socket>();
        System.Diagnostics.Process.GetCurrentProcess().WaitForExit();
    }
 
    static void listener_SocketAccepted(Socket e) {
        Console.Clear();
        Client client = new Client(e);
        client.Received += new Client.ClientReceivedHandler(client_Received);
        client.Disconnected += new Client.ClientDisconnectedHandler(client_Disconnected);
        listener.Connections.Add(new KeyValuePair<Client, DateTime>(client,DateTime.Now));
        listener.Print();
    }
    
    static void client_Received(Client sender, byte[] data)
    {
        Console.Clear();
        String result = Encoding.Default.GetString(data);
        Console.WriteLine(result.Length);
        var foundKey = listener.DataPool.Keys.FirstOrDefault( x => x.Equals(sender.parseString()) );
        if (foundKey == null) {
            listener.DataPool.Add(sender.parseString(), new List<KeyValuePair<DateTime, string>>() {
                new KeyValuePair<DateTime, string>(DateTime.Now,result)
            });
        }
        else {
            listener.DataPool[sender.parseString()].Add(new KeyValuePair<DateTime, string>(DateTime.Now,result));
        }
        listener.Print();
        
        var json = JsonSerializer.Serialize(listener.DataPool);
        byte[] msg = Encoding.Default.GetBytes(json);
        int bytesSent = sender.socket.Send(msg);
    }

    static void client_Disconnected(Client sender)
    {
        Console.Clear();
        listener.Connections.RemoveAll(connection=>connection.Key.Equals(sender));
        listener.Print();
    }
}