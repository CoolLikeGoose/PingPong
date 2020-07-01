using Photon.Pun;
using UnityEngine;

public class OnlinePaddleController : MonoBehaviour
{
    private GameObject masterPaddle;
    private GameObject slavePaddle;

    private void Start()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate("PaddleMP", new Vector2(-8.3f, 0), Quaternion.identity);
        }
        else
        {
            PhotonNetwork.Instantiate("PaddleMP", new Vector2(8.3f, 0), Quaternion.identity);
        }
    }
}
