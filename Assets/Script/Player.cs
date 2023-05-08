using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour,StateInterface
{
    private Rigidbody2D m_rigidbody;
    private BoxCollider2D m_boxCollider;
    [SerializeField]
    GameObject Clear;
    [SerializeField]
    GameObject player;
    public GameObject playerCollider;
    private Vector3 m_initialPosition;
    bool _isStart = false;
    [SerializeField]
    float moveSpeed = 5.0f;

    private void Awake()//m_rigidbodyとm_boxColliderを取得して、
    //playerColliderのSetActiveをtrueにして、その0.1f後にsecondを動かし始める。
    {
        this.m_rigidbody = GetComponent<Rigidbody2D>();
        this.m_boxCollider = this.GetComponent<BoxCollider2D>();
        playerCollider.SetActive(true);
        Invoke("second", 0.1f);
    }

    void second()//falseにしていた_isStartをtrueにするプログラム
    {
        _isStart = true;
    }

    bool isActive;

    void Update()//_isStartがtrueの時に動きはじめて、isActiveがtrueの時に動くプログラム
    //float xを0に当たり判定のplayerColliderをfalseにする。
    //スペースキーを押している時にfloat xを1に当たり判定のplayerColliderをtrueにする。
    //スペースキーを離した時にPlayerオブジェクトにあるAnimationManagerプログラムにあるchangeAnimetionを動かしはじめる。
    //その後に、PlayerオブジェクトにあるAnimationManagerプログラムにあるchangeAnimetionを動かしはじめる。
    //moveを動かして、xにその時のfloat xを代入するプログラム
    {
        if(_isStart)
        {
        if(isActive == true)
        {
            float x = 0;
            playerCollider.SetActive(false);
            if(Input.GetKey("space"))
            {
                x = 1;
                playerCollider.SetActive(true);
            }
            if(Input.GetKeyUp("space"))
            {
                player.GetComponent<AnimationManager>().changeAnimetion();
            }
            player.GetComponent<AnimationManager>().Changespeed(x);
            move(x);
        }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)//クリアの当たり判定をとるためのプログラム
    {
            if(other.name == Clear.name)
            {
                StateChange();
            }
    }

    void move(float speedX)//ついているオブジェクトを動かすためのプログラム
    {
        this.m_rigidbody.velocity = new Vector2(speedX * this.moveSpeed, this.m_rigidbody.velocity.y);
    }

    void StateChange()//Stateを変えるためのプログラム
    {
        GameInstance.Instance.SetState(GameInstance.GameState.GameClear);
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
            break;
            case GameInstance.GameState.GameOver:
            player.SetActive(false);
            isActive = false;
            move(0);
            break;
            case GameInstance.GameState.GameClear:
            isActive = false;
            move(0);
            break;
            case GameInstance.GameState.GameTitle:
            isActive = false;
            break;
        }
    }
}
