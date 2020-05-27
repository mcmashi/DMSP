using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour {

    LineRenderer beam;

    BoxCollider2D boxCollider2D;

    Vector3 bposition;



    // Use this for initialization
    void Start () {
        beam = this.gameObject.GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        bposition.y -= 0.5f;



        beam.SetPosition(1,bposition);
		
	}
}
