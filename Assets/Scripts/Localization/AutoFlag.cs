using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEditor;

[RequireComponent(typeof(Button))]
public class AutoFlag : MonoBehaviour
{
    Image img;
    Button button;

    private void Awake()
    {
        img = GetComponent<Image>();
        button = GetComponent<Button>();

        if(img == null)
        {
            Debug.LogError("The component " + img.GetType().ToString() + " doesn't exit (Object " + this.gameObject.name + ")");
            return;
        }

        if(button == null)
        {
            Debug.LogError("The component " + button.GetType().ToString() + " doesn't exit (Object " + this.gameObject.name + ")");
            return;
        }

        string path = "";
        Texture2D import = null;
        //TextureImporter importer = null;


        path = "Localization/" + gameObject.name + "/flag";
        import = Resources.Load(path) as Texture2D;


        if (import == null)
        {
            Debug.LogError("Error: " + path+ " doesn't exit (Object " + import.name + ")");
            return;
        }

        img.sprite = Sprite.Create(import, new Rect(0, 0, import.width, import.height), Vector2.zero);
        
        button.onClick.AddListener(SelectLanguage);

    }

    void SelectLanguage()
    {
        LanguageSelector.Instance.SetLanguage(gameObject.name);
    }
}
