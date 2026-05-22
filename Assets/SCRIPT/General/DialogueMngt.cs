using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueMngt : MonoBehaviour // set active dialogue panel, set text, set name and avatar of npc
{
    public static DialogueMngt instance {get; private set; }
    public GameObject dialoguePanel;
    public TMP_Text dialogueText, nameText;
    public Image avtImg;
    public Image nextButton;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        nextButton.gameObject.SetActive(false);
    }
    public void ShowDialogue(bool show)
    {
        dialoguePanel.SetActive(show);
       
    }
    public void SetNPCInfo(string name, Sprite avt)
    {
        nameText.text = name;
        avtImg.sprite = avt;

    }
    public void SetLamInfo(string name, Sprite avt)
    {
        nameText.text = name;
        avtImg.sprite = avt;
    }
     public void SetText(string text)
    {
        dialogueText.text = text;
    }
    public void showNext(bool act)
    {
        nextButton.gameObject.SetActive(act);
      
    }
}
