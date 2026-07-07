using UnityEngine;

public class EntityHealth : MonoBehaviour
{
    // Can be changed in unity
    [SerializeField] float hp = 10.0f; 
    protected void CheckHp()
    {
        Debug.Log(hp);
        if(hp <= 0)
        {
            Debug.Log("DEAD"); //Leave the popUp for now NO LO TOQUES LIU YA VA BIEN TENER ESTO DE MOMENTO
            Destroy(gameObject);
        }        
    }

    public void TakeDamage(float dmg)
    {
        hp -= dmg;
        CheckHp();
    }

    public float GetHealth()
    {
        return hp;   
    }
}
