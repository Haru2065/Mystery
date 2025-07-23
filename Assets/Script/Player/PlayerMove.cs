using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �v���C���[�̑���X�N���v�g
/// </summary>
public class PlayerMove : PlayerManager
{

    [SerializeField]
    [Tooltip("�O���b�h�ړ��T�C�Y")]
    public float gridSize;

    [SerializeField]
    [Tooltip("�����蔻��X�N���v�g")]
    private MapHitManager hitManager;

    [SerializeField]
    [Tooltip("�v���C���[�̃R���t�B�O")]
    private PlayerConfig playerConfig;

    //�߂��ɂ���֎q
    private PushableObject nearChair;

    //�֎q�ɏ��O�̃|�W�V�������L�^
    private Vector3 StartPosition;

    private bool isOnChair;

    //�ړ��ł��邩
    private bool isMoving;

    /// <summary>
    /// �ړ��ł��邩�̃Q�b�^�[�Z�b�^�[
    /// </summary>
    public bool IsMoving
    {
        get => isMoving;
        set => isMoving = value;
    }

    private void Start()
    {
        isOnChair = false;

        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsMoving || isOnChair) return;

        Vector2 direction = Vector2.zero;

        // ���͎擾�iWASD/���/�Q�[���p�b�h�j
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(moveX) > 0) moveY = 0;

        Vector2 inputDir = new Vector2(moveX, moveY);

        // ���t���[���`�F�b�N����悤�ɕύX
        Vector3 forwardCheckPos = transform.position + (Vector3)(transform.up * gridSize);
        IsEventAction = hitManager.IsEventTile(forwardCheckPos);

        if (inputDir != Vector2.zero)
        {
            //���͂�����������ɂ���
            transform.up= inputDir.normalized;

            Vector3 checkPos = transform.position + (Vector3)(inputDir.normalized * gridSize);

            // ���ۂ̈ړ�����
            TryMove(inputDir);

            Vector3 forwarPos = transform.position + (Vector3)(transform.up * gridSize);
            nearChair = hitManager.GetMovableObjectAt(forwarPos);

            playerConfig.SetNearChair(nearChair);
        }

        
    }

    public void SitOnChair(PushableObject chair)
    {
        if (isOnChair || chair == null) return;

        StartPosition = transform.position;
        transform.position = chair.transform.position;
        
        isOnChair = true;
    }

    /// <summary>
    /// �֎q����~��鏈��
    /// </summary>
    public void GetOffChair()
    {
        if(!isOnChair) return;

        transform.position = StartPosition;

        isOnChair = false;
    }

    /// <summary>
    /// ���֎q�ɏ���Ă��邩
    /// </summary>
    /// <returns>����Ă��邩�̃t���O</returns>
    public bool IsOnChair()
    {
        return isOnChair;
    }

    /// <summary>
    /// �ǂ��Ȃ���Ԃŕ����邩�̃`�F�b�N���郁�\�b�h
    /// </summary>
    /// <param name="dir"></param>
    private void TryMove(Vector2 dir)
    {
        //�v���C���[�̓����蔻����ʒu����ݒ�
        Vector3 playerTargetPos = transform.position + (Vector3)(dir * gridSize);

        // �֎q�Ȃǂ̉�����I�u�W�F�N�g�����邩�m�F
        PushableObject pushable = hitManager.GetMovableObjectAt(playerTargetPos);

        if (pushable != null)
        {
            Vector3 pushTargetPos = playerTargetPos + (Vector3)(dir * gridSize);

            // �֎q������������F���̐�ɕǂ⑼�̈֎q���Ȃ�����
            if (!hitManager.IsWall(pushTargetPos) && !hitManager.IsMovableObject(pushTargetPos))
            {
                pushable.TryPush(dir, hitManager);
            }

            //�v���C���[�͂��̏�Ŏ~�܂�
            return;
        }

        //�����ǂ�����΃v���C���[�͓����Ȃ��悤�ɂ���
        if (hitManager.IsWall(playerTargetPos) ||hitManager.IsEventTile(playerTargetPos))return;

        //�v���C���[�̈ړ��R�[���`�����J�n
        StartCoroutine(Move(transform, playerTargetPos));
    }

    //�v���C���[�݈̂ړ�������R�[���`��
    IEnumerator Move(Transform mover, Vector3 target)
    {
        isMoving = true;

        Vector3 start = mover.position;

        float elapsed = 0f;
        float duration = gridSize / PlayerMoveSpeed;

        while (elapsed < duration)
        {
            mover.position = Vector3.Lerp(start, target, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        mover.position = target;
        isMoving = false;
    }
}