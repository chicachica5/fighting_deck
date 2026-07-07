using UnityEngine;

public class AimMovement : MonoBehaviour
{
    private Vector3 mousePos;
    [SerializeField] Transform playerPos;
    [SerializeField] Camera cam;

    void Update()
    {
        mousePos = GetMousePoint();

        SetPos();
    }
    
    private void SetPos()
    {
        Vector3 dir = mousePos - playerPos.position;
        dir.Normalize();

        dir *= 1.5f;
        Vector3 finalPos = playerPos.position + dir;
        gameObject.transform.position = finalPos;
    }

    private Vector3 GetMousePoint() 
    {
        Vector3 worldPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        worldPoint.z = 0;
        return worldPoint;
    }
}
