using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    public GameObject Pause;
    bool IsPaused = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("escape")){


            if (!IsPaused){

                IsPaused = true;
                Pause.gameObject.SetActive(true);


                //Time.Instance
                //Fermo il Timer
                //Blocco il movimento dei giocatori
                //Blocco le abilità di fantasma
                //Abilito la GUI del menù

            }
            else{

                IsPaused = false;
                Pause.gameObject.SetActive(false);
                //Time.Instance

            }
        }

    }
}
