using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class RoomConnector : MonoBehaviourPunCallbacks
{
    [Header("Panels")]
    [SerializeField] GameObject lobbyPanel;
    [SerializeField] GameObject loadingPanel;
    [Header("Buttons")]
    [SerializeField] Button joinButton;
    [SerializeField] Button cancelButton;
    string roomName = "SampleRoom";
    RoomOptions roomOptions = new RoomOptions();
    void Awake()
    {
        roomOptions.IsOpen = true;
        roomOptions.IsVisible = true;
        roomOptions.MaxPlayers = 4;
    }
    public void CreateRoom()
    {
        PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, null, null);
        lobbyPanel.SetActive(false);
        loadingPanel.SetActive(true);
    }
    public void BackToLobby()
    {
        PhotonNetwork.LeaveRoom();
        lobbyPanel.SetActive(true);
        loadingPanel.SetActive(false);
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel(2);
    }
}
