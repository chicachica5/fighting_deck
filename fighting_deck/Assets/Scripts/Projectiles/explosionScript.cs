using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    private float deltaTimeModifier = 1.5f;

    void Update()
    {
        Resize();

        if(gameObject.transform.localScale.x >= 6.0f) 
        {
            Destroy(gameObject);
        }
    }

    private void Resize() {
        Vector3 vec = new Vector3(Time.deltaTime, Time.deltaTime, 0) * deltaTimeModifier;
        gameObject.transform.localScale += vec;
    }
}
