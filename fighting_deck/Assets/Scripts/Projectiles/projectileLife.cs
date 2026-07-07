using UnityEngine;

public class ProjectileLife : MonoBehaviour
{
    private int lifeFrames = 1000;

    void Update()
    {
        lifeFrames--;

        if(lifeFrames <= 0) 
        {
            // After 1000 frames or UpdateCalls destroy the object
            // In the future we will have to take account for framerate and all that kind of thing, but for now...
            Destroy(gameObject);
        }
    }
}
