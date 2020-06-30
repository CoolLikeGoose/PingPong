using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviourPunCallbacks
{
    public GameObject mainPopup;
    public GameObject multiplayerPopup;

    public Text logoCheck;

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        logoCheck.color = Color.green;
    }

    public void OnSinglePlayerBtn() { SceneManager.LoadScene(1); }

    public void OnMultiplayerBtn(bool turnMPvisible)
    {
        mainPopup.SetActive(!turnMPvisible);
        multiplayerPopup.SetActive(turnMPvisible);
    }

    public void OnExitBtn() { Application.Quit(); }
}
