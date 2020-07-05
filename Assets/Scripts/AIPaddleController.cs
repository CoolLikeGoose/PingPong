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
        if (ball.transform.position.y > RightPaddle.transform.position.y) { rightPaddleController.Move(1f); }
        else { rightPaddleController.Move(-1f); }
    }
}
