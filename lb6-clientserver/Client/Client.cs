using System;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using Newtonsoft.Json;

struct Post
{
    public string id;
    public string title;
    public string body;
    public User author;
    public string created;
    public string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("#############");
        sb.AppendLine($"id:\t{id}");
        sb.AppendLine($"title:\t{title}");
        sb.AppendLine($"author:\t{author.email}");
        sb.AppendLine($"created:\t{created}");
        sb.AppendLine($"body:\t{body}");
        return sb.ToString();
    }
}

struct Connection
{
    public User user;
    public string accessToken;
    public string refreshToken;
    public Connection(User user, string accessToken, string refreshToken)
    {
        this.accessToken = accessToken;
        this.refreshToken = refreshToken;
        this.user = user;
    }
}

struct User
{
    public string id;
    public string email;
    public string[] rules;
    public string created;
    public void setEmail(string newEmail) => email = newEmail;
}

class ClientVM {
    public bool isConnect { get; private set; }
    public Connection Session { get; private set; }
    public string HOST;
    HttpClient Client;
    public ClientVM(string host)
    {
        this.HOST = host;
        Client = new HttpClient();
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
        isConnect = false;
    }

    public async Task Authorize(string email, string password)
    {
        if (!String.IsNullOrEmpty(Session.accessToken)) throw new DataException("Session is already exist");
        Client.DefaultRequestHeaders.Accept.Clear();
        var content = new FormUrlEncodedContent(new Dictionary<string, string>() {
          { "email", email},
          { "password", password }
        });
        var awaiter = await Client.PostAsync($"{this.HOST}/user/authorization", content);
        if (!awaiter.IsSuccessStatusCode) throw new ArgumentException("Bed credentials");
        var response = await awaiter.Content.ReadAsStringAsync();
        var data =  JsonConvert.DeserializeObject<Connection>(response);
        Session = new Connection(data.user, data.accessToken, data.refreshToken);
        isConnect = true;
    }

    public async Task Registrate(string email, string password)
    {
        if (!String.IsNullOrEmpty(Session.accessToken)) throw new DataException("Session is already exist");
        Client.DefaultRequestHeaders.Accept.Clear();
        var content = new FormUrlEncodedContent(new Dictionary<string, string>() {
          { "email", email},
          { "password", password }
        });
        var awaiter = await Client.PostAsync($"{this.HOST}/user/registration", content);
        if (!awaiter.IsSuccessStatusCode) throw new ArgumentException("Bed credentials");
        MessageBox.Show("Check your email");
    }
    public async Task SendPost(string title, string body)
    {
        if (String.IsNullOrEmpty(Session.accessToken)) throw new DataException("Session forbidden");
        Client.DefaultRequestHeaders.Accept.Clear();
        Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Session.accessToken);
        var content = new FormUrlEncodedContent(new Dictionary<string, string>() {
          { "author", Session.user.id},
          { "title", title },
          { "body", body },
        });
        var awaiter = await Client.PostAsync($"{this.HOST}/post", content);
        if (!awaiter.IsSuccessStatusCode) throw new ArgumentException("Bed credentials");
        MessageBox.Show("Post Sended");
    }
    public async Task Exit()
    {
        Client.DefaultRequestHeaders.Accept.Clear();
        var content = new FormUrlEncodedContent(new Dictionary<string,string>() { });
        var awaiter = await Client.PostAsync($"{this.HOST}/user/logout", content);
        isConnect = false;
    }
    public async Task<List<Post>> PullPosts()
    {
        Client.DefaultRequestHeaders.Accept.Clear();
        var awaiter = await Client.GetAsync($"{this.HOST}/post");
        if (!awaiter.IsSuccessStatusCode) throw new ArgumentException("Bed credentials");
        var response = await awaiter.Content.ReadAsStringAsync();
        var data = JsonConvert.DeserializeObject<List<Post>>(response);
        return data;

    }

}
