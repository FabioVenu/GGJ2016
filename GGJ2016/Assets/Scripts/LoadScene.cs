using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    
    public void LoadLevel(string Level)
    {
           SceneManager.LoadScene(Level);
    }
}
