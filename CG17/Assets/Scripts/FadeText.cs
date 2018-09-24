using UnityEngine;
using UnityEngine.UI;
//Henrik,
public class FadeText : MonoBehaviour {

    public Animator animator;
    private Text FadedText; 

    void Awake()
    {
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        Destroy(gameObject, clipInfo[0].clip.length);
        FadedText = animator.GetComponent<Text>();
    }
    public void SetText(string text)
    {
        FadedText.text = text;
    }
}
