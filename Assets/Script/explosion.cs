using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour {

    Animator eanima;

    //爆発のSE鳴らす
    private GameObject SEController;

    SEController secscript;

	// Use this for initialization
	void Start () {
        eanima = GetComponent<Animator>();
        SEController = GameObject.Find("exSE");
        secscript = SEController.GetComponent<SEController>();
        secscript.exSE();
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
