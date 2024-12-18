using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private bool isFacingRight = true;

    public bool canDash { get; private set; }
    public bool isDashing = false;

    private bool isWallSliding;

    [SerializeField] private PlayerDataSO playerData;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private SaveAndReset saveAndReset;
    [SerializeField] private TrailRenderer tr;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;

    public bool bouncing = false;

    void Start()
    {
        canDash = true;
        if (saveAndReset != null)
        {
            saveAndReset.SavePosition(this.gameObject.transform.position);
        }
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            saveAndReset.SavePosition(this.gameObject.transform.position);
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            GoToLastReset();
        }

        if (isDashing || bouncing)
        {
            return;
        }

        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, playerData.jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

        WallSlide();
        Flip();
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        // Control del movimiento horizontal
        if (!isWallSliding) // Solo se mueve en el eje X si no está resbalando
        {
            rb.velocity = new Vector2(horizontal * playerData.speed, rb.velocity.y);
        }
    }

    private bool IsWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }

    private void WallSlide()
    {
        if (IsWalled() && !IsGrounded())
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y - 0.1f, -playerData.wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
        }
    }
    private void GoToLastReset()
    {
        gameObject.transform.position = saveAndReset.GetSavedPosition();
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(groundCheck.position, 0.2f);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(wallCheck.position, 0.2f);
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * playerData.dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(playerData.dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(playerData.dashingCooldown);
        canDash = true;
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void OnApplicationQuit()
    {
        transform.parent = null;
    }

    public void PlayerDeath()
    {
        GoToLastReset();
    }
}