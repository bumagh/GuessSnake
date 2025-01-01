using UnityEngine;

public class Snake : MonoBehaviour
{
    public string snakeName;  // 蛇的名字（例如 "蛇1", "蛇2" 或网络热梗）
    public Vector2 moveDirection;  // 蛇的移动方向
    public float moveSpeed = 2f;  // 蛇的移动速度
    private Vector2 startPosition;  // 初始位置
    private bool isOver = false;
    public float exchangeRate { get; internal set; }

    private GameObject hideGo;
    private SpriteRenderer spriteRenderer;
    // 初始化
    void Awake()
    {
        hideGo = transform.Find("Hide").gameObject;
        spriteRenderer = transform.Find("Image").GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        startPosition = transform.position;

    }

    public void SetSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }
    // 每帧更新蛇的位置
    void Update()
    {
        if (transform.position.y >= -3)
            MoveSnake();
        else
        {
            if (isOver == false)
            {
                HideSnake(true);
                isOver = true;

            }
        }

    }

    public void HideSnake(bool hide)
    {
        hideGo.SetActive(hide);
    }
    // 移动蛇
    void MoveSnake()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    // 随机改变蛇的方向（用于交换）
    public void ChangeDirection(Vector2 newDirection)
    {
        moveDirection = newDirection;
    }

    // 重置蛇的位置
    public void ResetPosition()
    {
        transform.position = startPosition;
    }
}
