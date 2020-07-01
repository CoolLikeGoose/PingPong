using Photon.Pun;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnlineGameController : MonoBehaviour
{
    public static OnlineGameController Instance { get; private set; }

    public GameObject ball;

    public float paddleSpeed;
    public float ballSpeed;

    [NonSerialized] public bool isMaster;

    private GameObject BallObj;

    private void Awake()
    {
        Instance = this;
        isMaster = PhotonNetwork.IsMasterClient;
    }

    private void Start()
    {
        if (isMaster) { BallObj =  PhotonNetwork.Instantiate("BallMP", Vector3.zero, Quaternion.identity); }
    }

    public void OnMenuBtn()
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene(0);
    }
}
