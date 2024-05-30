using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
//using System.Diagnostics;

public class MynetworkManager : NetworkManager
{
    public override void OnStartServer()
    {
        Debug.Log("sevidor iniciado");
    }
    public override void OnStopServer()
    {
        Debug.Log("servidor detenido");
    }
    public override void OnClientConnect()
    {
        base.OnClientConnect();
        Debug.Log("cliente conectado al servidor");
    }
    public override void OnClientDisconnect()
    {
        base.OnClientDisconnect();
        Debug.Log("cliente desconectado desde el servidor");
    }
}
