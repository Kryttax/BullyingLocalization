using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuLanguageSelector : MonoBehaviour
{

    public GameObject backGround;

    public GameObject PlayButton;
    public GameObject ExitButton;
    public GameObject CreditsButton;


    private void Awake()
    {
        GlobalState.Language = "NULL";
    }

    public void SpanishLanguage()
    {
        GlobalState.Language = "ES";

        PlayButton.GetComponent<Text>().text = "Empezar";
        ExitButton.GetComponent<Text>().text = "Salir";
        CreditsButton.GetComponent<Text>().text = "Créditos";
        OnClickCallback();
    }

    public void EnglishLanguage()
    {
        GlobalState.Language = "EN";

        PlayButton.GetComponent<Text>().text = "Start";
        ExitButton.GetComponent<Text>().text = "Exit";
        CreditsButton.GetComponent<Text>().text = "Credits";
        OnClickCallback();
    }

    void OnClickCallback()
    {
        //Cerrar menu de idioma
        backGround.SetActive(false);
    }
}
