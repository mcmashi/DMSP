using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pad : MonoBehaviour {

    //タッチ情報取得
    Touch touch;

    //パッドUIの取得
    public GameObject padCircle;

    GameObject pad;


    RectTransform padCircletransform;
    RectTransform padtransform;



    // Use this for initialization
    void Start () {
        pad = padCircle.gameObject.transform.Find("Pad").gameObject;
        padCircletransform = padCircle.GetComponent<RectTransform>();
        padtransform = pad.GetComponent<RectTransform>();
        //表示off
        padCircle.gameObject.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {
        //プレイヤが破壊されていれば
        if (GameObject.Find("Player") == null)
        {
            padCircle.gameObject.SetActive(false);
            return;
        }

        //タッチされているか
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            padCircle.gameObject.SetActive(true);

            Vector2 LocalBasepad = new Vector2(0.0f,0.0f);


            //タッチはじめ
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    padCircletransform.position = touch.position;
                    LocalBasepad = touch.position;



                    break;

                    //タッチ中
                case TouchPhase.Moved:

                    //タッチ始点からの差分
                    Vector2 localpad = -(LocalBasepad - touch.position)/40.0f;

                    //中央値を25~-25にする
                    localpad += new Vector2(-22.5f,-22.5f);



                    //パッドサークルに収める補正

                    if (localpad.x > 0)
                    {
                        localpad.x = Mathf.Min(localpad.x, 25.0f);
                    }
                    else if (localpad.x < 0)
                    {
                        localpad.x = Mathf.Max(localpad.x, -25.0f);

                    }

                    if (localpad.y > 0)
                    {
                        localpad.y = Mathf.Min(localpad.y, 25.0f);
                    }
                    else if (localpad.y < 0)
                    {
                        localpad.y = Mathf.Max(localpad.y, -25.0f);

                    }

                    //ワールド座標で子の座標位置を代入
                    padtransform.position = padCircletransform.TransformPoint(localpad);



                    break;



                default:


                    break;


            }
        }
        else
        {
            padCircle.gameObject.SetActive(false);
        }

    }


}
