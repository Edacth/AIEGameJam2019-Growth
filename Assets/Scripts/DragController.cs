using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DragController : MonoBehaviour {
    private float screenHeightInUnits;
    private float screenWidthInUnits;
    private float unitPerPixel;
    private Vector2 mousePos;
    private Vector2 cachedMousePos;
    private Vector3 mouseWorldPosition;
    private LayerMask mask;
    private Vector3 dragDir;

    public float dragStrength = 1;


    public Rigidbody selectedRigidBody;
    public GameObject testObject;
    public Camera mainCamera;
    public Text debugText;

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
        mouseWorldPosition = new Vector3(mainCamera.ScreenToWorldPoint(mousePos).x, 5, mainCamera.ScreenToWorldPoint(mousePos).z);
        //mouseWorldPosition = new Vector3(mousePos.x * unitPerPixel, 5, mousePos.y * unitPerPixel);
        //debugText.text = mouseWorldPosition.ToString();
        Debug.DrawRay(mouseWorldPosition, Vector3.down * 10, Color.red);

        if (Input.GetMouseButtonDown(0)) //Left mouse down
        {
            RaycastHit hit;
            if (Physics.Raycast(mouseWorldPosition, Vector3.down * 10, out hit, 10, mask))
            {
                selectedRigidBody = hit.rigidbody;
                Debug.DrawRay(mouseWorldPosition, Vector3.down * 10, Color.green);
                //Debug.Log("Found RB");
            }
            cachedMousePos = mousePos;
        }

        if (Input.GetMouseButtonUp(0)) //Left mouse up
        {
            selectedRigidBody = null;
            cachedMousePos = Vector2.zero;
        }

        if (cachedMousePos != Vector2.zero)
        {
            dragDir.x = mousePos.x - cachedMousePos.x;
            dragDir.z = mousePos.y - cachedMousePos.y;
        }

        if (selectedRigidBody != null)
        {
            
            selectedRigidBody.AddForce(dragDir * dragStrength);
            cachedMousePos = mousePos;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            
        }
	}
}
