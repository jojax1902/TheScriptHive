using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepositionWithDelay());
    }

    IEnumerator RepositionWithDelay()
    {
        while (true)
        {
            SetRandomPosition();
            yield return new WaitForSeconds(5.0f);
        }
    }

    void SetRandomPosition()
    {
        float x = Random.Range(-5, 5);
        float z = Random.Range(-5, 5);
        transform.position = new Vector3(x, 0.0f, z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
