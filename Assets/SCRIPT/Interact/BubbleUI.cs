using UnityEngine;

public class BubbleUI : MonoBehaviour
    //= class PlayerInteractUI
{
   
    [SerializeField] private GameObject containerE;
    [SerializeField] private InteractCheck RangeCheck;
    private void Show()
    {
        containerE.SetActive(true);
        
    }
    private void Hide()
    {
        containerE.SetActive(false);
    }
    private void Update()
    {
       interactBtnCheck();
       
    }
  
    void interactBtnCheck()
    {
        if (RangeCheck.GetInteractableSoul() != null || RangeCheck.GetInteractableWater() != null) Show();
        else Hide();
    }
}
