using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public List<GameObject> myList = new List<GameObject>();
    public GameObject[] enemyCollider;

    public static UnityEvent unityEvent = new UnityEvent();

    void Start()//スタート時にStateをGameModeにする
    {
        unityEvent.AddListener(callback_stateChange);
        GameInstance.Instance.SetState(GameInstance.GameState.GameMode);
    }

    public void SetList()//作成したリストにColliderタグを追加する
    {
        enemyCollider = GameObject.FindGameObjectsWithTag("Collider");
        foreach(GameObject List in enemyCollider)
        {
            myList.Add(List);
        }
        callback_stateChange();
    }

    void callback_stateChange()//Stateに関するプログラムがかかれているオブジェクトにStateが変わったことを知らせられるようにするプログラム
    {
        for(int i = 0; i< myList.Count; i++)
        {
            myList[i].GetComponent<StateInterface>().ChangeState();
        }
    }
}