using UnityEngine;

public class BallController : MonoBehaviour
{
    private float speed;

    private Vector2 direction;

    private void Start()
    {
        speed = GameController.Instance.ballSpeed;

        direction = new Vector2(1, 1).normalized;
    }

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
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
        }
    }
}
