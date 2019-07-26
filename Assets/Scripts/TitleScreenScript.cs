using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenScript : MonoBehaviour {

    bool enlarge = false;
    float sizeValue;
    public GameObject circle;
    float time;
	void Start ()
    {
        sizeValue = 1;
        time = 0;
	}
	
	void Update ()
    {
        if (enlarge)
        {
            sizeValue += 0.1f;
            Vector3 newScale = new Vector3(sizeValue, 0.5f, sizeValue);
            circle.transform.localScale = newScale;

            time += Time.deltaTime;
        }

        

        if (time > 4f)
        {
            SceneManager.LoadScene("Level1");
        }
    }

    public void StartSequence()
    {
        enlarge = true;
    }
}
