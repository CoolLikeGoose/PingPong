using Photon.Pun;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private float speed;

    private Vector2 direction;

    private Vector3 startPosition;

    private bool isMineBall;

    private void Start()
    {
        //TODO: fix that
        if (GameController.Instance == null) { speed = OnlineGameController.Instance.ballSpeed; }
        else { speed = GameController.Instance.ballSpeed; }

        direction = new Vector2(1, 1).normalized;

        startPosition = transform.position;

        PhotonView observerComponent = GetComponent<PhotonView>();
        isMineBall = observerComponent == null || observerComponent.IsMine;
    }

    private void Update()
    {
        if (isMineBall)
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    public void ResetPostition()
    {
        transform.position = startPosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Paddle"))
        {
            direction.x = -direction.x;
        }
        else if (collision.CompareTag("Border"))
        {
            direction.y = -direction.y;
        }
        else
        {
            StartCoroutine(GameController.Instance.GameOver(collision.name));
            Debug.Log(collision.name);
        }
    }
}
