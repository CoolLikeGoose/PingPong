using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject paddle;

    public float paddleSpeed;
    public float ballSpeed;

    [NonSerialized] public Vector2 topRight;
    [NonSerialized] public Vector2 bottomLeft;

    private PaddleController paddleL;
    private PaddleController paddleR;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        bottomLeft = Camera.main.ScreenToWorldPoint(Vector2.zero);

        Instantiate(ball);

        paddleR = Instantiate(paddle, new Vector2(topRight.x - paddle.transform.localScale.x, 0), Quaternion.identity).GetComponent<PaddleController>();
        paddleL = Instantiate(paddle, new Vector2(bottomLeft.x + paddle.transform.localScale.x, 0), Quaternion.identity).GetComponent<PaddleController>();
    }

    private void Update()
    {
        paddleL.Move(Input.GetAxis("LeftPaddle"));
        paddleR.Move(Input.GetAxis("RightPaddle"));
    }
}
