using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    Transform playerPos;
    float cameraDepth = -15;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerPos = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = playerPos.position;
        temp.z = cameraDepth;
        gameObject.transform.position = temp;
    }
}
