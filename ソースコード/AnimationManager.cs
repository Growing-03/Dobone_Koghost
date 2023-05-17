using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    private int random;
    [SerializeField]
    int MaxrandomValue;
    public int[] BranchValue;
    [SerializeField]
    Animator m_animator;

    [SerializeField]
    void createrandom()//ランダムの最大数値を決めるプログラム
    {
        random = Random.Range(0,MaxrandomValue);
    }

    public void changeAnimetion()//プレイヤーのアニメーションを変えるためのプログラム
    {
        createrandom();
        for(int i = 1; i< BranchValue.Length; i++)
        //配列を使用することで途中でアニメーションが増えても対応がすぐに対応ができる
        {
            if(random < BranchValue[i] && random >= BranchValue[i-1])
            {
                this.m_animator.SetInteger("ran", i);
                Debug.Log("ran");
            }
        }
    }

    public void Changespeed(float speedX)//speedXが変更されたときにアニメーターの"InputX"に実数値を絶対値にしていれるためプログラム
    {
        this.m_animator.SetFloat("InputX", Mathf.Abs(speedX));
    }
}