using UnityEngine;

public class FishingToggle : MonoBehaviour, I_Interactable
{
    //Fishing Cam active basd on player position and rotation coordinates
    //Fishing minigame start when player press E and is in the right position and rotation
    //Fishing start by Unity Event
    public void Interact()
    {
        Debug.Log("Fishing minigame started!");
        // Implement fishing minigame logic here
    }
}
