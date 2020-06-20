using UnityEngine;

public class PaddleController : MonoBehaviour
{

    private float speed;

    private Vector3 startPosition;
    private void Start()
    {
        speed = GameController.Instance.paddleSpeed;
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