using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despacito : MonoBehaviour
{

	KeyCode[] konamicode;
	int index = 0;

	AudioSource cameraAudio;
    public AudioClip despacitoClip;

    // Start is called before the first frame update
    void Awake(){
    	cameraAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    	 if (index == 0 && Input.GetKeyDown(KeyCode.UpArrow)){
    	 	print("FIRST UP");
    	 	index++;
 		 }

 		if (Input.GetKeyDown(KeyCode.UpArrow) && index == 1 ){
 		 	print("SECOND UP");
    	 	index++;
 		 }

 		if (Input.GetKey(KeyCode.DownArrow) && index == 2 ){
 		 	print("FIRST DOWN");
    	 	index++;
 		 }

 		if (Input.GetKey(KeyCode.DownArrow) && index == 3 ){
 			print("SECOND DOWN");
    	 	index++;
 		 }

 		if (Input.GetKeyDown(KeyCode.LeftArrow) && index == 4 ){
 			print("FIRST LEFT");
    	 	index++;
 		}

 		if (Input.GetKeyDown(KeyCode.LeftArrow) && index == 5 ){
 			print("SECOND LEFT");
    	 	index++;
 		}

 		if (Input.GetKeyDown(KeyCode.RightArrow) && index == 6 ){
 			print("FIRST RIGHT");
    	 	index++;
 		}

 		if (Input.GetKeyDown(KeyCode.RightArrow) && index == 7 ){
 			print("SECOND RIGHT");
    	 	index++;
 		}


 		if (Input.GetKeyDown(KeyCode.A) && index == 8 ){
 			print("A PRESS");
    	 	index++;
 		}

 		if (Input.GetKeyDown(KeyCode.B) && index == 9 ){
 			print("DESPACITO TIME");
 			cameraAudio.clip = despacitoClip;
    		cameraAudio.Play();
 		}

    }

}
