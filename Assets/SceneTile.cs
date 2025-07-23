using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneTile : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�V�[���ړ���")]
    private string sceneName;

    // �v���C���[���͈͂ɓ������Ƃ�
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
