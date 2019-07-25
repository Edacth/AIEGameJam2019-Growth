using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragController : MonoBehaviour {
    private float screenHeightInUnits;
    private float screenWidthInUnits;
    private float unitPerPixel;
    public Vector2 mousePos;
    public Vector2 cachedMousePos;
    LayerMask mask;
    public Vector3 dragDir;


    public Rigidbody selectedRigidBody;
    public GameObject testObject;
    public Camera mainCamera;

    void Start ()
    {
        screenHeightInUnits = mainCamera.orthographicSize * 2;
        screenWidthInUnits = screenHeightInUnits * ((float)Screen.width / (float)Screen.height);
        unitPerPixel = screenHeightInUnits / Screen.height;
        mask = LayerMask.GetMask("Draggable");
    }
	
	void Update ()
    {
        mousePos = Input.mousePosition;
        Vector3 mouseWorldPosition = new Vector3(mousePos.x * unitPerPixel, 5, mousePos.y * unitPerPixel);
        Debug.DrawRay(mouseWorldPosition, Vector3.down * 10, Color.red);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(mouseWorldPosition, Vector3.down * 10, out hit, 10, mask))
            {
                selectedRigidBody = hit.rigidbody;
                Debug.DrawRay(mouseWorldPosition, Vector3.down * 10, Color.green);
                Debug.Log("Found RB");
            }
            cachedMousePos = mousePos;
        }

        if (Input.GetMouseButtonUp(0))
        {
            selectedRigidBody = null;
            cachedMousePos = Vector2.zero;
        }

        if (cachedMousePos != Vector2.zero)
        {
            //if (mousePos.x > cachedMousePos.x)
            //{
            //    dragDir.x = 1;
            //}
            //else if (mousePos.x < cachedMousePos.x)
            //{
            //    dragDir.x = -1;
            //}

            //if (mousePos.y > cachedMousePos.y)
            //{
            //    dragDir.z = 1;
            //}
            //else if (mousePos.y < cachedMousePos.y)
            //{
            //    dragDir.z = -1;
            //}

            dragDir.x = mousePos.x - cachedMousePos.x;
            dragDir.z = mousePos.y - cachedMousePos.y;
        }

        if (selectedRigidBody != null)
        {
            selectedRigidBody.AddForce(dragDir * 2);
            cachedMousePos = mousePos;
        }
	}
}
