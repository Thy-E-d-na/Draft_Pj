using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "NewNPCDialogue", menuName = "NPC Dialogue")]
public class DialogueData : ScriptableObject //NPCDialogue ONLY SPECIAL NPC
{
    public string npcName;
    public Sprite soulAvt;
    public string[] lines;
    public bool[] autoNext;
    
    public float autoNextDelay = 1.5f;
    public float typingSpeed = 0.05f;
    public AudioClip voiceSound;
    public float voicePitch = 1f;

    public Sprite LamAvt;
    public int[] LamResponses; 

}
