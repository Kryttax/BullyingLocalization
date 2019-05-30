using UnityEngine;
using UnityEngine.UI;

public class GetStringName : MonoBehaviour
{

    private void Awake()
    {
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
    }
}
