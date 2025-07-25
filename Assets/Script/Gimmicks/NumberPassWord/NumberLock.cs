using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NumberLock : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�p�X���[�h���X�g")]
    private List<Button> passWordButtonList;

    [SerializeField]
    [Tooltip("�G���^�[�{�^��")]
    private Button enterButton;

    [SerializeField]
    [Tooltip("���Z�b�g�{�^��")]
    private Button resetbutton;

    [SerializeField]
    [Tooltip("�p�X���[�h���͉��")]
    private GameObject passWordWindow;


    private string currentInput = "";
    private string correctCode = "1234";


    //�{�^�����󂢂���
    public bool IsOpen { get; private set; }


    private void Start()
    {
        IsOpen = false;
        
        enterButton.onClick.AddListener(() => Submit());

        for (int i = 0; i < passWordButtonList.Count; i++)
        {
            int index = i;
            passWordButtonList[i].onClick.AddListener(() => AddDigit(index.ToString()));
        }

        resetbutton.onClick.AddListener(() => ResetInput());
    }

    /// <summary>
    /// ����{�^���̎��s
    /// </summary>
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            passWordWindow.SetActive(false);
        }
    }

    public void AddDigit(string digit)
    {
        if(currentInput.Length < 4)
        {
            currentInput += digit;
        }
    }

    public void Submit()
    {
        Debug.Log("���͂��ꂽ�ԍ�: " + currentInput);
        Debug.Log("�����̔ԍ�: " + correctCode);

        if(currentInput == correctCode)
        {
            Debug.Log("�����I");

            IsOpen = true;

            passWordWindow.SetActive(false);
        }
        else
        {
            Debug.Log("�s����");
            currentInput = "";
        }
    }

    void ResetInput()
    {
        currentInput =  "";
    }
}
