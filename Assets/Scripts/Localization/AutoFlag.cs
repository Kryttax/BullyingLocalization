using UnityEngine;
using UnityEngine.UI;

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
        LanguageSelector.instance.SetLanguage(gameObject.name);
    }


    // VISUAL STYLES ONLY. DOES NOT AFFECT EXECUTION AND CAN BE DELETED.
    public void Expand()
    {
        transform.localScale = new Vector2(1.2f, 1.2f);
    }

    public void Contract()
    {
        transform.localScale = new Vector2(1.0f, 1.0f);
    }
}
