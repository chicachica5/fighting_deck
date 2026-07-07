using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    private Vector3 direction;
    private float velocity = 2f;
    
    void Update()
    {
        Move();
    }

    private void Move() 
    {
        transform.Translate(direction * velocity * Time.deltaTime);
    }

    public void changeDirection(Vector3 dir)
    {
        direction = dir;
    }

    public void changeVelocity(float vel)
    {
        velocity = vel;
    }
}
