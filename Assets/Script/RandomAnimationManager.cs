using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnimationManager : MonoBehaviour,StateInterface
{
    private int random;
    private float time;
    [SerializeField]
    float returnrandom;
    [SerializeField]
    int MaxrandomValue;
    public int[] BranchValue;
    [SerializeField]
    Animator animator;
    [SerializeField]
    GameObject blindfold;

    void Start()//スタート時にtimeを0.0fにするプログラム
    {
        time = 0.0f;
    }
    
    void Update()//時間を計測して指定時間経過後にRandomchangeAnimetionを動かしはじめて、
    //計測しているtimeを0.0fにするプログラム
    {
        time += Time.deltaTime;
        if(time >= returnrandom)
        {
            RandomchangeAnimetion();
            time = 0.0f;
        }
    }
    public void createrandom()//randomの最大値を決まるプログラム
    {
        random = Random.Range(0,MaxrandomValue);
    }

    public void RandomchangeAnimetion()//createrandomを動かし始めて、
    //randomの数値を決めるプログラム
    {
        createrandom();
        for(int i = 0; i< BranchValue.Length; i++)
        {
            if(random == BranchValue[i])
            {
                this.animator.SetInteger("rm", i);
            }
        }
    }
    public void ChangeState()//各stateでの指示を出すためのプログラム
    {
        switch(GameInstance.Instance.GetState())
        {
            case GameInstance.GameState.GameWait:
            break;
            case GameInstance.GameState.GameMode:
            break;
            case GameInstance.GameState.GameOver:
            blindfold.SetActive(false);
            break;
            case GameInstance.GameState.GameClear:
            blindfold.SetActive(false);
            break;
            case GameInstance.GameState.GameTitle:
            break;            
        }
    }
}
