using App.Reversi.Shared;
using Cysharp.Net.Http;
using Grpc.Net.Client;
using MagicOnion.Client;
using UnityEngine;

public class CallTest : MonoBehaviour
{
    void Start()
    {
        Call();
    }

    private async void Call()
    {
        var handler = new YetAnotherHttpHandler();
        handler.Http2Only = true;
        var options = new GrpcChannelOptions { HttpHandler = handler, UnsafeUseInsecureChannelCallCredentials = false };
        var channel = GrpcChannel.ForAddress("http://localhost:5000", options);
        var client = MagicOnionClient.Create<IMyFirstService>(channel);
        var result = await client.SumAsync(1, 2);
        Debug.Log($"Result: {result}");
        await channel.ShutdownAsync();
    }
}
