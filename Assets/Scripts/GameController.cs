using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject paddle;

    public static Vector2 topRight;
    public static Vector2 bottomLeft;

    private void Start()
    {
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        bottomLeft = Camera.main.ScreenToWorldPoint(Vector2.zero);

        Instantiate(ball);

        Instantiate(ball, )
    }
}
