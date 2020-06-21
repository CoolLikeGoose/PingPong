using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    public float paddleSpeed;
    public float ballSpeed;

    public PaddleController paddleL;
    public PaddleController paddleR;
    public BallController ball;

    /// <summary>
    /// 0 - L player, 1 - R player
    /// </summary>
    private int[] scores;

    private void Awake()
    {
        Instance = this;
        scores = new int[2] { 0, 0 };
    }   

    private void Update()
    {
        paddleL.Move(Input.GetAxis("LeftPaddle"));
        paddleR.Move(Input.GetAxis("RightPaddle"));
    }

    public IEnumerator GameOver(string goalName)
    {
        int playerNumber;
        if (goalName == "GoalR") { scores[0]++; playerNumber = 1; }
        else { scores[1]++; playerNumber = 2; }

        UIController.Instance.UpdatedScores(scores, playerNumber);

        yield return new WaitForSeconds(1f);

        UIController.Instance.TurnGameOverPopup();
        ball.ResetPostition();
        paddleL.ResetPostition();
        paddleR.ResetPostition();
    }
}
