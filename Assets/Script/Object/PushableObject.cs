using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// 椅子など動かせるオブジェクトの処理
/// </summary>
public class PushableObject : MonoBehaviour
{
    [SerializeField]
    [Tooltip("移動するグリッドサイズ")]
    private float gridSize;

    [SerializeField]
    [Tooltip("移動速度")]
    private float moveSpeed;

    //移動できるか
    private bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
    }

    /// <summary>
    /// 椅子を移動できるか
    /// </summary>
    /// <param name="direction"></param>
    /// <param name="hitManager"></param>
    /// <returns></returns>
    public bool TryPush(Vector2 direction, MapHitManager hitManager)
    {
        if(isMoving) return false;

        Vector3 targetPos = transform.position + (Vector3)(direction * gridSize);

        // 行き先が壁や別の椅子なら押せない
        if (hitManager.IsWall(targetPos) || hitManager.IsMovableObject(targetPos)) return false;

        //椅子移動コールチン
        StartCoroutine(MoveTo(targetPos));

        return true;
    }

    /// <summary>
    /// 移動処理
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    private IEnumerator MoveTo(Vector3 target)
    {
        isMoving = true;

        Vector3 start = transform.position;

        float time = 0f;

        float duration = gridSize / moveSpeed;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(start, target, time / duration);

            time += Time.deltaTime;

            yield return null;
        }

        transform.position = target;

        isMoving = false;
    }
}
