using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeChanger : MonoBehaviour {

    Vector3 startingScale;
    public float startingSize = 1f;
    public float upperSizeBound = 1.5f;
    public float lowerSizeBound = 0.5f;
    public float changeSpeed = 0.01f;
    public float sizeValue;
    public bool isShrinking = false;
    public bool isGrowing = false;
    public List<Collider> zoneCollisions;

	void Start ()
    {
        zoneCollisions = new List<Collider>();
        startingScale = transform.lossyScale;
        sizeValue = startingSize;
	}
	
	void Update ()
    {
        isGrowing = false;
        isShrinking = false;
        for (int i = 0; i < zoneCollisions.Count; i++)
        {
            if (zoneCollisions[i].CompareTag("Growth"))
            {
                isGrowing = true;
            }
            else if (zoneCollisions[i].CompareTag("Shrink"))
            {
                isShrinking = true;
            }
        }

        if (isGrowing)
        {
            sizeValue += changeSpeed;
            if (sizeValue > upperSizeBound)
            {
                sizeValue = upperSizeBound;
            }
        }
        if (isShrinking)
        {
            sizeValue -= changeSpeed;
            if (sizeValue < lowerSizeBound)
            {
                sizeValue = lowerSizeBound;
            }
        }


        transform.localScale = new Vector3(startingScale.x * sizeValue, startingScale.y, startingScale.z * sizeValue);

	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Growth") || other.gameObject.CompareTag("Shrink"))
        {
            //Debug.Log("Enter Growth Zone");
            zoneCollisions.Add(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Growth") || other.gameObject.CompareTag("Shrink"))
        {
            //Debug.Log("Exit Growth Zone");
            zoneCollisions.Remove(other);
        }
    }
}
