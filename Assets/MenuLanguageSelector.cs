using System.Collections;
using System.Collections.Generic;
using Isometra.Sequences;
using UnityEngine;
using UnityEngine.UI;
using System;
public class MenuLanguageSelector : MonoBehaviour
{
    protected static MenuLanguageSelector instance;
    public static MenuLanguageSelector Instance { get { return instance == null ? instance = new MenuLanguageSelector() : instance; } }

    public GameObject backGround;

    private Dictionary<string, string> menuDictionary;

    public static string _playButton;
    public static string _exitButton;
    public static string _creditsButton;

    public static string _adviceTitle;
    public static string _adviceDescription;
    public static string _title;
    public static string _name;
    public static string _nameField;
    public static string _user;
    public static string _userField;
    public static string _password;
    public static string _passwordField;
    public static string _back;
    public static string _beginButton;
    public static string _introText;

    TextAsset menutxt;
    string[] menuProperties;

    TextAsset jsonFile;


    private void Awake()
    {

        DontDestroyOnLoad(gameObject);
        GlobalState.Language = "NULL";
        menuDictionary = new Dictionary<string, string>();
    }

    public void SpanishLanguage()
    {
        GlobalState.Language = "ES";

        //PlayButton.GetComponent<Text>().text = "Empezar";
        //ExitButton.GetComponent<Text>().text = "Salir";
        //CreditsButton.GetComponent<Text>().text = "Créditos";
        OnClickCallback();
    }

    public void EnglishLanguage()
    {
        GlobalState.Language = "EN";


        //PlayButton.GetComponent<Text>().text = "Start";
        //ExitButton.GetComponent<Text>().text = "Exit";
        //CreditsButton.GetComponent<Text>().text = "Credits";
        OnClickCallback();
    }

    void OnClickCallback()
    {
        //menutxt = (TextAsset)UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Texts/" +
        //GlobalState.Language + "/menuProperties.txt", typeof(TextAsset));
        //menuProperties = menutxt.text.Split(',');

        FillDictionary();
        //menuDictionary.Add("playButton", _playButton);
        //menuDictionary.Add("creditsButton", _creditsButton);
        //menuDictionary.Add("exitButton", _exitButton);
        //Cerrar menu de idioma
        backGround.SetActive(false);
    }

    string fileName = "menuProperties.json";
    static JSONObject json;

    void FillDictionary()
    {
        jsonFile = (TextAsset)UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Texts/" + GlobalState.Language + "/" + fileName, typeof(TextAsset));
        string fileContents = jsonFile.text;

        json = JSONObject.Create(fileContents);

        menuDictionary = json.ToDictionary();


        //foreach (string i in menuProperties)
        //{
           
        //    if (!menuDictionary.ContainsKey(i))
        //    {
        //        try
        //        {
        //            if (json.HasField(i))
        //            {
        //                menu
        //                menuDictionary.Add(i, );
        //            }
        //            else if (json.HasField(i.ToLower()))
        //            {
        //                menuDictionary.Add(i, SequenceGenerator.createSimplyDialog(i.ToLower(), json, null));
        //            }
        //            else
        //            {
        //                Debug.LogWarning("Dialog with key " + i + " doesn't exist in file " + fileName);
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            Debug.LogError("Error in " + jsonFile.name + " file. The error is: " + e.Message);
        //        }
        //    }
        //}

    }

    public string GetName(string objectName)
    {
        if (!json.ToDictionary().ContainsKey(objectName))
        {
            Debug.LogError("The sequence with key " + objectName + " doesn't exit (Object " + this.gameObject.name + ")");
            return null;
        }

        return json.ToDictionary()[objectName];

    }
}
