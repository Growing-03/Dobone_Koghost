using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearManager : MonoBehaviour,StateInterface
{

    //クリア画面を表示するためのプログラム
    [SerializeField]
    GameObject ClearObj;

    public void ChangeState()//各stateでの指示を出すためのプログラム
    {
        switch(GameInstance.Instance.GetState())
        {
            case GameInstance.GameState.GameWait:
            break;
            case GameInstance.GameState.GameMode:
            break;
            case GameInstance.GameState.GameOver:
            break;
            case GameInstance.GameState.GameClear:
            ClearObj.SetActive(true);
            break;
            case GameInstance.GameState.GameTitle:
            break;
        }
    }
}