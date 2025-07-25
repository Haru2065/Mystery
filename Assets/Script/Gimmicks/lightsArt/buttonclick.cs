using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class buttonclick : MonoBehaviour
{
    //どのbuttonか照合するID
    int buttonID;
    //ライトの点灯消灯の判別につかう
    bool[] lightOn;
    //取得したボタンを格納する
    List<GameObject> buttons;
    //成功したら表示するオブジェクト
    public GameObject isClear;

    void Start()
    {
        //buttonを入れた親オブジェクトを取得
        GameObject area = GameObject.FindGameObjectWithTag("area");
        //buttonを入れるlist
        buttons = new List<GameObject>();
        //listに1個ずつボタンを加える
        for (int i = 0; i < area.transform.childCount; i++)
        {
            //Getchild(0),Getchild(1)…とGameObjectをリスト化
            buttons.Add(area.transform.GetChild(i).gameObject);
        }

        //ボタンの消灯・転倒を判断するbool,ボタンと同じ数だけほしいのでListの数を取得する.Countを使う
        lightOn = new bool[buttons.Count];

        //ボタンの点灯消灯bool初期化と、それぞれのボタンのゲームオブジェクトに
        //クリックしたときに行う自前のメソッドをaddlistnerで取り付け
        for (int i = 0; i < buttons.Count; i++)
        {
            //すべてのボタンを消灯
            lightOn[i] = false;
            buttons[i].AddComponent<Button>();
            //引数付きAddListenerについてのやり方
            var count = i;
            // ローカル変数を引数にする
            buttons[i].GetComponent<Button>().onClick.AddListener(() => Push_Button(count));  
        }
    }

    // Update is called once per frame
    void Update()
    {
        //ボタンの色を変えるメソッド
        buttoncolor();
        //クリアしたかチェックする
        clearcheck();
    }


    //int型の引数numberを宣言
    //押したボタンに応じてほかのライトも点灯消灯する（buttonruleで行う）
    public void Push_Button(int num)
    {
        //押したボタンのIDを確認
        //引数の数値を代入
        buttonID = num;

        //各々のbuttonを押したときのruleでboolを変えてclearしたかチェック
        buttonrule();
    }


    //ライツアウトの部分
    public void buttonrule()
    {
        //3*3の場合のそれぞれのボタンを押したときの条件
        //左上
        if (buttonID == 0)
        {
            lightOn[0] = !lightOn[0];
            lightOn[1] = !lightOn[1];
            lightOn[3] = !lightOn[3];
        }
        //上
        if (buttonID == 1)
        {
            lightOn[0] = !lightOn[0];
            lightOn[1] = !lightOn[1];
            lightOn[2] = !lightOn[2];
            lightOn[4] = !lightOn[4];
        }
        //右上
        if (buttonID == 2)
        {
            lightOn[1] = !lightOn[1];
            lightOn[2] = !lightOn[2];
            lightOn[5] = !lightOn[5];
        }
        //左
        if (buttonID == 3)
        {
            lightOn[0] = !lightOn[0];
            lightOn[3] = !lightOn[3];
            lightOn[4] = !lightOn[4];
            lightOn[6] = !lightOn[6];
        }
        //真ん中
        if (buttonID == 4)
        {
            lightOn[1] = !lightOn[1];
            lightOn[3] = !lightOn[3];
            lightOn[4] = !lightOn[4];
            lightOn[5] = !lightOn[5];
            lightOn[7] = !lightOn[7];
        }
        //右
        if (buttonID == 5)
        {
            lightOn[2] = !lightOn[2];
            lightOn[4] = !lightOn[4];
            lightOn[5] = !lightOn[5];
            lightOn[8] = !lightOn[8];
        }
        //左下
        if (buttonID == 6)
        {
            lightOn[3] = !lightOn[3];
            lightOn[6] = !lightOn[6];
            lightOn[7] = !lightOn[7];
        }
        //下
        if (buttonID == 7)
        {
            lightOn[4] = !lightOn[4];
            lightOn[6] = !lightOn[6];
            lightOn[7] = !lightOn[7];
            lightOn[8] = !lightOn[8];
        }
        //右下
        if (buttonID == 8)
        {
            lightOn[5] = !lightOn[5];
            lightOn[7] = !lightOn[7];
            lightOn[8] = !lightOn[8];
        }
    }

    //ボタンの色を変える
    void buttoncolor()
    {
        //boolがfalseかtrueかで色変え
        for (int i = 0; i < buttons.Count; i++)
        {
            //i番目のボタンが消灯の場合
            if (!lightOn[i])
            {
                //消灯時の色
                buttons[i].GetComponent<Image>().color = new Color32(150, 150, 150, 125);
            }
            //i番目のボタンが点灯の場合
            else
            {
                //点灯時の色
                buttons[i].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            }
        }
    }

    //クリアしたら文字を表示させてクリアを伝える
    public void clearcheck()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            //どれか一つでもbuttonのboolがfalseだったらclearではなく、returnで終了
            if (!lightOn[i])
            {
                isClear.SetActive(false);
                return;
            }
            //結果すべてがtrueなら、clear文字表示
            isClear.SetActive(true);

        }
    }
}