using UnityEngine;

public class PlayerMovement : MonoBehaviour

{

    public float movementInput;

    [SerializeField] private float jumpForce;

    public bool isGrounded = true;

    [SerializeField] private float speed;

    float yVelocity;

    Rigidbody2D rb;

    Health playerHealth;

    Animator playerAnimator;

    SpriteRenderer spriteRenderer;

    [SerializeField] GameObject attackHitbox;

    Vector3 attackHitboxStartingPosition;

    CapsuleCollider2D playerCollider;

    Vector2 playerColliderStartingOffset;

    private void Start()

    {

        rb = GetComponent<Rigidbody2D>();

        playerHealth = GetComponent<Health>();

        playerAnimator = GetComponent<Animator>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        playerCollider = GetComponent<CapsuleCollider2D>();

        attackHitboxStartingPosition = attackHitbox.transform.localPosition;

        playerColliderStartingOffset = playerCollider.offset;

    }

    private void Update()

    {

        UpdateWalkingAnimation();

        UpdateJumpAnimation();

    }

    private void FixedUpdate()

    {

        if (playerHealth.IsVulnerable && !playerAnimator.GetBool("isAttacking"))

        {

            rb.linearVelocity = new Vector3(movementInput * speed, rb.linearVelocity.y, 0);

        }

    }

    public void Jump()

    {

        if (isGrounded)

        {

            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);

            playerAnimator.SetBool("isJumping", true);

        }

    }

    public void StopJumping()

    {

        playerAnimator.SetBool("isJumping", false);

    }

    public void Attack()

    {

        if (isGrounded)

        {

            playerAnimator.SetBool("isAttacking", true);

            rb.linearVelocityX = 0;

        }

    }

    public void StopAttacking()

    {

        playerAnimator.SetBool("isAttacking", false);

    }

    public void UpdateJumpAnimation()

    {

        yVelocity = rb.linearVelocity.y;

        if (yVelocity == 0)

        {

            yVelocity = -0.01f;

        }

        playerAnimator.SetFloat("yVelocity", yVelocity);

    }

    public void UpdateWalkingAnimation()

    {

        if (movementInput != 0)

        {

            //ANDA

            playerAnimator.SetBool("isWalking", true);

            if (movementInput > 0)

            {

                //DERECHA

                spriteRenderer.flipX = false;

                attackHitbox.transform.localPosition = attackHitboxStartingPosition;

                playerCollider.offset = playerColliderStartingOffset;

            }

            else

            {

                //IZQUIERDA

                spriteRenderer.flipX = true;

                attackHitbox.transform.localPosition =

                    new Vector3(-attackHitboxStartingPosition.x, attackHitboxStartingPosition.y, attackHitboxStartingPosition.z);

                playerCollider.offset =

                    new Vector2(-playerColliderStartingOffset.x, playerColliderStartingOffset.y);

            }

        }

        else

        {

            //NO ANDES

            playerAnimator.SetBool("isWalking", false);

        }

    }

}

