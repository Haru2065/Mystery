using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

/// <summary>
/// ����̃C�x���g�Ń}�b�v���Â��Ȃ�X�N���v�g
/// </summary>
public class LightController : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�}�b�v���Â������薾�邭���郉�C�g")]
    private Light2D globalLight;

    /// <summary>
    ///�@�O���[�o�����C�g�𖾂邭���郁�\�b�h
    /// </summary>
    public void SetBright()
    {
        globalLight.intensity = 1f;
    }

    /// <summary>
    /// �O���[�o�����C�g���Â����郁�\�b�h
    /// </summary>
    public void setDark()
    {
        globalLight.intensity = 0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        //�ŏ��͖��邢��Ԃɂ���
        SetBright();
    }

    // Update is called once per frame
    //�f�o�b�N�p
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
