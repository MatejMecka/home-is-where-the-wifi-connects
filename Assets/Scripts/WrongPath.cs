using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WrongPath : MonoBehaviour
{
    float timerZaDaProcitash;
    public float limitZaDaProcitash = 20f;

    AudioSource playerAudio;
    public AudioClip deathClip;


    void Start()
    {
        playerAudio.clip = deathClip;
        print("PLAYERAUDIO: " + playerAudio);
        playerAudio.Play();
    }

    void Update(){
        print("TIMER ZA DA PROCITASH:" + timerZaDaProcitash);
        if(timerZaDaProcitash > limitZaDaProcitash){
            SceneManager.LoadScene("Scene1", LoadSceneMode.Single);
        }

        timerZaDaProcitash += Time.deltaTime;

    }


}
