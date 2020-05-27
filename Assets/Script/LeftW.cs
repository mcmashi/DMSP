using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftW : MonoBehaviour {

    [SerializeField] int LHP = 100;

    public bool brokeL = false;

	// Use this for initialization
	void Start () {
		
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
            LHP--;
        }
    }

}
