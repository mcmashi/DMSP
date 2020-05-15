using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate( 0, -0.1f, 0);
        if (transform.position.y < -10f)
        {
            transform.position = new Vector3( 0, 0, 0.1f);
        }
    }
}
