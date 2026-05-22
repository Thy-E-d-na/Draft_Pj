using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InteractableSoul : MonoBehaviour, I_Interactable //ONLY 3 SPECIAL SOULS
{

    public void Interact()
    {
        Talk();
    }
   
    private DialogueMngt dialogueUI;
    public DialogueData dialogueData;
   

    private int dialogueIndex, LamLineIndex;
    private bool isInDialogue, isTyping;

    public bool CanTalk => !isInDialogue;

    private void Start()
    {
        dialogueUI = DialogueMngt.instance;
    }

    public void Talk() // trigger Dialogue chain, if pressed E multiple times while talking, it won't reset the dialogue chain
    {
        if (dialogueData == null) return;
        
       
        if (isInDialogue) NextLine();
        else StartDialogue();
    }
    void StartDialogue()
    {
        isInDialogue = true;
        dialogueIndex = 0;
        LamLineIndex = 0;


        dialogueUI.SetNPCInfo(dialogueData.npcName, dialogueData.soulAvt);
        dialogueUI.ShowDialogue(true);

        StartCoroutine(TypeLine()); //first line so go str8 to typeLine
    }


    void NextLine()
    {
        var x = dialogueIndex;
        if (isTyping)
        {
            StopAllCoroutines();
            dialogueUI.SetText(dialogueData.lines[dialogueIndex]);
            isTyping = false;
        }
        else if (++dialogueIndex < dialogueData.lines.Length) //check if next line is not out of Dialogue length, then typeLine, else end dialogue
        {
            if (!dialogueData.autoNext[x--]) dialogueUI.SetText("");
            if (dialogueIndex == dialogueData.LamResponses[LamLineIndex])
            {
                dialogueUI.SetLamInfo("Lam", dialogueData.LamAvt);
                LamLineIndex++;

            }

            else
            {               
                dialogueUI.SetNPCInfo(dialogueData.npcName, dialogueData.soulAvt);
            }
            StartCoroutine(TypeLine());
        }
        else
        {
            EndDialogue();
        }
    }
 
    IEnumerator TypeLine() //what happen in 1 line, run 1 by 1 letter, if player press E while typing, it will skip to the end of the line
    {
        isTyping = true;

        //hide next button while typing
        dialogueUI.showNext(false);

        //clear past line
        

        foreach (char letter in dialogueData.lines[dialogueIndex]) //type letter by letter
        {
            dialogueUI.SetText(dialogueUI.dialogueText.text + letter);
            //SoundMngt.PlayVoice();
            yield return new WaitForSeconds(dialogueData.typingSpeed); //typing speed
        }
        isTyping = false; //typing finish, can move to next line

        //check if autoNext else need press E to move to next line
        if (dialogueData.autoNext.Length > dialogueIndex && dialogueData.autoNext[dialogueIndex])
        {
            dialogueUI.showNext(false); //hide next button if autoNext, show if not autoNext
            yield return new WaitForSeconds(dialogueData.autoNextDelay); //wait for a moment before next line
            NextLine();
        }
        else
        {
          
            dialogueUI.showNext(true); //show next button if not autoNext

        }


    }


    void EndDialogue()
    {
        StopAllCoroutines();
        isInDialogue = false;
        dialogueUI.SetText("");
        dialogueUI.ShowDialogue(false);
       //only interact once
        Destroy(GetComponent<SphereCollider>());
    }


}
