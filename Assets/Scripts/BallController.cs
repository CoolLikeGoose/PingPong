using Photon.Pun;
using System.Collections;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private float speed;

    private Vector2 direction;

    private Vector3 startPosition;

    private bool isMineBall;

    private bool readyForCollision = true;

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
        if (collision.CompareTag("Border"))
        {
            direction.y = -direction.y;
        }
        else if (readyForCollision)
        {
            if (collision.CompareTag("Paddle"))
            {
                direction.x = -direction.x;
            }
            else
            {
                //TODO: fix that
                if (GameController.Instance == null) { StartCoroutine(OnlineGameController.Instance.GameOver(collision.name)); }
                else { StartCoroutine(GameController.Instance.GameOver(collision.name)); }
            }

            StartCoroutine(CollisionCooldown());
        }
    }

    private IEnumerator CollisionCooldown()
    {
        readyForCollision = false;

        yield return new WaitForSeconds(2f);

        readyForCollision = true;
    }
}
