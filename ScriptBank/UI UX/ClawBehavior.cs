using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ClawBehavior : MonoBehaviour
{
    public Text score;
    public int ScoreVal = 0;
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            Destroy(collision.gameObject);
        }
        ScoreVal++;
        score.text = ScoreVal.ToString();
    }

}
