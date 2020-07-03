using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OnlineGameController : MonoBehaviour, IOnEventCallback
{
    public static OnlineGameController Instance { get; private set; }

    public GameObject ball;

    public float paddleSpeed;
    public float ballSpeed;

    public Text firstPlayerNickname;
    public Text secondPlayerNickname;

    [NonSerialized] public bool isMaster;

    private GameObject BallObj;

    private int[] scores;

    private void Awake()
    {
        scores = new int[2] { 0, 0 };


        Instance = this;
        isMaster = PhotonNetwork.IsMasterClient;
    }

    private void Start()
    {
        if (isMaster)
        {
            BallObj = PhotonNetwork.Instantiate("BallMP", Vector3.zero, Quaternion.identity);

            firstPlayerNickname.text = PhotonNetwork.NickName;
        }
        else
        {
            secondPlayerNickname.text = PhotonNetwork.NickName;
        }
    }

    public void OnMenuBtn()
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene(0);
    }

    public IEnumerator GameOver(string goalName)
    {
        int playerNumber;
        if (goalName == "GoalR") { scores[0]++; playerNumber = 1; }
        else { scores[1]++; playerNumber = 2; }

        UIController.Instance.UpdatedScores(scores, playerNumber);

        yield return new WaitForSeconds(1f);

        UIController.Instance.TurnGameOverPopup();

        //TODO: fix that sht
        if (BallObj != null) { BallObj.GetComponent<BallController>().ResetPostition(); }

        OnlinePaddleController.Instance.NewRound();

        RaiseEventOptions options1 = new RaiseEventOptions { Receivers = ReceiverGroup.All };
        SendOptions options2 = new SendOptions { Reliability = true };
        PhotonNetwork.RaiseEvent(5, true, options1, options2);
    }

    public void OnEvent(EventData photonEvent)
    {
        switch (photonEvent.Code)
        {
            case 5:
                OnlinePaddleController.Instance.NewRound();
                break;
        }
    }
}
