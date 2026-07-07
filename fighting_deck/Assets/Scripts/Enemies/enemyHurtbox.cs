using UnityEngine;

public class EnemyHurtbox : MonoBehaviour
{
    [SerializeField] EnemyHealth Hp;
    
    void OnTriggerEnter2D(Collider2D other) {

        if(other.tag == "Player")
        {
            //Temporal, debemos crear un sistema para enviar daño aun
            //Hp.TakeDamage(5.0f); 
        }
    }
}
