using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightW : MonoBehaviour {

    [SerializeField] int RHP = 100;

    public bool brokeR = false;

    [SerializeField] GameObject Boss;

    Boss_stage3 sbo;

    // Use this for initialization
    void Start()
    {
        sbo = Boss.GetComponent<Boss_stage3>();
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
            if (sbo.enter) RHP--;
            Destroy(other.gameObject);
        }
    }
}
