using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject paddle;

    public float paddleSpeed;
    public float ballSpeed;

    public PaddleController paddleL;
    public PaddleController paddleR;

    private void Awake()
    {
        Instance = this;
    }   

    private void Update()
    {
        paddleL.Move(Input.GetAxis("LeftPaddle"));
        paddleR.Move(Input.GetAxis("RightPaddle"));
    }

    public IEnumerator GameOver(string goalName)
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(0);
    }
}
