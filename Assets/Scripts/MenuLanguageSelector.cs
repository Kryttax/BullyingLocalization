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

    //TextAsset menutxt;
    ////string[] menuProperties;
    static string[] jsonFiles;

    private static Dictionary<string, string> myDictionary;
    static JSONObject json;
    static TextAsset jsonFile;
    int cont = 0;

    private void Awake()
    {

        DontDestroyOnLoad(gameObject);
        GlobalState.Language = "NULL";

        jsonFiles = new string[4];

        jsonFiles[0] = "menuProperties.json";
        jsonFiles[1] = "cutscenes.json";
        jsonFiles[2] = "mobileProperties.json";
        jsonFiles[3] = "computerProperties.json";
        myDictionary = new Dictionary<string, string>();
    }

    public void SetLanguage(string lang)
    {
        GlobalState.Language = lang;

        OnClickCallback();
    }

    //public void SpanishLanguage()
    //{
    //    GlobalState.Language = "ES";

    //    //PlayButton.GetComponent<Text>().text = "Empezar";
    //    //ExitButton.GetComponent<Text>().text = "Salir";
    //    //CreditsButton.GetComponent<Text>().text = "Créditos";
    //    OnClickCallback();
    //}

    //public void EnglishLanguage()
    //{
    //    GlobalState.Language = "EN";


    //    //PlayButton.GetComponent<Text>().text = "Start";
    //    //ExitButton.GetComponent<Text>().text = "Exit";
    //    //CreditsButton.GetComponent<Text>().text = "Credits";
    //    OnClickCallback();
    //}

    void OnClickCallback()
    {
        FillDictionary();
        //Cerrar menu de idioma
        backGround.SetActive(false);
    }

    //Fills local myDictionary given a custom path 
    void FillDictionary()
    {
        jsonFile = (TextAsset)UnityEditor.AssetDatabase.LoadAssetAtPath("Assets/Texts/" + GlobalState.Language + "/" +
            jsonFiles[cont], typeof(TextAsset));

        string fileContents = jsonFile.text;

        json = JSONObject.Create(fileContents);

        myDictionary = json.ToDictionary();

    }

    //Checks if the given key "objectName" is in myDictionary, if it's not, fills myDictionary with the next
    //json file and tries again. If it runs out of json files, logs error, otherwise returns the string of
    //the given key.
    public string GetName(string objectName)
    {
        cont = 0;

        if (!myDictionary.ContainsKey(objectName))
        {
            ++cont;
            FillDictionary();
            while (!myDictionary.ContainsKey(objectName))
            {
                //fileName = jsonFiles[cont];
                ++cont;
                if(cont < jsonFiles.Length)
                    FillDictionary();
            }

            if (cont >= jsonFiles.Length)
            {
                Debug.LogError("The sequence with key " + objectName + " doesn't exit (Object " + this.gameObject.name + ")");
                return null;
            }

        }

        return myDictionary[objectName];
    }
}
