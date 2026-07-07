using UnityEngine;

public class ProjectileExplosionHit : MonoBehaviour
{
    public GameObject explosionPrefab;
    GameObject explosion;

    private float damage;
    private float explosionDamage;

    void OnTriggerEnter2D(Collider2D other) {

        if(other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(0);
        }
        else if(other.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(0);
        }

        //Create explosion prefab
        explosion = Instantiate(explosionPrefab, gameObject.transform.position, Quaternion.identity);
        explosion.GetComponent<ExplosionHit>().AssignDamage(explosionDamage);
        Destroy(gameObject);
    }

    public void AssignDamage(float dmg, float expDmg)
    {
        damage = dmg;
        explosionDamage = expDmg;
    }
}
