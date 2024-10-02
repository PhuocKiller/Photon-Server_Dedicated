using Fusion;
using Fusion.Sockets;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public abstract class NetworkLauncher : MonoBehaviour, INetworkRunnerCallbacks
{
    NetworkRunner runner;
    NetworkSceneManagerDefault sceneManager;
    [SerializeField]
    GameObject cube;
    private void Awake()
    {
        runner=GetComponent<NetworkRunner>();
        sceneManager= GetComponent<NetworkSceneManagerDefault>();
    }
    protected async Task StartServer(string roomName, ushort port, string ip=null )
    {
        runner.AddCallbacks(this);
        await runner.StartGame(new StartGameArgs
        {
            GameMode = GameMode.Server,
            SessionName = roomName,
            SceneManager = sceneManager,
            //Address = ip == null ? NetAddress.Any(port) : NetAddress.CreateFromIpPort(ip, port)
            Address = NetAddress.Any()
        });
    }
    private void OnDestroy()
    {
        runner.RemoveCallbacks(this);
    }

    public void OnPlayerJoined(NetworkRunner runner, PlayerRef player)
    {
        runner.Spawn(cube, inputAuthority: player);
        Debug.Log( $"player join: {player.PlayerId} is join" );
    }

    public void OnPlayerLeft(NetworkRunner runner, PlayerRef player)
    {
        Debug.Log($"player left: {player.PlayerId} is left");
    }
    #region
    public void OnInput(NetworkRunner runner, NetworkInput input)
    {
       
    }

    public void OnInputMissing(NetworkRunner runner, PlayerRef player, NetworkInput input)
    {
       
    }

    public void OnShutdown(NetworkRunner runner, ShutdownReason shutdownReason)
    {
       
    }

    public void OnConnectedToServer(NetworkRunner runner)
    {
       
    }

    public void OnDisconnectedFromServer(NetworkRunner runner)
    {
       
    }

    public void OnConnectRequest(NetworkRunner runner, NetworkRunnerCallbackArgs.ConnectRequest request, byte[] token)
    {
       
    }

    public void OnConnectFailed(NetworkRunner runner, NetAddress remoteAddress, NetConnectFailedReason reason)
    {
       
    }

    public void OnUserSimulationMessage(NetworkRunner runner, SimulationMessagePtr message)
    {
       
    }

    public void OnSessionListUpdated(NetworkRunner runner, List<SessionInfo> sessionList)
    {
       
    }

    public void OnCustomAuthenticationResponse(NetworkRunner runner, Dictionary<string, object> data)
    {
       
    }

    public void OnHostMigration(NetworkRunner runner, HostMigrationToken hostMigrationToken)
    {
       
    }

    public void OnReliableDataReceived(NetworkRunner runner, PlayerRef player, ArraySegment<byte> data)
    {
       
    }

    public void OnSceneLoadDone(NetworkRunner runner)
    {
       
    }

    public void OnSceneLoadStart(NetworkRunner runner)
    {
       
    }
    #endregion
}
