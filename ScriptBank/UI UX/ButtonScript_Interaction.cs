using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR.Extras;

public class ButtonScript_Interaction : MonoBehaviour
{
    public string Action;

    public GameObject claw;

    public bool down;

    private SteamVR_LaserPointer lpLeft = null;
    private SteamVR_LaserPointer lpRight = null;

    // Start is called before the first frame update
    void Awake()
    {

        foreach (GameObject C in FindObjectsOfType<GameObject>())
        {
            if (C.tag == "Claw")
            {
                claw = C;
            }
        }
        foreach (SteamVR_LaserPointer lp in FindObjectsOfType<SteamVR_LaserPointer>())
        {
            if (lp.tag == "Left")
            {
                lpLeft = lp;
            }
            else
            {
                lpRight = lp;
            }
        }
        lpLeft.PointerClick += PointerClick;
        down = false;
    }

    public void PointerClick(object sender, PointerEventArgs e)
    {
        if (this.gameObject == e.target.gameObject)
        {
            Debug.Log(down.ToString());
            if (Action == "Up" && claw.transform.position.y > 1.75f)
            {
                if (claw.transform.position.z > -3.5 && down == false)
                {
                    claw.transform.position = claw.transform.position + (Vector3.forward * -.05f);
                }
            }
            if (Action == "Down" && claw.transform.position.y > 1.75f)
            {
                if (claw.transform.position.z < -1.5 && down == false)
                {
                    claw.transform.position = claw.transform.position + (Vector3.forward * .05f);
                }
            }
            if (Action == "Left" && claw.transform.position.y > 1.75f)
            {
                if (claw.transform.position.x < 1 && down == false)
                {
                    claw.transform.position = claw.transform.position + (Vector3.left * -.05f);
                }
            }
            if (Action == "Right" && claw.transform.position.y > 1.75f)
            {
                if (claw.transform.position.x > -1 && down == false)
                {
                    claw.transform.position = claw.transform.position + (Vector3.right * -.05f);
                }
            }
            if (Action == "Drop")
            {
                
                if (down == true)
                {
                    
                    claw.transform.position = claw.transform.position + (Vector3.up * .5f);
                    down = false;
                }
                else
                {
                    claw.transform.position = claw.transform.position + (Vector3.up * -.5f);
                    down = true;
                }
            }

        }
    }
}
