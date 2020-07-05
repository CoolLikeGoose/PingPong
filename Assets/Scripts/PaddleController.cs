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
            bool isMine = pv.IsMine;
            bool isMaster = OnlineGameController.Instance.isMaster;

            if (isMaster == isMine) { OnlineGameController.Instance.firstPlayerNickname.text = nickname; }
            else { OnlineGameController.Instance.secondPlayerNickname.text = nickname; }
            /*     \/     \/    \/
            if (isMaster && isMIne)
            {
                OnlineGameController.Instance.firstPlayerNickname.text = nickname;
            }
            else if (!isMaster && !isMine)
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
            */

            if (isMine != isMaster) { transform.localScale = new Vector3(-1, 1, 1); }

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
    public void Move(Vector2 BallPosition)
    {
        transform.Translate(new Vector2(0, transform.InverseTransformPoint(BallPosition).y * Time.deltaTime * speed * 3f));

        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, -3.5f, 3.5f));
    }

    public void ResetPostition()
    {
        transform.position = startPosition;
    }
}