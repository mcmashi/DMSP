using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour {

    Animator eanima;

    //SE
    public AudioClip exse;
    AudioSource exaudio;

	// Use this for initialization
	void Start () {
        eanima = GetComponent<Animator>();

        this.exaudio = GetComponent<AudioSource>();
        exaudio.PlayOneShot(exse,0.6f);

    }
	
	// Update is called once per frame
	void Update () {
        //endステートに入ったら消す。爆発の後消える。
        bool endcheck = eanima.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.end");

        if (endcheck)
        {
            Destroy(this.gameObject);


        }

		
	}
}
