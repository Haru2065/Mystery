using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[�̊�{������Ǘ����Ă���X�N���v�g
/// �C�x���g�n�ȊO�̑���������ɏ���
/// </summary>
public class PlayerConfig : MonoBehaviour
{
    private PushableObject nearChair = null;

    [SerializeField]
    [Tooltip("�v���C���[�̑���X�N���v�g")]
    private PlayerMove playerMove;

    /// <summary>
    /// playerMove����߂��̈֎q�����󂯎��
    /// </summary>
    /// <param name="chair">�֎q</param>
    public void SetNearChair(PushableObject chair)
    {
        nearChair = chair;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if (!playerMove.IsOnChair() && nearChair != null)
            {
                playerMove.SitOnChair(nearChair);
            }

            else if(playerMove.IsOnChair())
            {
                playerMove.GetOffChair();
            }
        }
        
        // �v���C���[���߂��ɂ��āAE�L�[����������擾
        if (ItemPocket.Instance.IsPlayerNear)
        {
           if(Input.GetKeyDown(KeyCode.E))
           {
                ItemPocket.Instance.PickUpItem();
           }
        }
    }
}
