using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stock : MonoBehaviour {

    Text stocktext;

    GameObject Player;

    Player pscript;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Player");
        pscript = Player.GetComponent<Player>();

        stocktext = this.gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //残機数を表示
        this.stocktext.text = " × " + pscript.stock;

    }
}
