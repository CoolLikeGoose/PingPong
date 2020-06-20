using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    private float speed;

    private Vector2 direction;

    private float maxYpos;
    private float minYpos;
    private float maxXpos;
    private float minXpos;

    private void Start()
    {
        speed = GameController.Instance.ballSpeed;

        direction = new Vector2(1, 1).normalized;

        maxYpos = GameController.Instance.topRight.y - transform.localScale.y / 2;
        minYpos = GameController.Instance.bottomLeft.y + transform.localScale.y / 2;

        maxXpos = GameController.Instance.topRight.x - transform.localScale.y / 2;
        minXpos = GameController.Instance.bottomLeft.x + transform.localScale.y / 2;
    }

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        
        // TODO: maybe stuck in border, fix
        if (transform.position.y > maxYpos || transform.position.y < minYpos) { direction.y = -direction.y; }
        
        if (transform.position.x > maxXpos || transform.position.x < minXpos) { SceneManager.LoadScene(0); }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Paddle"))
        {
            direction.x = -direction.x;
        }
    }
}
