using UnityEngine;

public class GunInformation : BaseInformation
{
    int damage = 8;
    float speed = 7.0f; 
    public override void ApplyInformation() 
    {
        gameObject.GetComponent<ProjectileHit>().AssignDamage(damage);
        gameObject.GetComponent<ProjectileMovement>().changeVelocity(speed);
    }
}
