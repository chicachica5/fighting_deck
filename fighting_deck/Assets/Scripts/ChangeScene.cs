using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        if(Input.GetButtonDown("ChangeScene1")) 
        {
            SceneManager.LoadScene(0);
        }
        else if(Input.GetButtonDown("ChangeScene2")) 
        {
            SceneManager.LoadScene(1);
        }
    }
}
