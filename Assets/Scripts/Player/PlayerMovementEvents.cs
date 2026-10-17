using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementEvents : MonoBehaviour
{
    PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    //public void OnMove(InputValue value)
    //{
    //    Debug.Log("On move: " + value.Get<Vector2>());
    //    playerMovement.movementInput = value.Get<Vector2>();
    //}

    public void OnMoveHorizontal(InputValue value)
    {
        playerMovement.movementInput = value.Get<float>();
    }

    public void OnJump(InputValue value)
    {
        if (value.isPressed)
        {
            playerMovement.Jump();
        }
    }
}
