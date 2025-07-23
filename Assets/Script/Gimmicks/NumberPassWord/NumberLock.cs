using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NumberLock : MonoBehaviour
{
    [SerializeField]
    private List<Button> passWordButtonList;

    public GameObject door;

    [SerializeField]
    private Button enterButton;


    private string currentInput = "";
    private string correctCode = "1234";

    public bool IsOpen;


    private void Start()
    {
        IsOpen = false;
        
        enterButton.onClick.AddListener(() => Submit());

        for (int i = 0; i < passWordButtonList.Count; i++)
        {
            int index = i;
            passWordButtonList[i].onClick.AddListener(() => AddDigit(index.ToString()));
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
            
        }
        else
        {
            Debug.Log("�s����");
            currentInput = "";
        }
    }

    void OpenDoor()
    {
        if(door != null)
        {
            door.transform.position += new Vector3(0, 2, 0);
        }
        else
        {
            Debug.Log("���h�A���܂��ݒ肳��Ă��܂���I");
        }
    }
}
