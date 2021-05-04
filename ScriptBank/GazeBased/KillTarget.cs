using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KillTarget : MonoBehaviour
{
    public GameObject[] targets;
    public ParticleSystem hitEffect;
    public GameObject killEffect;
    public float timeToSelect = 3.0f;
    public static int kills;
    public int points;
    public Camera mainCamera;
    Transform camera;
    private float countDown;
    public GameObject[] all;

    public TextMeshProUGUI eliminations;
    public TextMeshProUGUI score;


    // Start is called before the first frame update
    void Start()
    {

        camera = mainCamera.transform;
        kills = 0;
        countDown = timeToSelect;
        eliminations.text = kills.ToString();
        score.text = points.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        eliminations.text = kills.ToString();
        score.text = points.ToString();

        int count = 0;
        /*
        all = FindObjectsOfType<GameObject>();
        foreach(GameObject x in all)
        {
            if (x.CompareTag("Zombie"))
            {
                targets[count] = x;
                
                count++;
            }
        }
        */

        bool isHitting = false;
        
        Ray ray = new Ray(camera.position, camera.rotation * Vector3.forward*10);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if(hit.transform.tag == "UI")
            {
                hit.transform.SendMessage("HitByRay");
            }
            
            //if(targets.Length != 0)
            //{
                for (int i = 0; i < targets.Length; i++)
                {
                    //Debug.Log(targets.Length);
                    if (hit.collider.gameObject.tag == "Zombie")
                    {
                        isHitting = true;
                    }

                    if (isHitting)
                    {
                        if (countDown > 0.0f)
                        {
                            countDown -= Time.deltaTime;
                            hitEffect.transform.position = hit.point;
                            if (hitEffect.isStopped)
                            {
                                hitEffect.Play();
                            }
                        }
                        else
                        {
                            Instantiate(killEffect, hit.transform.position, hit.transform.rotation);
                            kills += 1;
                            points += 1;
                            countDown = timeToSelect;
                            Destroy(hit.collider.gameObject);
                        }
                    }
                    else
                    {
                        countDown = timeToSelect;
                        hitEffect.Stop();
                    }
                }

            //}
            
        }

    }

}
