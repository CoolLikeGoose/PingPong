using UnityEngine;

public class PaddleController : MonoBehaviour
{
    private float speed;

    private float maxYpos;
    private float minYpos;

    private void Start()
    {
        speed = GameController.Instance.paddleSpeed;

        maxYpos = GameController.Instance.topRight.y - transform.localScale.y / 2 * 1.2f;
        minYpos = GameController.Instance.bottomLeft.y + transform.localScale.y / 2 * 1.2f;
    }

    public void Move(float moveFactor)
    {
        transform.Translate(new Vector2(0, moveFactor * Time.deltaTime * speed));

        if (transform.position.y > maxYpos) { transform.position = new Vector2(transform.position.x, maxYpos); }
        else if (transform.position.y < minYpos) { transform.position = new Vector2(transform.position.x, minYpos); }
    }
}
