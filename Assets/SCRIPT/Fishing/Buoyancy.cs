using System.Collections.Generic;
using UnityEngine;

public class Buoyancy : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }
    [SerializeField] private List<Floater> floaters = new List<Floater>();

    [SerializeField] private float underWaterDrag = 3f;
    [SerializeField] private float underWaterAngularDrag = 1f;
    [SerializeField] private float defaultDrag = 0f;
    [SerializeField] private float defaultAngularDrag = 0.05f;

    //[SerializeField] private Transform water;

    //float w waves
    WaterMngt waveMngt;
    private void Start()
    {
        waveMngt = FindAnyObjectByType<WaterMngt>();
    }

    private void FixedUpdate()
    {
        bool isUnderWater = false;
        for (int i = 0; i < floaters.Count; i++)
        {
            if (floaters[i].floatCheck(rb, waveMngt.waterSurface.transform, waveMngt))
            {
                isUnderWater = true;
            }
        }
        SetState(isUnderWater);
    }


    void SetState(bool isUnderWater)
    {
        if (isUnderWater)
        {
            rb.linearDamping = underWaterDrag;
            rb.angularDamping = underWaterAngularDrag;

        }
        else
        {
            rb.linearDamping = defaultDrag;
            rb.angularDamping = defaultAngularDrag;

        }
    }
}
public class Floater
{
    [SerializeField] private Transform floater;
    [SerializeField] private float floatForce = 20f;
    private bool isUnderwater;
    public bool floatCheck(Rigidbody rg, Transform waterLine, WaterMngt wave)
    {
        float distance2Surface = floater.position.y - wave.waterHeightAtPosition(waterLine.position);
        if (distance2Surface < 0)
        {
            rg.AddForceAtPosition(Vector3.up * floatForce * Mathf.Abs(distance2Surface),floater.position,ForceMode.Force);
            if(!isUnderwater ) 
            isUnderwater = true;
        }
        else if(isUnderwater)
        {
            isUnderwater = false;
        }
        return isUnderwater;
    }
}