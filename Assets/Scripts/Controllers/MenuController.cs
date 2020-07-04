using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviourPunCallbacks
{
    public GameObject mainPopup;
    public GameObject multiplayerPopup;

    public Text logoCheck;

    public InputField nickInput;

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public void OnSinglePlayerBtn() { SceneManager.LoadScene(1); }

    public void OnExitBtn() { Application.Quit(); }

    //Multiplayer

    public void OnMultiplayerBtn(bool turnMPvisible)
    {
        mainPopup.SetActive(!turnMPvisible);
        multiplayerPopup.SetActive(turnMPvisible);
    }

    public void CreateRoom()
    {
        PhotonNetwork.NickName = nickInput.text;
        PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions { MaxPlayers = 2 });
    }

    public void JoinRandomRoom()
    {
        PhotonNetwork.NickName = nickInput.text;
        PhotonNetwork.JoinRandomRoom();
    }

    //Multiplayer override
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("OnlineGame");
    }

    public override void OnConnectedToMaster()
    {
        logoCheck.color = Color.green;
    }
}
