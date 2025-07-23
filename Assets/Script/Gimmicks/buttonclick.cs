using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class buttonclick : MonoBehaviour
{
    //�ǂ�button���ƍ�����ID
    int buttonID;
    //���C�g�̓_�������̔��ʂɂ���
    bool[] lightOn;
    //�擾�����{�^�����i�[����
    List<GameObject> buttons;
    //����������\������I�u�W�F�N�g
    public GameObject isClear;

    void Start()
    {
        //button����ꂽ�e�I�u�W�F�N�g���擾
        GameObject area = GameObject.FindGameObjectWithTag("area");
        //button������list
        buttons = new List<GameObject>();
        //list��1���{�^����������
        for (int i = 0; i < area.transform.childCount; i++)
        {
            //Getchild(0),Getchild(1)�c��GameObject�����X�g��
            buttons.Add(area.transform.GetChild(i).gameObject);
        }

        //�{�^���̏����E�]�|�𔻒f����bool,�{�^���Ɠ����������ق����̂�List�̐����擾����.Count���g��
        lightOn = new bool[buttons.Count];

        //�{�^���̓_������bool�������ƁA���ꂼ��̃{�^���̃Q�[���I�u�W�F�N�g��
        //�N���b�N�����Ƃ��ɍs�����O�̃��\�b�h��addlistner�Ŏ��t��
        for (int i = 0; i < buttons.Count; i++)
        {
            //���ׂẴ{�^��������
            lightOn[i] = false;
            buttons[i].AddComponent<Button>();
            //�����t��AddListener�ɂ��Ă̂���
            var count = i;
            // ���[�J���ϐ��������ɂ���
            buttons[i].GetComponent<Button>().onClick.AddListener(() => Push_Button(count));  
        }
    }

    // Update is called once per frame
    void Update()
    {
        //�{�^���̐F��ς��郁�\�b�h
        buttoncolor();
        //�N���A�������`�F�b�N����
        clearcheck();
    }


    //int�^�̈���number��錾
    //�������{�^���ɉ����Ăق��̃��C�g���_����������ibuttonrule�ōs���j
    public void Push_Button(int num)
    {
        //�������{�^����ID���m�F
        //�����̐��l����
        buttonID = num;

        //�e�X��button���������Ƃ���rule��bool��ς���clear�������`�F�b�N
        buttonrule();
    }


    //���C�c�A�E�g�̕���
    public void buttonrule()
    {
        //3*3�̏ꍇ�̂��ꂼ��̃{�^�����������Ƃ��̏���
        //����
        if (buttonID == 0)
        {
            lightOn[0] = !lightOn[0];
            lightOn[1] = !lightOn[1];
            lightOn[3] = !lightOn[3];
        }
        //��
        if (buttonID == 1)
        {
            lightOn[0] = !lightOn[0];
            lightOn[1] = !lightOn[1];
            lightOn[2] = !lightOn[2];
            lightOn[4] = !lightOn[4];
        }
        //�E��
        if (buttonID == 2)
        {
            lightOn[1] = !lightOn[1];
            lightOn[2] = !lightOn[2];
            lightOn[5] = !lightOn[5];
        }
        //��
        if (buttonID == 3)
        {
            lightOn[0] = !lightOn[0];
            lightOn[3] = !lightOn[3];
            lightOn[4] = !lightOn[4];
            lightOn[6] = !lightOn[6];
        }
        //�^��
        if (buttonID == 4)
        {
            lightOn[1] = !lightOn[1];
            lightOn[3] = !lightOn[3];
            lightOn[4] = !lightOn[4];
            lightOn[5] = !lightOn[5];
            lightOn[7] = !lightOn[7];
        }
        //�E
        if (buttonID == 5)
        {
            lightOn[2] = !lightOn[2];
            lightOn[4] = !lightOn[4];
            lightOn[5] = !lightOn[5];
            lightOn[8] = !lightOn[8];
        }
        //����
        if (buttonID == 6)
        {
            lightOn[3] = !lightOn[3];
            lightOn[6] = !lightOn[6];
            lightOn[7] = !lightOn[7];
        }
        //��
        if (buttonID == 7)
        {
            lightOn[4] = !lightOn[4];
            lightOn[6] = !lightOn[6];
            lightOn[7] = !lightOn[7];
            lightOn[8] = !lightOn[8];
        }
        //�E��
        if (buttonID == 8)
        {
            lightOn[5] = !lightOn[5];
            lightOn[7] = !lightOn[7];
            lightOn[8] = !lightOn[8];
        }
    }

    //�{�^���̐F��ς���
    void buttoncolor()
    {
        //bool��false��true���ŐF�ς�
        for (int i = 0; i < buttons.Count; i++)
        {
            //i�Ԗڂ̃{�^���������̏ꍇ
            if (!lightOn[i])
            {
                //�������̐F
                buttons[i].GetComponent<Image>().color = new Color32(150, 150, 150, 125);
            }
            //i�Ԗڂ̃{�^�����_���̏ꍇ
            else
            {
                //�_�����̐F
                buttons[i].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            }
        }
    }

    //�N���A�����當����\�������ăN���A��`����
    public void clearcheck()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            //�ǂꂩ��ł�button��bool��false��������clear�ł͂Ȃ��Areturn�ŏI��
            if (!lightOn[i])
            {
                isClear.SetActive(false);
                return;
            }
            //���ʂ��ׂĂ�true�Ȃ�Aclear�����\��
            isClear.SetActive(true);

        }
    }
}