using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController Instance { get; private set; }

    [SerializeField] private Text scoreCounter;

    private void Awake()
    {
        Instance = this;
    }
}
