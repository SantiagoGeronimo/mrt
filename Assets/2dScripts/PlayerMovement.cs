using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    
    private bool isFacingRight = true;

    private bool canDash = true;
    private bool isDashing = false;
    private float dashingPower = 18f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    [SerializeField] private float speed;
    [SerializeField] private float jumpingPower;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private SaveAndReset saveAndReset;
    [SerializeField] private TrailRenderer tr;

    public bool bouncing = false;

    void Start()
    {
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

        if (isDashing)
        {
            return; 
        }

        if (bouncing)
        {
            return;
        }

        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

        Flip();
    }

    private void GoToLastReset()
    {
        gameObject.transform.position = saveAndReset.GetSavedPosition();
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(groundCheck.position, 0.2f);
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
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

    public void PlayerDeath()
    {
        GoToLastReset();
    }


}