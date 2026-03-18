using UnityEngine;

public class MovementCharacter : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 5f;    
    public float jumpForce = 5f;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public float lowMultiplier = 0.5f;
    public float fallMultiplier = 2.5f;
    public float coyoteTime = 0.2f;
    private float coyoteTimeCounter;
    public float prebuffTime = 0.2f;
    private float prebuffTimeCounter;
    public bool jumping;


    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(xInput * speed, rb.linearVelocity.y);

        // Prebuffer: registra intención de salto
        if (Input.GetButtonDown("Jump"))
            prebuffTimeCounter = prebuffTime;
        else
            prebuffTimeCounter -= Time.deltaTime;

        // Coyote time: guarda tiempo desde que dejó el suelo
        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime; // ✅ Se llena cuando está en suelo
            jumping = false;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime; // ✅ Se vacía al estar en el aire
        }

        // Salto: prebuffer + coyote time combinados
        if (prebuffTimeCounter > 0 && coyoteTimeCounter > 0 && !jumping)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0); // ✅ Resetea velocidad vertical
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumping = true;
            coyoteTimeCounter = 0;  // ✅ Evita doble salto
            prebuffTimeCounter = 0;
        }
    }
    public bool IsGrounded()
    {
        
        return Physics2D.OverlapCircle(groundCheck.position, 
        groundCheckRadius, LayerMask.GetMask("Ground"));
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
