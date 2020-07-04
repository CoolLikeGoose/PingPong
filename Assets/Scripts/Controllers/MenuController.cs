using Photon.Pun;
using System.Collections;
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
        if (PhotonNetwork.IsConnected) { OnConnectedToMaster(); }
        else { PhotonNetwork.ConnectUsingSettings(); }
        nickInput.text = PlayerPrefs.GetString("NickName", "");
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
        if (CheckNickname()) { PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions { MaxPlayers = 2 }); }
    }

    public void JoinRandomRoom()
    {
        if (CheckNickname()) { PhotonNetwork.JoinRandomRoom(); }
    }

    private bool CheckNickname()
    {
        string nickname = nickInput.text;

        if (nickname.Replace(" ", "") == "")
        {
            nickInput.image.color = Color.red;

            return false;
        }

        PlayerPrefs.SetString("NickName", nickname);
        PlayerPrefs.Save();

        PhotonNetwork.NickName = nickname;

        return true;
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
