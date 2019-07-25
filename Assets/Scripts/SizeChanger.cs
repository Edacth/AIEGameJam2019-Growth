using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeChanger : MonoBehaviour {

    public float startingSize = 1f;
    public float upperSizeBound = 1.5f;
    public float lowerSizeBound = 0.5f;
	void Start () {
		
	}
	
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Growth"))
        {
            Debug.Log("Enter Growth Zone");
        }

        if (other.gameObject.CompareTag("Shrink"))
        {
            Debug.Log("Enter Shrink Zone");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Growth"))
        {
            Debug.Log("Exit Growth Zone");
        }

        if (other.gameObject.CompareTag("Shrink"))
        {
            Debug.Log("Exit Shrink Zone");
        }
    }
}
