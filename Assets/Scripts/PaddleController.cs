using Photon.Pun;
using UnityEngine;

public class PaddleController : MonoBehaviour
{

    private float speed;

    private Vector3 startPosition;
    private void Start()
    {
        //TODO: fix that TWICE
        if (GameController.Instance == null)
        {
            speed = OnlineGameController.Instance.paddleSpeed;

            //what am doing with my life?
            PhotonView pv = GetComponent<PhotonView>();

            string nickname = pv.Owner.NickName;
            bool isMIne = pv.IsMine;
            bool isMaster = OnlineGameController.Instance.isMaster;

            if (isMaster && isMIne)
            {
                OnlineGameController.Instance.firstPlayerNickname.text = nickname;
            }
            else if (isMaster && !isMIne)
            {
                OnlineGameController.Instance.secondPlayerNickname.text = nickname;
            }
            else if (!isMaster && isMIne)
            {
                OnlineGameController.Instance.secondPlayerNickname.text = nickname;
            }
            else
            {
                OnlineGameController.Instance.firstPlayerNickname.text = nickname;
            }

        }
        else
        {
            speed = GameController.Instance.paddleSpeed;
        }

        startPosition = transform.position;
    }

    public void Move(float moveFactor)
    {
        transform.Translate(new Vector2(0, moveFactor * Time.deltaTime * speed));

        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, -3.5f, 3.5f));
    }

    public void ResetPostition()
    {
        transform.position = startPosition;
    }
}