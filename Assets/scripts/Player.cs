using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player : NetworkBehaviour
{
    [SyncVar (hook =nameof(OnHolaCountChange))]
    int HolaCount = 0;

    
    void HandleMovement()
    {
        if(isLocalPlayer)
        {
            float MoveH = Input.GetAxis("Horizontal");
            float MoveV = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(MoveH * 0.1f, MoveV * 0.1f, 0);
            transform.position = transform.position + movement;
        }
    }
    private void Update()
    {
        HandleMovement();

        if (isLocalPlayer && Input.GetKeyDown(KeyCode.X)) ;
        {
            Hola();
        }
        if (isServer && transform.position.y > 5) 
        {
            TooHigh();
        }
    }
    [Command]

    void Hola()
    {
        Debug.Log("recibe un saludo desde cliente");
        HolaCount += 1;
        ReplayHola();
    }

    [ClientRpc]
    void TooHigh()
    {
        Debug.Log("andas demasiado alto");
    }

    [TargetRpc]
    void ReplayHola()
    {
        Debug.Log("recibe un hola desde el servidor");
    }


    void OnHolaCountChange(int oldCount, int newCount)
    {
        Debug.Log($"teniamos {oldCount} holas, ahora tenemos {newCount} holas");
    }
}
