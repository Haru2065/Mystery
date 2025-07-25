using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPassWordAction : MonoBehaviour
{
    [SerializeField]
    [Tooltip("ライティングを制御するスクリプト")]
    private LightController lightController;

    [SerializeField]
    [Tooltip("数字型パスワードスクリプト")]
    private NumberLock numberLock;


    // ライトを暗くしたかどうかのフラグ
    private bool isDarkened = false;

    /// <summary>
    /// １回だけ実行
    /// もし、パスワード解除されたら周りを暗くする
    /// </summary>
    private void Update()
    {
        if (numberLock.IsOpen && !isDarkened)
        {
            lightController.setDark();
            isDarkened = true;
        }
    }
}
