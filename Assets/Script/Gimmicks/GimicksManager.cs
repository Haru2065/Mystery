using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ギミックのマネージャー
/// </summary>
public class GimicksManager : MonoBehaviour
{
    //ギミックマネージャーのインスタンス
    private static GimicksManager instance;

    /// <summary>
    /// インスタンスのゲッターセッター
    /// </summary>
    public static GimicksManager Instance
    {
        get => instance;
    }

    [SerializeField, Tooltip("ギミックのゲームオブジェクト")]
    public List<GameObject> gimickObjects = new List<GameObject>();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
