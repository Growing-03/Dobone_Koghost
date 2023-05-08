using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Page : MonoBehaviour
{
  [SerializeField]
  string NextStage;
  private float step_time;
  [SerializeField]
  float ReturnTitleTime;
  [SerializeField]
  string ReturnStage;

    void Start()//スタート時にstep_timeを0.0fにするプログラム
    {
      step_time = 0.0f;
    }

    void Update()//一定時間内にスペースキーを押すとNextStageに指定した画面に遷移し、
    //スペースキーを押さずに一定時間が経過すると、ReturnStageに指定した画面に遷移する
    {
        if(Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene(NextStage,LoadSceneMode.Single);
        }
        step_time += Time.deltaTime;

        if(step_time >= ReturnTitleTime)
        {
          SceneManager.LoadScene(ReturnStage);
        }
    }
  }
