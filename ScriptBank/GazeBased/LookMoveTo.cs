using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookMoveTo : MonoBehaviour
{
    public GameObject ground;

    void Update()
    {
        Transform camera = Camera.main.transform;
        Ray ray;
        RaycastHit hit;
        GameObject hitObject;
        Debug.DrawRay(camera.position, camera.rotation * Vector3.forward * 100f);

        ray = new Ray(camera.position, camera.rotation * Vector3.forward);
        if(Physics.Raycast(ray, out hit))
        {
            hitObject = hit.collider.gameObject;
            if(hitObject == ground)
            {
                transform.position = hit.point;
            }
        }

    }
}
