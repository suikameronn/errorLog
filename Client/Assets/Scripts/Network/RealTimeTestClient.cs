using App.Reversi.Shared;
using Cysharp.Net.Http;
using Grpc.Net.Client;
using MagicOnion.Client;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class RealTimeTestClient : IRealTimeTestReserver
{
    private YetAnotherHttpHandler handler;
    private GrpcChannelOptions options;
    private GrpcChannel channel;

    private IRealTimeTest client;

    private Dictionary<string,Player> players = new Dictionary<string, Player>();
    private Player ownPlayer;

    private GameObject debug;
    private TMP_Text debugText;

    public RealTimeTestClient()
    {
        //debug = GameObject.Find("Debug");
        //debugText = debug.GetComponent<TMP_Text>();
    }

    public async ValueTask<Player> ConnectAsync(string roomName, string userName, Vector3 position)
    {
        handler = new YetAnotherHttpHandler();
        handler.Http2Only = true;
        options = new GrpcChannelOptions { HttpHandler = handler, UnsafeUseInsecureChannelCallCredentials = false };
        channel = GrpcChannel.ForAddress("http://localhost:5000", options);

        ownPlayer = new Player();
        ownPlayer.Name = userName;
        ownPlayer.Position = new Vector3(0, 0, 0);

        client = await StreamingHubClient.ConnectAsync<IRealTimeTest, IRealTimeTestReserver>(channel, this);
        var roomPlayers = await client.JoinAsync(roomName, userName);

        foreach(var player in roomPlayers)
        {
            (this as IRealTimeTestReserver).OnJoin(player);
        }

        return players[userName];
    }

    public ValueTask AppearPlayersAsync()
    {
        if (client == null) return new ValueTask();

        return client.AppearPlayersAsync();
    }

    public ValueTask Empty()
    {
        if (client == null) return new ValueTask();

        return client.Empty();
    }


    public ValueTask MoveAsync(Vector3 position)
    {
        if (client == null) return new ValueTask();
        return client.MoveAsync(position);
    }

    public ValueTask LeaveAsync(string userName)
    {
        return client.LeaveAsync();
    }

    public Task DisposeAsync()
    {
        return client.DisposeAsync();
    }

    void IRealTimeTestReserver.OnJoin(Player player)
    {
        Debug.Log("Join:" + player.Name);

        players[player.Name] = player;
    }

    void IRealTimeTestReserver.OnLeave(Player player)
    {
        Debug.Log("Leave:" + player.Name);//退出したプレイヤー以外で実行される
    }

    void IRealTimeTestReserver.OnMove(Player player)
    {
        Debug.Log(player.Name + ":" +  player.Position);
    }

    void IRealTimeTestReserver.OnAppear(Player[] players)
    {
        foreach(var player in players)
        {
            if(ownPlayer.Name == player.Name)
            {
                Debug.Log(player.Position);
            }
        }
    }
}
