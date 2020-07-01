using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnlineGameController : MonoBehaviour
{
    public static OnlineGameController Instance { get; private set; }

    public GameObject ball;

    public float paddleSpeed;
    public float ballSpeed;

    private GameObject BallObj;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if (PhotonNetwork.IsMasterClient) { BallObj =  PhotonNetwork.Instantiate("BallMP", Vector3.zero, Quaternion.identity); }
    }

    public void OnMenuBtn()
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene(0);
    }
}
