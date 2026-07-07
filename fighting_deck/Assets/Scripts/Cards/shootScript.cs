using UnityEngine;

public class shootScript : MonoBehaviour
{
    private Transform aimPosition;
    private Transform playerPosition;
    public GameObject bulletPrefab;
    GameObject bullet;

    private Vector3 dir;

    public void Shoot() 
    {
        aimPosition = GameObject.Find("testCardsAim").transform;
        playerPosition = GameObject.Find("Player").transform;
        dir = aimPosition.position - playerPosition.position;

        bullet = Instantiate(bulletPrefab, aimPosition.position, Quaternion.identity);
        bullet.GetComponent<ProjectileMovement>().changeDirection(dir);
        bullet.GetComponent<BaseInformation>().ApplyInformation();

        NotifyTheAuthorities();
    }

    void NotifyTheAuthorities() 
    {
        DeckScriptBase deck = GameObject.Find("DeckManager").GetComponent<DeckScriptBase>();
        deck.AddToDiscarded(gameObject);
    }
}