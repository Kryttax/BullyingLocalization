using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetStringName : MonoBehaviour
{
    bool done;
    //void Awake()
    //{
    //    if(GlobalState.Language != "NULL")
    //        gameObject.GetComponentInChildren<Text>().text = LanguageSelector.Instance.GetName(gameObject.name);
    //}

    private void Update()
    {
        if (!done && GlobalState.Language != "NULL" )
            FillName();
    }

    void FillName()
    {
        if(gameObject.GetComponent<Text>() != null)
        {
            gameObject.GetComponent<Text>().text = LanguageSelector.Instance.GetName(gameObject.name);
        }
        else
        {
            gameObject.GetComponentInChildren<Text>().text = LanguageSelector.Instance.GetName(gameObject.name);
        }

        done = true;
    }
}
