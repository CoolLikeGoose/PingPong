using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnlineGameController : MonoBehaviour//, IPunObservable
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

    /*
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext((Vector2)BallObj.transform.position);
        }
        else
        {
            BallObj.transform.position = (Vector2)stream.ReceiveNext();
        }
    }
    */
}
