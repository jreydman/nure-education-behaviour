//////////////////////////////////////////
//  Лабораторная работа #3  | Вариант 5 //
//  Студент Киуки-20-5 Мавринский А.Д.  //
//              --CLIENT--              //
//////////////////////////////////////////


using System;
using System.Diagnostics;
using System.Dynamic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
namespace ipp_lb3_5_client;

internal class Program {
    private static Client client;
    public static void Main(String[] args) {
        byte[] buffer = new byte[8192];
        try {
            client = new Client(new Connection("127.0.0.1", 8, ProtocolType.Tcp));
            client.Start();
            client.Received += new Client.pipeReceivedHandler(client_pipeReceived);
            while (true) {
                Console.Write($"{client.parseString()}:");
                string message = Console.ReadLine();
                if (message.Equals("!!")) {
                    client.Stop();
                    Process.GetCurrentProcess().Close();
                    break; }
                byte[] msg = Encoding.Default.GetBytes(message);
                int bytesSent = client.socket.Send(msg);
                Thread.Sleep(50);
            }
        }
        catch (ArgumentNullException e) {
            Console.WriteLine($"ArgumentNullException : {e.ToString()}");
        }
        catch (SocketException e) {
            Console.WriteLine($"SocketException : {e.ToString()}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Unexpected exception : {e.ToString()}");
        }
        finally{ client.Stop(); Console.ReadKey(); }
    }
    private static void client_pipeReceived(Client sender, byte[] data) {
        Console.Clear();
        String result = Encoding.Default.GetString(data);
        var values = JsonSerializer.Deserialize<Dictionary<string, List<KeyValuePair<DateTime, string>>>>(result);
        client.DataPool = values;
        client.DataPoolPrint();
    }
}