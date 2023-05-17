using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class ObjectActive : MonoBehaviour
{
    [SerializeField]
    GameObject sphereObject;
    [SerializeField]
    GameObject cubeObject;
    [SerializeField]
    GameObject TitleBI;
 
    void Start()//inspectorに設定した各オブジェクトを非表示にして、SphereAppearを動かし始めるプログラム
    {
        sphereObject.SetActive(false);
        cubeObject.SetActive(false);
        TitleBI.SetActive(false);
        StartCoroutine("SphereAppear");
    }
 
    IEnumerator SphereAppear()//指定秒数経過語にsphereObjectを表示してTitleApperを動かし始めるプログラム
    {
        yield return new WaitForSeconds(16.0f);
        sphereObject.SetActive(true);
        StartCoroutine("TitleAppear");
    }

    IEnumerator TitleAppear()//SphereAppearと同様のプログラム
    {
        yield return new WaitForSeconds(0.0f);
        TitleBI.SetActive(true);
        StartCoroutine("CubeAppear");
    }
 
     IEnumerator CubeAppear()//SphereAppearと同様のプログラム
     {
         Debug.Log("Good");
        yield return new WaitForSeconds(0.0f);
        cubeObject.SetActive(true);
     }
}