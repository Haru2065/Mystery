using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// マップの当たり判定を管理するマネージャー(壁など）
/// </summary>
public class MapHitManager : MonoBehaviour
{
    [SerializeField]
    [Tooltip("壁のタイルマップ")]
    private List<Tilemap> HitTileMap;

    [SerializeField]
    [Tooltip("イベントタイルのタイルマップ")]
    private List<Tilemap> eventTileMap;

    [SerializeField]
    [Tooltip("移動可能オブジェクト")]
    private List<Transform> movableObjects;

    /// <summary>
    /// 指定したワールド座標が壁かどうかを判定。
    /// </summary>
    /// <param name="targetWorldPos">判定するワールド座標</param>
    /// <returns>壁であれば true、それ以外は false</returns>
    public bool IsWall(Vector3 targetWorldPos)
    {
        Vector3Int cellPos = Vector3Int.FloorToInt(targetWorldPos);

        foreach (var tilemap in HitTileMap)
        {
            if (tilemap.HasTile(cellPos))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// イベント時(動かないタイルに使用）
    /// </summary>
    /// <param name="targetWorldPos"></param>
    /// <returns></returns>
    public bool IsEventTile(Vector3 targetWorldPos)
    {
        foreach (var tilemap in eventTileMap)
        {
            Vector3Int cellPos = tilemap.WorldToCell(targetWorldPos);

            if (tilemap.HasTile(cellPos))
            {
                return true;
            }
        }

        return false;
    }
    
    /// <summary>
    /// イベントタイルマップから特定のタイルを消去
    /// </summary>
    /// <param name="tilemap"></param>

    public void RemoveEventTileMap(Tilemap tilemap)
    {
        eventTileMap.Remove(tilemap);
    }

    /// <summary>
    /// :指定位置に移動可能なオブジェクト（椅子など）が存在するかどうか
    /// </summary>
    /// <param name="targetWorldPos"></param>
    /// <returns></returns>
    public bool IsMovableObject(Vector3 targetWorldPos)
    {
        Vector3Int targetCell = Vector3Int.FloorToInt(targetWorldPos);

        foreach (var obj in movableObjects)
        {
            Vector3Int objCell = Vector3Int.FloorToInt(obj.position);
            if (objCell == targetCell)
            {
                return true;
            }
        }

        return false;
    }


    /// <summary>
    /// 指定位置にある移動可能なオブジェクトを取得する
    /// </summary>
    /// <param name="targetWorldPos"></param>
    /// <returns></returns>
    public PushableObject GetMovableObjectAt(Vector3 targetWorldPos)
    {
        Vector3Int targetCell = Vector3Int.FloorToInt(targetWorldPos);

        foreach (var obj in movableObjects)
        {
            if (Vector3Int.FloorToInt(obj.position) == targetCell)
            {
                return obj.GetComponent<PushableObject>();
            }
        }

        return null;
    }
}
