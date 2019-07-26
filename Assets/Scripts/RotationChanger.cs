using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationChanger : MonoBehaviour {

    public float startingRot = 0f;
    public float changeSpeed = 0.5f;
    public float rotation;
    public bool isClockwise = false;
    public bool isCounterClockwise = false;
    public List<Collider> zoneCollisions;

    void Start ()
    {
        zoneCollisions = new List<Collider>();
        startingRot = transform.rotation.eulerAngles.y;
    }
	
	void Update ()
    {
        isClockwise = false;
        isCounterClockwise = false;

        for (int i = 0; i < zoneCollisions.Count; i++)
        {
            if (zoneCollisions[i].CompareTag("Clockwise"))
            {
                isClockwise = true;
            }
            else if (zoneCollisions[i].CompareTag("CounterClockwise"))
            {
                isCounterClockwise = true;
            }
        }

        if (isClockwise)
        {
            transform.Rotate(new Vector3(0, changeSpeed, 0));
            //if (sizeValue > upperSizeBound)
            //{
            //    sizeValue = upperSizeBound;
            //}
        }
        if (isCounterClockwise)
        {
            transform.Rotate(new Vector3(0, -changeSpeed, 0));
            //if (sizeValue < lowerSizeBound)
            //{
            //    sizeValue = lowerSizeBound;
            //}
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Clockwise") || other.gameObject.CompareTag("CounterClockwise"))
        {
            //Debug.Log("Enter Growth Zone");
            zoneCollisions.Add(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Clockwise") || other.gameObject.CompareTag("CounterClockwise"))
        {
            //Debug.Log("Exit Growth Zone");
            zoneCollisions.Remove(other);
        }
    }
}
