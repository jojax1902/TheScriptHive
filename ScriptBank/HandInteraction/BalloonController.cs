using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BalloonController : MonoBehaviour
{
    private ActionBasedController controller;

    public bool wasDown = false;

    public GameObject balloonPrefab;
    public float floatStrength = 20f;
    public float growRate = 1.5f;
    private GameObject balloon;



    // Start is called before the first frame update
    void Start()
    {
        XRBaseController left =  FindObjectOfType<XRBaseController>();
        controller = left.GetComponent<ActionBasedController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(wasDown && controller.selectAction.action.ReadValue<float>() != 1)
        {
            wasDown = false;
            Debug.Log("Up");
            ReleaseBalloon();
        }
        if (wasDown && controller.selectAction.action.ReadValue<float>() == 1)
        {
            GrowBalloon();
            return;
        }
        if (controller.selectAction.action.ReadValue<float>() == 1)
        {
            wasDown = true;
            Debug.Log("Down");
            CreateBalloon();
        }

    }

    public void CreateBalloon()
    {
        balloon = Instantiate(balloonPrefab, controller.transform.position, Quaternion.identity);
        balloon.transform.localScale = new Vector3(.1f, .1f, .1f);

    }

    public void GrowBalloon()
    {
        balloon.transform.localScale += balloon.transform.localScale * growRate * Time.deltaTime;
    }

    public void ReleaseBalloon()
    {
        Rigidbody rb = balloon.GetComponent<Rigidbody>();
        Vector3 force = Vector3.up * floatStrength;
        rb.AddForce(force);

        GameObject.Destroy(balloon, 10f);
        balloon = null;



    }
        
}
