using UnityEngine;

public class ExplosionHit : MonoBehaviour
{
    private float damage = 1;

    void OnTriggerEnter2D(Collider2D other) {

        if(other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
        else if(other.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
        }

        //Does not destroy, but only hurts on enter
    }

    public void AssignDamage(float dmg)
    {
        damage = dmg;
    }
}
