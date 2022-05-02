using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{

    public InputField LobbyName;

    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        roomOptions.BroadcastPropsChangeToAll = true;

        if(LobbyName != null){
            roomOptions.IsVisible = false;
            PhotonNetwork.CreateRoom(LobbyName.text, roomOptions, null);
        }
        else{
            PhotonNetwork.CreateRoom(null, roomOptions, null);
        }
    }

    public void QuickMatch()
    {
        PhotonNetwork.JoinRandomRoom();
    }
}
