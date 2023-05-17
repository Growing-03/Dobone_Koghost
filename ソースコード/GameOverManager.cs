using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour,StateInterface
{
    //StateがGameOverの時にGameOverObjを表示させるプログラム
    [SerializeField]
    GameObject GameOverObj;

    public void ChangeState()//各stateでの指示を出すためのプログラム
    {
        switch(GameInstance.Instance.GetState())
        {
            case GameInstance.GameState.GameWait:
            break;
            case GameInstance.GameState.GameMode:
            break;
            case GameInstance.GameState.GameOver:
            GameOverObj.SetActive(true);
            break;
            case GameInstance.GameState.GameClear:
            break;
            case GameInstance.GameState.GameTitle:
            break;
        }
    }
}