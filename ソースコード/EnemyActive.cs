using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActive : MonoBehaviour//,StateInterface
{
    public List <GameObject> EnemyList = new List<GameObject>();
    private int number;
    [SerializeField]
    GameObject GameManager;
    int count = 2;
    private int xPos;
    private int YPos;

    void Start()//プレハブの中からランダムでプレハブを2つ抽選し、表示させるためのプログラム
    {
        while(count-- >0)
        {
        number = Random.Range (0, EnemyList.Count);
        Instantiate(EnemyList[number], new Vector2(xPos,YPos), Quaternion.identity);
        EnemyList.RemoveAt(number);
        xPos++;
        }
        Debug.Log(number);
        
        GameManager.GetComponent<GameManager>().SetList();
    }
}
