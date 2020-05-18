using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_Wave : MonoBehaviour {

    public GameObject enrobAobj;

    private GameObject InstanceenrobA;

    //ウェーブの順番
    private int wcount = 0; 

    //0:何も無い　1:雑魚敵A
    //ウェーブ01
    //----------------------------
    private int[,] Wave1= new int[5,9]{
        {1,0,1,0,1,0,1,0,1},
        {0,0,0,0,0,0,0,0,0},
        {0,0,1,0,1,0,1,0,0},
        {0,0,0,0,0,0,0,0,0},
        {0,0,0,0,1,0,0,0,0}

    };

    public float TimeOut = 10.0f;

    private float ewTime = 0.0f;

    //画面内の左上座標を格納
    float camx = 0.0f;
    float camy = 0.0f;


	// Use this for initialization
	void Start () {
        //カメラ内の左上を基準にして敵が出現する為、左上の座標を取得。
        var mainCamera = Camera.main;
        var top = mainCamera.ViewportToWorldPoint(new Vector3(0.0f, 1.0f, 0.0f));
        camx = top.x;
        camy = top.y;
    }
	
	// Update is called once per frame
	void Update () {
        //一定時間でウェーブが始まる。
        ewTime += Time.deltaTime;

        if(ewTime >= TimeOut){
            wcount++;

            ewTime = 0.0f;
            switch(wcount){
                case 1:
                    WaveDraw(Wave1);

                    break;


            }



        }

		
	}


    int WaveDraw(int[,] wave){
        //ウェーブを作る。
        for (int i = 0; i < 5; i++)
        {

            for (int j = 0; j < 9; j++)
            {
                //最初の一体目のx座標が左端の座標+zeropointになる。
                float zeropoint = 0.4f;
                //space分x座標をずらして敵を配置。
                float spacex = j * 0.6f;
                //space分y座標をずらして敵を配置。
                float spacey = i * 0.6f;

                switch (wave[i, j]){
                    case 1:
                        InstanceenrobA = (GameObject)Instantiate(enrobAobj, new Vector3(spacex + camx + zeropoint, 5 - spacey + camy, 0), Quaternion.identity);
                        break;

                }
            }


        }


        return 0;
    }
}