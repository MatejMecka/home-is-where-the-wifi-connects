using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class redirectToGame : MonoBehaviour
{

	float timerZaDaProcitash;
    public float limitZaDaProcitash = 40f;

	void Update(){
		if(timerZaDaProcitash > limitZaDaProcitash){
            SceneManager.LoadScene("Scene1", LoadSceneMode.Single);
        }

        timerZaDaProcitash += Time.deltaTime;
	}
}
