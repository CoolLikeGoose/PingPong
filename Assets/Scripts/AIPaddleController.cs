using UnityEngine;

public class AIPaddleController : MonoBehaviour
{
    [SerializeField] private GameObject ball;

    [SerializeField] private GameObject LeftPaddle;
    [SerializeField] private GameObject RightPaddle;

    private PaddleController leftPaddleController;
    private PaddleController rightPaddleController;

    private void Start()
    {
        leftPaddleController = LeftPaddle.GetComponent<PaddleController>();
        rightPaddleController = RightPaddle.GetComponent<PaddleController>();
    }

    private void Update()
    {
        rightPaddleController.Move(ball.transform.position);
    }
}
