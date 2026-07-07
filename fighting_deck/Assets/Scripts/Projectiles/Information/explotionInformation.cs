using UnityEngine;

public class ExplotionInformation : BaseInformation
{
    int damage = 1;
    int explosionDamage = 2;

    public override void ApplyInformation() 
    {
        gameObject.GetComponent<ProjectileExplosionHit>().AssignDamage(damage, explosionDamage);
    }
}
