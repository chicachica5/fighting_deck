using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;

    private float velocity = 7.0f;
    private float jumpPower = 400.0f;
    private bool canJump = true;

    private float mov;

    void Update()
    {
        mov = Input.GetAxis("Horizontal");

        if(Input.GetButtonDown("Jump") && canJump) 
        {
            Jump();
        }

        Move();
    }

    void Jump() 
    {
        canJump = false;
        rb.AddForce(Vector2.up * jumpPower);
    }

    void Move() 
    {
        transform.Translate(velocity * Vector2.right * mov * Time.deltaTime);
    }

     void OnTriggerEnter2D(Collider2D other) 
    {
        canJump = true;
    }
}
