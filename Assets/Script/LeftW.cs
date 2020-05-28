using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftW : MonoBehaviour {

    [SerializeField] int LHP = 100;

    public bool brokeL = false;

    [SerializeField] GameObject Boss;

    Boss_stage3 sbo;

	// Use this for initialization
	void Start () {
        sbo = Boss.GetComponent<Boss_stage3>();
		
	}
	
	// Update is called once per frame
	void Update () {
        if(LHP <= 0){
            LHP = 0;
            brokeL = true;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.gameObject.tag =="PB"){
            if(sbo.enter)LHP--;
            Destroy(other.gameObject);
        }
    }

}
