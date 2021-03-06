using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.SceneManagement;
public class ChangeMap : MonoBehaviour
{
    public string MapStr { get; set; }
    public UiTitle _uiTitle;//= UiTitle.GoodEnd;
    public static GameData gameData;
    public static bool LampBeUse;
    private void Start()
    {
        LampBeUse = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.tag =="Player")
        {
            GoMap();
            ChangeSigelState();
        }
    }

    void ChangeSigelState()//碰到物件服文變換
    {
        if (SceneManager.GetActiveScene().name =="m1")
        {
            MapV2.Sigel2.SetActive(false);
            MapV2.Sigel1.SetActive(true);
            for (int i = 0; i < MapV2.SigelList.Count; i++)
            {
                MapV2.SigelList[i] = RotateSigel(MapV2.SigelList[i], MapV2.Exit2);
            }
        }

    }
    
    GameObject RotateSigel(GameObject gameObject,Vector2 target) {//選轉傳入物件到指定座標

        Vector2 v = new Vector2(target.x - gameObject.transform.position.x, target.y -gameObject.transform.position.y);
        v.Normalize();
        Vector2 v2 = Vector2.up;
        v2.Normalize();
        float theta = Mathf.Acos(Vector2.Dot(v2, v));
        gameObject.transform.rotation = Quaternion.Euler(0, 0, theta * 180 / Mathf.PI * (target.x - gameObject.transform.position.x < 0 ? 1 : -1));
        return gameObject;
    }
    
    
    public void GoMap()
    {
        if ( !LampBeUse)//&&MapStr!= null)
        {
            MapV2.ClearList();
            gameData._uiTitle =_uiTitle;
            SceneManager.LoadScene(MapStr); 
            //SceneManager.LoadScene(); 
            
        }
        else
        {
            MapV2.ClearList();
            gameData._uiTitle =UiTitle.BadEnd;
            SceneManager.LoadScene(MapStr);
            // if (MapStr!=null)
            // {
            //     gameData._uiTitle = UiTitle.BadEnd;
            //     SceneManager.LoadScene(MapStr);
            // }
            // else
            // {
            //     SceneManager.LoadScene("m1");
            // }

        }
    }

}
