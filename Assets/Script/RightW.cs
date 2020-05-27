using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightW : MonoBehaviour {

    [SerializeField] int RHP = 100;

    public bool brokeR = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (RHP <= 0)
        {
            RHP = 0;
            brokeR = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PB")
        {
            RHP--;
        }
    }
}
