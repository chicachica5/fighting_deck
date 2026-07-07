using UnityEngine;

public class EnemyMovement2 : MonoBehaviour
{
    private int isRight = 1;
    private float velocity = 1.0f;

    void Update()
    {
        MoveAround();
    }

    void MoveAround()
    {
        transform.Translate(Vector2.right * velocity * isRight * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Wall" || other.tag == "Enemy" || other.tag == "Floor")
        {
            isRight *= -1;
        }
    }
}


