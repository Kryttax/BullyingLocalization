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
        Texture2D test = null;
        //TextureImporter importer = null;

        try
        {
            {
                path = "Localization/" + gameObject.name + "/flag";
                //importer = (TextureImporter)TextureImporter.GetAtPath(path);
                test = Resources.Load(path) as Texture2D;
            }
            if (test == null)
            {
                path = "Localization/" + gameObject.name + "/flag";
                test = Resources.Load<Texture2D>(path);
            }
            else
            {
               // Debug.LogWarning("Dialog with key " + name + " doesn't exist in file " + fileName);
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error in " + path + " path. The error is: " + e.Message);
        }

        img.sprite = Sprite.Create(test, new Rect(0, 0, test.width, test.height), Vector2.zero);
        
        button.onClick.AddListener(SelectLanguage);

    }

    void SelectLanguage()
    {
        LanguageSelector.Instance.SetLanguage(gameObject.name);
    }
}
