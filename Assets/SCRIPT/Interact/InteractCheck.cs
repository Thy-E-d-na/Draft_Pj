using System;
using UnityEngine;

public class InteractCheck : MonoBehaviour //= class PlayerInteract 
{

    
    [SerializeField] private float soulInteractRange = 1f;
    [SerializeField] private float waterInteractRange = 5f;
   

    private void Update()
    {        
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(GetInteractableWater() != null) GetInteractableWater().Interact();

            if (GetInteractableSoul() != null) GetInteractableSoul().Interact();
        }
    }
  

    public FishingToggle GetInteractableWater()
    {

        Collider[] arr = Physics.OverlapSphere(transform.position, waterInteractRange);
        foreach (Collider col in arr)
        {
            if (col.CompareTag("Water"))
            {
                if (col.TryGetComponent(out FishingToggle interact))
                {
                    return interact;
                }
            }
        }
        return null;
    }
     
 
    public InteractableSoul GetInteractableSoul()
    {
        Collider[] arr = Physics.OverlapSphere(transform.position, soulInteractRange);
        foreach (Collider col in arr)
        {
           if(col.TryGetComponent(out InteractableSoul interact))
            {
                
                return interact;
            }
        }
        return null;
    }

}
