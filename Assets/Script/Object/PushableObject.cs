using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// �֎q�ȂǓ�������I�u�W�F�N�g�̏���
/// </summary>
public class PushableObject : MonoBehaviour
{
    [SerializeField]
    [Tooltip("�ړ�����O���b�h�T�C�Y")]
    private float gridSize;

    [SerializeField]
    [Tooltip("�ړ����x")]
    private float moveSpeed;

    //�ړ��ł��邩
    private bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
    }

    /// <summary>
    /// �֎q���ړ��ł��邩
    /// </summary>
    /// <param name="direction"></param>
    /// <param name="hitManager"></param>
    /// <returns></returns>
    public bool TryPush(Vector2 direction, MapHitManager hitManager)
    {
        if(isMoving) return false;

        Vector3 targetPos = transform.position + (Vector3)(direction * gridSize);

        // �s���悪�ǂ�ʂ̈֎q�Ȃ牟���Ȃ�
        if (hitManager.IsWall(targetPos) || hitManager.IsMovableObject(targetPos)) return false;

        //�֎q�ړ��R�[���`��
        StartCoroutine(MoveTo(targetPos));

        return true;
    }

    /// <summary>
    /// �ړ�����
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    private IEnumerator MoveTo(Vector3 target)
    {
        isMoving = true;

        Vector3 start = transform.position;

        float time = 0f;

        float duration = gridSize / moveSpeed;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(start, target, time / duration);

            time += Time.deltaTime;

            yield return null;
        }

        transform.position = target;

        isMoving = false;
    }
}
