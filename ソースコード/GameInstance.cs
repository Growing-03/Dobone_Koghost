using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInstance
{
    public readonly static GameInstance Instance = new GameInstance();

    public enum GameState//このゲームで存在するGameStateを全て設定するプログラム
    {
        GameWait,
        GameMode,
        GameOver,
        GameClear,
        GameTitle
    }
    GameState state = GameState.GameWait;

    public void SetState(GameState _state)//stateの内容を_stateにいれて、GameManagerに送るプログラム
    {
        state = _state;

        GameManager.unityEvent.Invoke();
    }
    public GameState GetState()//stateが変わったことをstateを返すプログラム
    {
        return state;
    }
}