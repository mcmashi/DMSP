using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyGage : MonoBehaviour {


    GameObject Player;

    Player script;

    private Image ENImage;

	// Use this for initialization
	void Start () {

        ENImage = this.GetComponent<Image>();
        //プレイヤーの情報取得してから、そのスクリプトのエネルギーの値にアクセスする。
        Player = GameObject.Find("Player");
        script = Player.GetComponent<Player>();
		
	}
	
	// Update is called once per frame
	void Update () {
        //エネルギーゲージの制御
        ENImage.fillAmount = 0.75f * (script.energy / 1000.0f);
    }
}
