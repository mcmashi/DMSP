using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour {

    LineRenderer beam;

    BoxCollider2D boxCollider2D;

    Vector3 beamposition;

    private GameObject Boss;

    private Transform bossP;

    float bTime;

    //ビームの幅の増加率
    private float rate;

    // Use this for initialization
    void Start () {
        beam = this.gameObject.GetComponent<LineRenderer>();

        boxCollider2D = this.gameObject.GetComponent<BoxCollider2D>();

        Boss = GameObject.Find("Boss_stage3");

        rate = 0.1f;

        beam.startWidth = rate;
        beam.endWidth = rate;

        boxCollider2D.size = new Vector2(rate, 10.0f);

        boxCollider2D.offset = new Vector2(-0.21f,-5.42f);

        //２秒後削除
        Destroy(gameObject,2.0f);

    }
	
	// Update is called once per frame
	void Update () {

        //ビームの始点
        beam.SetPosition(0,new Vector3(-0.2f, -0.5f, 0));

        //ビームの終点
        beamposition = new Vector3(-0.2f,-10.0f,0);
        beam.SetPosition(1,beamposition);

        bTime += Time.deltaTime;

        //ビームの放出
        if (bTime <= 1.0f)
        {

            if (rate >= 0.3f)
            {
                beam.startWidth = 0.3f;
                beam.endWidth = 0.3f;
            }
            else{
                rate += 0.01f;
                beam.startWidth = rate;
                beam.endWidth = rate;
            }

        }
        else if(bTime >= 1.0f)
        {
            if (rate <= 0.0f)
            {
                beam.startWidth = 0.0f;
                beam.endWidth = 0.0f;
            }else{
                rate -= 0.01f;
                beam.startWidth = rate;
                beam.endWidth = rate;
            }

        }
        else if (bTime >= 2.0f){


        }

        //当たり判定をビームの幅に合わせる
        boxCollider2D.size = new Vector2(rate, 10.0f);


    }
}
