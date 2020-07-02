using Photon.Pun;
using System;
using UnityEngine;

public class OnlinePaddleController : MonoBehaviour
{
    public static OnlinePaddleController Instance { get; private set; }

    [NonSerialized] public PaddleController masterPaddle;
    [NonSerialized] public PaddleController slavePaddle;

    private bool isMaster;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        isMaster = OnlineGameController.Instance.isMaster;

        if (isMaster)
        {
            masterPaddle = PhotonNetwork.Instantiate("PaddleMP", new Vector2(-8.3f, 0), Quaternion.identity).GetComponent<PaddleController>();
        }
        else
        {
            slavePaddle = PhotonNetwork.Instantiate("PaddleMP", new Vector2(8.3f, 0), Quaternion.identity).GetComponent<PaddleController>();
        }
    }

    private void Update()
    {
        float movement = Input.GetAxis("Vertical");

        if (isMaster) { masterPaddle.Move(movement); }
        else { slavePaddle.Move(movement); }
    }

    public void NewRound()
    {
        if (isMaster) { masterPaddle.ResetPostition(); }
        else { slavePaddle.ResetPostition(); }
    }
}
