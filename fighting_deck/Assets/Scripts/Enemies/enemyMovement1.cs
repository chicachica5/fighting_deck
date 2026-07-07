using UnityEngine;

public class EnemyMovement1 : MonoBehaviour
{
    private Transform pos;
    private float velocity = 2.0f;

    void Start() 
    {
        pos = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, pos.position, velocity * Time.deltaTime);
    }
}
