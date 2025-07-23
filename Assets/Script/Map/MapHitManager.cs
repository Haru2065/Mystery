using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// �}�b�v�̓����蔻����Ǘ�����}�l�[�W���[(�ǂȂǁj
/// </summary>
public class MapHitManager : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�ǂ̃^�C���}�b�v")]
    private List<Tilemap> HitTileMap;

    [SerializeField]
    [Tooltip("�C�x���g�^�C���̃^�C���}�b�v")]
    private List<Tilemap> eventTileMap;

    [SerializeField]
    [Tooltip("�ړ��\�I�u�W�F�N�g")]
    private List<Transform> movableObjects;

    /// <summary>
    /// �w�肵�����[���h���W���ǂ��ǂ����𔻒�B
    /// </summary>
    /// <param name="targetWorldPos">���肷�郏�[���h���W</param>
    /// <returns>�ǂł���� true�A����ȊO�� false</returns>
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
    /// �C�x���g��(�����Ȃ��^�C���Ɏg�p�j
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
    /// �C�x���g�^�C���}�b�v�������̃^�C��������
    /// </summary>
    /// <param name="tilemap"></param>

    public void RemoveEventTileMap(Tilemap tilemap)
    {
        eventTileMap.Remove(tilemap);
    }

    /// <summary>
    /// :�w��ʒu�Ɉړ��\�ȃI�u�W�F�N�g�i�֎q�Ȃǁj�����݂��邩�ǂ���
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
    /// �w��ʒu�ɂ���ړ��\�ȃI�u�W�F�N�g���擾����
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
