using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Button))]
public class AutoFlag : MonoBehaviour
{
    Image img;
    Button button;
    private void Start()
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
        TextureImporter importer = null;

        try
        {
            {
                path = "Assets/Texts/" + gameObject.name + "/flag.png";
                importer = (TextureImporter)TextureImporter.GetAtPath(path);
            }
            if (importer == null)
            {
                path = "Assets/Texts/" + gameObject.name + "/flag.jpg";
                importer = (TextureImporter)TextureImporter.GetAtPath(path);
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

        importer.textureType = TextureImporterType.Sprite;

        EditorUtility.SetDirty(importer);
        importer.SaveAndReimport();
        AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);

        GetComponent<Image>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath(path, typeof(Sprite));

        button.onClick.AddListener(SelectLanguage);

    }

    void SelectLanguage()
    {
        LanguageSelector.Instance.SetLanguage(gameObject.name);
    }
}
