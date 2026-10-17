using UnityEngine;

public class NPCComplexMovement : MonoBehaviour
{
    Vector3 direction;
    [SerializeField] float speed = 8f;
    [SerializeField] float timeToChangeDirection = 2f;
    float timeCounter = 0f;

    int directionCounter;

    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;

        direction = new Vector3(1, -1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        ChangeDirection();
        Movement();
    }

    private void ChangeDirection()
    {
        timeCounter = timeCounter + Time.deltaTime;

        if(timeCounter >= timeToChangeDirection)
        {
            timeCounter = 0;

            //AQUÍ cambio la dirección
            //directionCounter = (directionCounter + 1)%4;

            directionCounter = directionCounter + 1;
            if(directionCounter >= 4)
            {
                directionCounter = 0;
            }

            switch (directionCounter)
            {
                case 0:
                    //Derecha abajo
                    direction = new Vector3(1, -1, 0);
                    break;
                case 1:
                    //Derecha arriba
                    direction = new Vector3(1, 1, 0);
                    break;
                case 2:
                    //Izquierda abajo
                    direction = new Vector3(-1, -1, 0);
                    break;
                default:
                    //Izquierda arriba
                    direction = new Vector3(-1, 1, 0);
                    break;

            }


        }
    }

    private void Movement()
    {
        transform.position = transform.position + direction * speed * Time.deltaTime;
    }
}
