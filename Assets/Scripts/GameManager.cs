using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using Photon.Pun;
using Photon.Realtime;
public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject PlayerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        //TODO
        //1 vérifier que le joueur est connecté
        //2 vérifier que playerPrefab n'est pas égale à nul
        PhotonNetwork.Instantiate(PlayerPrefab.name,new Vector3(0,1,0),Quaternion.identity,0);
    }
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            QuitApplication();
        }
    }

    public void OnPlayerEnterRoom(Player p)
    {
        print(p.NickName = " connecté !");
    }
    public override void  OnPlayerLeftRoom(Player p)
    {
        print(p.NickName = " déconnecté !");
    }

    public override void  OnLeftRoom()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
}
