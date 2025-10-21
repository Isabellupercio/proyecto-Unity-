using UnityEngine;

public class JohnMovement : MonoBehaviour
{

    void Start()
    {

    }
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
    }
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal, Rigidbody2D.velocity.y);
        
    }
}
