using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AnyKeyLevelLoader : MonoBehaviour
{
    void Update()
    {
        if (Input.anyKey)
            SceneManager.LoadScene("Level");
    }  
}
