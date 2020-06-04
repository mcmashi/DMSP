using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEController : MonoBehaviour {

    public AudioClip audioex;

    AudioSource audiosource;


	// Use this for initialization
	void Start () {
        audiosource = this.GetComponent<AudioSource>();
		
	}
	
	// Update is called once per frame
	void Update () {

            
        		
	}

    public void exSE(){

        audiosource.PlayOneShot(audioex, 0.4f);

    }
}
