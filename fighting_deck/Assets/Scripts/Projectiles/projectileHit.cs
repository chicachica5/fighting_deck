using System.Collections.Generic;

using UnityEngine;

public class ProjectileHit : MonoBehaviour
{
    private float damage = 1;
    private HashSet<string> damageableTags = new HashSet<string>() 
    { 
        "Player", 
        "Enemy", 
    };

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(gameObject.name);
        if(damageableTags.Contains(other.tag))
        {
            other.gameObject.GetComponent<EntityHealth>().TakeDamage(damage);
        }

        Destroy(gameObject);
    }

    public void AssignDamage(float dmg)
    {
        damage = dmg;
    }
}
