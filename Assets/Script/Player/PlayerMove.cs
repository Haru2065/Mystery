using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// プレイヤーの操作スクリプト
/// </summary>
public class PlayerMove : PlayerManager
{

    [SerializeField]
    [Tooltip("グリッド移動サイズ")]
    public float gridSize;

    [SerializeField]
    [Tooltip("当たり判定スクリプト")]
    private MapHitManager hitManager;

    [SerializeField]
    [Tooltip("プレイヤーのコンフィグ")]
    private PlayerConfig playerConfig;

    //近くにある椅子
    private PushableObject nearChair;

    //椅子に乗る前のポジションを記録
    private Vector3 StartPosition;

    private bool isOnChair;

    //移動できるか
    private bool isMoving;

    /// <summary>
    /// 移動できるかのゲッターセッター
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

        // 入力取得（WASD/矢印/ゲームパッド）
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(moveX) > 0) moveY = 0;

        Vector2 inputDir = new Vector2(moveX, moveY);

        // 毎フレームチェックするように変更
        Vector3 forwardCheckPos = transform.position + (Vector3)(transform.up * gridSize);
        IsEventAction = hitManager.IsEventTile(forwardCheckPos);

        if (inputDir != Vector2.zero)
        {
            //入力した方向を上にする
            transform.up= inputDir.normalized;

            Vector3 checkPos = transform.position + (Vector3)(inputDir.normalized * gridSize);

            // 実際の移動処理
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
    /// 椅子から降りる処理
    /// </summary>
    public void GetOffChair()
    {
        if(!isOnChair) return;

        transform.position = StartPosition;

        isOnChair = false;
    }

    /// <summary>
    /// 今椅子に乗っているか
    /// </summary>
    /// <returns>乗っているかのフラグ</returns>
    public bool IsOnChair()
    {
        return isOnChair;
    }

    /// <summary>
    /// 壁がない状態で歩けるかのチェックするメソッド
    /// </summary>
    /// <param name="dir"></param>
    private void TryMove(Vector2 dir)
    {
        //プレイヤーの当たり判定を位置から設定
        Vector3 playerTargetPos = transform.position + (Vector3)(dir * gridSize);

        // 椅子などの押せるオブジェクトがあるか確認
        PushableObject pushable = hitManager.GetMovableObjectAt(playerTargetPos);

        if (pushable != null)
        {
            Vector3 pushTargetPos = playerTargetPos + (Vector3)(dir * gridSize);

            // 椅子を押せる条件：その先に壁や他の椅子がないこと
            if (!hitManager.IsWall(pushTargetPos) && !hitManager.IsMovableObject(pushTargetPos))
            {
                pushable.TryPush(dir, hitManager);
            }

            //プレイヤーはその場で止まる
            return;
        }

        //もし壁があればプレイヤーは動けないようにする
        if (hitManager.IsWall(playerTargetPos) ||hitManager.IsEventTile(playerTargetPos))return;

        //プレイヤーの移動コールチンを開始
        StartCoroutine(Move(transform, playerTargetPos));
    }

    //プレイヤーのみ移動させるコールチン
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