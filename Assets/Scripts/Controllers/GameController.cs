using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    public float paddleSpeed;
    public float ballSpeed;

    public PaddleController paddleL;
    public PaddleController paddleR;
    public BallController ball;

    //For PvE
    private PaddleController currentPaddle;

    public Text StartGamePopup;

    private bool isGameStarted = false;
    private bool isNowPvE = false;

    /// <summary>
    /// 0 - L player, 1 - R player
    /// </summary>
    private int[] scores;

    private void Awake()
    {
        Instance = this;
        scores = new int[2] { 0, 0 };
    }

    private void Start()
    {
        StartCoroutine(StartGame());

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByBuildIndex(3))
        {
            isNowPvE = true;
            currentPaddle = paddleL;
        }
    }

    private void Update()
    {
        if (isNowPvE)
        {
            currentPaddle.Move(Input.GetAxis("Vertical"));
            return;
        }
        //TODO: delete this if (like a ball by Pause method)
        if (isGameStarted)
        {
            paddleL.Move(Input.GetAxis("LeftPaddle"));
            paddleR.Move(Input.GetAxis("RightPaddle"));
        }
    }

    private IEnumerator StartGame()
    {
        ball.GetComponent<BallController>().PauseState(true);
        StartGamePopup.gameObject.SetActive(true);

        for (int i = 3; i != 0; i--)
        {
            StartGamePopup.text = i.ToString();

            yield return new WaitForSeconds(1);
        }

        StartGamePopup.text = "GO!";

        yield return new WaitForSeconds(0.5f);

        isGameStarted = true;
        StartGamePopup.gameObject.SetActive(false);
        ball.GetComponent<BallController>().PauseState(false);
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
