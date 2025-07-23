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
        Debug.Log("入力された番号: " + currentInput);
        Debug.Log("正解の番号: " + correctCode);

        if(currentInput == correctCode)
        {
            Debug.Log("正解！");

            IsOpen = true;
            
        }
        else
        {
            Debug.Log("不正解");
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
            Debug.Log("※ドアがまだ設定されていません！");
        }
    }
}
