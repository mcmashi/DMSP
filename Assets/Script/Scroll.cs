using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour {

    public float speed = -0.1f;

    public float scrollz = 0.1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate( 0, speed, 0);
        if (transform.position.y < -10f)
        {
            transform.position = new Vector3( 0, 0, scrollz);
        }
    }
}
