using Photon.Pun;
using UnityEngine;

public class OnlinePaddleController : MonoBehaviour
{
    private PaddleController masterPaddle;
    private PaddleController slavePaddle;

    private bool isMaster;

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
}
