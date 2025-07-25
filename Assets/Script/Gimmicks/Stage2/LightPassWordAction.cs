using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPassWordAction : MonoBehaviour
{
    [SerializeField]
    [Tooltip("���C�e�B���O�𐧌䂷��X�N���v�g")]
    private LightController lightController;

    [SerializeField]
    [Tooltip("�����^�p�X���[�h�X�N���v�g")]
    private NumberLock numberLock;


    // ���C�g���Â��������ǂ����̃t���O
    private bool isDarkened = false;

    /// <summary>
    /// �P�񂾂����s
    /// �����A�p�X���[�h�������ꂽ�������Â�����
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
