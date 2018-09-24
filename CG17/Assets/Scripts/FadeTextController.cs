using UnityEngine;
//Henrik, 
public class FadeTextController : MonoBehaviour {

    private static FadeText popupTextRed;
    private static FadeText popupTextYellow;
    private static FadeText popupTextBlue;
    private static GameObject canvas;

        public static void Initialize()
        {
        canvas = GameObject.Find("HUD");
        popupTextRed = Resources.Load<FadeText>("Prefabs/PopupTextParent");
        popupTextYellow = Resources.Load<FadeText>("Prefabs/PopupTextParentYellow");
        popupTextBlue = Resources.Load<FadeText>("Prefabs/PopupTextParentBlue");

    }

        public static void CreateFloatingText(string text, Transform location, string type)
    {
        float randomX = 0.0f;
        FadeText instance = null;

        if (type == "HP") { 
            instance = Instantiate(popupTextRed);
            randomX = Random.Range(-7.0f, -2.0f);
        }
        if (type == "XP") {
            instance = Instantiate(popupTextYellow);
            randomX = Random.Range(-1.0f, 6.0f);
        }
        if (type == "MP")
        {
            instance = Instantiate(popupTextBlue);
            randomX = Random.Range(6.0f, 10.0f);
        }
        Vector2 posText = new Vector2(randomX, 1.0f);
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(posText);
        instance.transform.SetParent(canvas.transform, false);
        instance.transform.position = screenPosition;
        instance.SetText(text);
    }
}