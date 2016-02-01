using UnityEngine;
using System.Collections;

public class PreferenceControllerKeyb : MonoBehaviour {

    bool IsControllerEnabled;

    void Update()
    {
        IsControllerEnabled = ControlliSwitch.IsControllerEnabled;
    }

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

}
