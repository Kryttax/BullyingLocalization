using System.Collections;
using System.Collections.Generic;
using Isometra.Sequences;
using UnityEngine;
using UnityEngine.UI;
using System;
public class LanguageSelector : MonoBehaviour
{
    protected static LanguageSelector instance;
    public static LanguageSelector Instance { get { return instance == null ? instance = new LanguageSelector() : instance; } }

    static GameObject backGround;

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

        jsonFiles = new string[5];

        jsonFiles[0] = "menuProperties.json";
        jsonFiles[1] = "cutscenes.json";
        jsonFiles[2] = "mobileProperties.json";
        jsonFiles[3] = "computerProperties.json";
        jsonFiles[4] = "credits.json";
        myDictionary = new Dictionary<string, string>();

        backGround = GameObject.Find("Canvas/Language");
    }

    public void SetLanguage(string lang)
    {
        GlobalState.Language = lang;

        OnClickCallback();
    }

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

        if (jsonFile == null)
        {
            Debug.LogError("The sequence with key " + jsonFile.name + " doesn't exit (Object " + this.gameObject.name + ")");
            return;
        }
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

        string newWord = myDictionary[objectName];
        if(newWord.Contains("\\n"))
            newWord = myDictionary[objectName].Replace("\\n", "\n");

        return newWord;
    }
}
