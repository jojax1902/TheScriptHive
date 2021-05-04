using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Physics.Raycast(this.transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, 3);
        Debug.DrawRay(this.transform.position, transform.TransformDirection(Vector3.forward),  Color.red);
        if(hit.transform.tag == "Balloon")
        {
            Destroy(hit.transform.gameObject);
        }
        
     
    }
}
