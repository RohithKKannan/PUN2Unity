using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PhotonConnector : MonoBehaviourPunCallbacks
{
    [Header("Panels")]
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject loading;
    [Header("Buttons")]
    [SerializeField] Button start;
    [SerializeField] Button back;
    public void StartClicked()
    {
        PhotonNetwork.ConnectUsingSettings();
        mainMenu.SetActive(false);
        loading.SetActive(true);
    }
    public void CancelClicked()
    {
        mainMenu.SetActive(true);
        loading.SetActive(false);
        PhotonNetwork.LeaveLobby();
    }
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        SceneManager.LoadScene(1);
    }
}
