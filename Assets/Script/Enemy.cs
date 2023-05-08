using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Enemy : MonoBehaviour,StateInterface
{
    [SerializeField]
    GameObject player;
    [SerializeField]
    GameObject enemy;

    bool isActive;

    void Start()//このタイミングでPlayer_Collisionオブジェクトと親オブジェクトを取得する。
    {
        player = GameObject.Find("Player_Collision");
        enemy = transform.parent.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D other)//エネミーに当たり判定を作るプログラム
    {
        if(isActive == true)
        {
            if(other.name == player.name)
            {
                StateChange();
            }
        }
        Debug.Log("On");
    }

    void Reset()//エネミーを設定した通りにリセットするプログラム
    {
        enemy = this.GetComponent<GameObject>();
    }

    void StateChange()//stateを変えるためのプログラム
    {
        GameInstance.Instance.SetState(GameInstance.GameState.GameOver);
    }

    public void ChangeState()//各stateでの指示を出すためのプログラム
    {
        switch(GameInstance.Instance.GetState())
        {
            case GameInstance.GameState.GameWait:
            isActive = false;
            break;
            case GameInstance.GameState.GameMode:
            isActive = true;
            enemy.SetActive(true);
            break;
            case GameInstance.GameState.GameOver:
            isActive = false;
            enemy.SetActive(false);
            break;
            case GameInstance.GameState.GameClear:
            isActive = false;
            enemy.SetActive(false);
            break;
            case GameInstance.GameState.GameTitle:
            isActive = false;
            break;
        }
    }
}