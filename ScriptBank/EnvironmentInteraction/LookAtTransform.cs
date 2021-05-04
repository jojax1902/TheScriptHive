using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTransform : MonoBehaviour
{
    public GameObject target;
    public GameObject looking;
        
        // Start is called before the first frame update
    void Start()
    {
        looking = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        looking.transform.LookAt(target.transform, Vector3.down);
    }
}
