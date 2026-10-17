using UnityEngine;
public class NPCHorizontalMove : MonoBehaviour
{

    private float speed = 2f; // Speed of the NPC movement

    private float contadorTiempo = 0;
    private float tiempoParaCambiar = 2f;

    Vector3 direction;

    void Start()
    {
        direction = new Vector3(1, 0, 0);
    }

    private void Update()
    {
        UpdateDirection();
        UpdateMovement();
    }

    private void UpdateDirection()
    {
        contadorTiempo += Time.deltaTime;

        if (contadorTiempo >= tiempoParaCambiar)
        {
            contadorTiempo = 0f; // Reset the timer
            speed = -speed; // Reverse the direction of movement   
        }
    }
    private void UpdateMovement()
    {
        transform.Translate((direction * speed * Time.deltaTime));
    }
}