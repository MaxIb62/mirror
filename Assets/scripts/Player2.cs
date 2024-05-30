using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    float vel = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float MoveH = Input.GetAxis("Horizontal");
        float MoveV = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(MoveH, 0.0f, MoveV);

        // Normaliza el vector de movimiento para que la velocidad sea constante en todas las direcciones
        if (movement.magnitude > 1)
        {
            movement = movement.normalized;
        }

        // Mueve el personaje
        transform.Translate(movement * vel * Time.deltaTime, Space.World);
    }
}
