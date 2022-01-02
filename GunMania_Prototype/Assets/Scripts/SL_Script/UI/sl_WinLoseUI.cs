using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using Photon.Pun.UtilityScripts;
using UnityEngine.SceneManagement;
using TMPro;

public class sl_WinLoseUI : MonoBehaviourPunCallbacks
{
    public static readonly byte RestartEventCode = 1;

    public GameObject winScreen;
    public GameObject loseScreen;

    public GameObject winLoseCharacterInfo;
    public Transform p1Pos;
    public Transform p2Pos;


    void Start()
    {
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
    }


    void Update()
    {
        StartCoroutine(WaitStartGame());
    }

    //IEnumerator RestartGame()
    //{
    //    sl_PlayerHealth.currentHealth = 8;
    //    sl_P2PlayerHealth.p2currentHealth = 8;
    //    yield return new WaitForSeconds(1.0f);

    //    RaiseEventOptions eventOpt = new RaiseEventOptions { Receivers = ReceiverGroup.All };
    //    ExitGames.Client.Photon.SendOptions sendOptions = new ExitGames.Client.Photon.SendOptions { Reliability = true };
    //    PhotonNetwork.RaiseEvent(RestartEventCode, null, eventOpt, sendOptions);
    //}

    IEnumerator WaitStartGame()
    {
        yield return new WaitForSeconds(3.0f);
        WinLoseCondition();
    }

    void WinLoseCondition()
    {
        if (sl_PlayerHealth.currentHealth <= 0)
        {
            Instantiate(winLoseCharacterInfo, p1Pos.position, Quaternion.identity);
            Instantiate(winLoseCharacterInfo, p2Pos.position, Quaternion.identity);

            if (PhotonNetwork.IsMasterClient)
            {
                //p1 lose
                winScreen.SetActive(true);
                StartCoroutine(ToExitScreen());

            }
            else
            {
                //p2 win
                winScreen.SetActive(true);
                StartCoroutine(ToExitScreen());

            }
        }

        if (sl_P2PlayerHealth.p2currentHealth <= 0)
        {
            Instantiate(winLoseCharacterInfo, p1Pos.position, Quaternion.identity);
            Instantiate(winLoseCharacterInfo, p2Pos.position, Quaternion.identity);

            if (PhotonNetwork.IsMasterClient)
            {
                //p1 win
                winScreen.SetActive(true);
                StartCoroutine(ToExitScreen());

            }
            else
            {
                //p2 lose
                loseScreen.SetActive(true);
                StartCoroutine(ToExitScreen());

            }
        }

    }
   

    IEnumerator ToExitScreen()
    {
        yield return new WaitForSeconds(3.0f);
        //SceneManager.LoadScene("sl_BacktoMainMenu");

    }


}



//IEnumerator DisplayMessage(string message)
//{
//    text.text = message;
//    yield return new WaitForSeconds(2f);
//    text.text = " ";
//}

//public static void kick(int num) 
//{ 
//    foreach (Player player in PhotonNetwork.PlayerList) 
//    {
//        int s = player.ActorNumber;
//        if (s == num) 
//        { 
//            PhotonNetwork.CloseConnection(player); 
//            break; 
//        }
//    } 
//}