using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ReturnToCenter : MonoBehaviour
{
    public Interactable grabP;
    public Transform pos;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(grabP.attachedToHand != null)
        {
            pos.position = Vector3.Lerp(pos.position, Vector3.zero, 15);
            Debug.Log("lerping");
        }
    }

    
}
