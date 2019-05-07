using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetStringName : MonoBehaviour
{
    
    //void Awake()
    //{
    //    if(GlobalState.Language != "NULL")
    //        gameObject.GetComponentInChildren<Text>().text = MenuLanguageSelector.Instance.GetName(gameObject.name);
    //}

    private void Update()
    {
        if (GlobalState.Language != "NULL")
            gameObject.GetComponentInChildren<Text>().text = MenuLanguageSelector.Instance.GetName(gameObject.name);
    }
}
