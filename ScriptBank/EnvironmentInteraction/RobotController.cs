using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class RobotController : MonoBehaviour
{
    public LinearMapping lmVert;
    public LinearMapping lmHoriz;
    public LinearMapping cirRot;
    public CharacterController robot;

    public Transform lev1;
    public Vector3 lev1Start;
    public Transform lev2;
    public Vector3 lev2Start;

    // Start is called before the first frame update
    void Start()
    {
        lev1Start = lev1.position;
        lev2Start = lev2.position;
    }

    // Update is called once per frame
    void Update()
    {
        float horiz = lmHoriz.value - .5f;
        float vert = lmVert.value - .5f;
        if(horiz > 0 || horiz < 0)
        {
            //robot.transform.Rotate(Vector3.up * horiz);
            robot.Move(Vector3.left * horiz);
        }
        if(vert > 0 || vert < 0)
        {
            robot.Move(Vector3.forward * vert);
        }
        robot.transform.rotation = Quaternion.Euler(Vector3.up * (cirRot.value * 400));

    }

    public void restoreControls()
    {
       
        lev1.position = lev1Start;
        lev2.position = lev2Start;
    }
}
