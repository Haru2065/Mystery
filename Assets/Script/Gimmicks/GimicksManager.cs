using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �M�~�b�N�̃}�l�[�W���[
/// </summary>
public class GimicksManager : MonoBehaviour
{
    //�M�~�b�N�}�l�[�W���[�̃C���X�^���X
    private static GimicksManager instance;

    /// <summary>
    /// �C���X�^���X�̃Q�b�^�[�Z�b�^�[
    /// </summary>
    public static GimicksManager Instance
    {
        get => instance;
    }

    [SerializeField, Tooltip("�M�~�b�N�̃Q�[���I�u�W�F�N�g")]
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
