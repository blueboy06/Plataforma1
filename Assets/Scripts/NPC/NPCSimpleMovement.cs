using UnityEngine;

namespace SimpleMovement
{
    public enum SimpleMovementTypes
    {
        Horizontal,
        Vertical,
        Diagonal
    }
    public class NPCSimpleMovement : MonoBehaviour
    {
        [Header("Movement Times")]
        [SerializeField] private float speed = 2f; // Speed of the NPC movement
        
        private float contadorTiempo = 0;
        [SerializeField] private float tiempoParaCambiar = 2f;

        Rigidbody2D rb;
        Vector3 direction;
        [Header("Movement Direction")]
        [SerializeField] SimpleMovementTypes movementType;
        [SerializeField][Range(-1, 1)] private float startingDirection = 1;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            rb = GetComponent<Rigidbody2D>();

            switch (movementType)
            {
                case SimpleMovementTypes.Horizontal:
                    direction = new Vector3(1, 0, 0); //Vector3.right
                    rb.gravityScale = 1;
                    break;
                case SimpleMovementTypes.Vertical:
                    direction = new Vector3(0, 1, 0); //Vector3.up
                    rb.gravityScale = 0;
                    break;
                case SimpleMovementTypes.Diagonal:
                    direction = new Vector3(1, 1, 0); 
                    rb.gravityScale = 0;
                    break;
            }

            direction *= startingDirection; // direction = direction * startingDirection;
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
}

