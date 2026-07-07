using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    int ShootCD = 120;
    
    private Transform player;

    public GameObject bulletPrefab; 
    GameObject bullet;

    int counter;

    void Start() 
    {
        player =  GameObject.Find("Player").GetComponent<Transform>();
        ShootCD = Random.Range(120, 240);
        counter = ShootCD;
    }

    void Update()
    {
        counter--;

        if(counter == 0) {
            Shoot();
            counter = ShootCD;
        }
    }

    void Shoot() 
    {
        Vector3 dir = player.position - gameObject.transform.position;
        dir.Normalize();

        bullet = Instantiate(bulletPrefab, gameObject.transform.position + dir, Quaternion.identity);

   

        bullet.GetComponent<ProjectileMovement>().changeDirection(dir);
    }
}
