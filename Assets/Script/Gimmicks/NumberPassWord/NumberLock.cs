using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NumberLock : MonoBehaviour
{
    [SerializeField]
    [Tooltip("パスワードリスト")]
    private List<Button> passWordButtonList;

    [SerializeField]
    [Tooltip("エンターボタン")]
    private Button enterButton;

    [SerializeField]
    [Tooltip("リセットボタン")]
    private Button resetbutton;

    [SerializeField]
    [Tooltip("パスワード入力画面")]
    private GameObject passWordWindow;


    private string currentInput = "";
    private string correctCode = "1234";


    //ボタンが空いたか
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
    /// 閉じるボタンの実行
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
        Debug.Log("入力された番号: " + currentInput);
        Debug.Log("正解の番号: " + correctCode);

        if(currentInput == correctCode)
        {
            Debug.Log("正解！");

            IsOpen = true;

            passWordWindow.SetActive(false);
        }
        else
        {
            Debug.Log("不正解");
            currentInput = "";
        }
    }

    void ResetInput()
    {
        currentInput =  "";
    }
}
