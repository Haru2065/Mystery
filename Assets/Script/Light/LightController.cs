using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

/// <summary>
/// 特定のイベントでマップが暗くなるスクリプト
/// </summary>
public class LightController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("マップを暗くしたり明るくするライト")]
    private Light2D globalLight;

    /// <summary>
    ///　グローバルライトを明るくするメソッド
    /// </summary>
    public void SetBright()
    {
        globalLight.intensity = 1f;
    }

    /// <summary>
    /// グローバルライトを暗くするメソッド
    /// </summary>
    public void setDark()
    {
        globalLight.intensity = 0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        //最初は明るい状態にする
        SetBright();
    }

    // Update is called once per frame
    //デバック用
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            setDark();

            
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            SetBright();
        }
    }
}
