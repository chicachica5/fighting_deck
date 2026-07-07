using UnityEngine;

public class BallScript : CardScript
{
    private Transform aimPosition;
    private Transform playerPosition;
    public GameObject bulletPrefab;
    GameObject bullet;

    private Vector3 dir;
    private float damage = 5.0f;

    public void Shoot() 
    {
        aimPosition = GameObject.Find("testCardsAim").transform;
        playerPosition = GameObject.Find("Player").transform;
        dir = aimPosition.position - playerPosition.position;

        bullet = Instantiate(bulletPrefab, aimPosition.position, Quaternion.identity);
        bullet.GetComponent<ProjectileMovement>().changeDirection(dir);
        bullet.GetComponent<ProjectileHit>().AssignDamage(damage);

        NotifyTheAuthorities();
    }

    void NotifyTheAuthorities() 
    {
        DeckScriptBase deck = GameObject.Find("DeckManager").GetComponent<DeckScriptBase>();
        deck.AddToDiscarded(gameObject);
    }
}
