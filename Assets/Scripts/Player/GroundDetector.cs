using UnityEngine;

[RequireComponent (typeof(BoxCollider2D))]
public class GroundDetector : MonoBehaviour
{
    PlayerMovement playerMovement;

    private void Start()
    {
        //playerMovement = transform.root.GetComponent<PlayerMovement>();
        playerMovement = GetComponentInParent<PlayerMovement> ();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            playerMovement.isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            playerMovement.isGrounded = false;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            Debug.Log("Estoy groundeando");
        }
    }
}
