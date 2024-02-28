using Grpc.Net.Client;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Connect : MonoBehaviour
{
    private  RealTimeTestClient testClient;

    public string userName;
    public Vector3 position;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    async void Update()
    {
        if (testClient == null) return;

        await testClient.MoveAsync(this.transform.position);
    }

    public async void ConnectToServer()
    {
        testClient = new RealTimeTestClient();
        await testClient.ConnectAsync("Room", userName, position);
    }

    private async void OnApplicationQuit()
    {
        await testClient.LeaveAsync(userName);
        await testClient.DisposeAsync();
        Debug.Log("DisConnect");
    }

    public async void AppearPlayers()
    {
        await testClient.AppearPlayersAsync();
    }

    public async void NullCheck()
    {
        Debug.Log("NullCheck");
        if(testClient == null)
        {
            Debug.Log("testClient null!");
        }
    }

    public async void Empty()
    {
        await testClient.Empty();
    }
}
