using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun; 
using Photon.Realtime;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject[] PlayerPrefabs; 
    public float PosY = -3f; 
    public float Player1Pos = -13f; 
    public float Player2Pos = 13f;
    private Vector2 SpawnPos;
    public string PrefabName; 

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    void Spawn() 
    {
        if(PhotonNetwork.LocalPlayer.CustomProperties["PlayerAvatar"] != null) {
            PrefabName = PlayerPrefabs[(int)PhotonNetwork.LocalPlayer.CustomProperties["PlayerAvatar"]].name;
        } 
        else{ 
            PrefabName = "Man"; 
        } 

        if(PhotonNetwork.LocalPlayer.IsMasterClient) 
        {
            SpawnPos = new Vector2(Player1Pos, PosY);
        }
        else{ 
            SpawnPos = new Vector2(Player2Pos, PosY); 
        } 

        PhotonNetwork.Instantiate(PrefabName, SpawnPos, Quaternion.identity); 



    }

}
