using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public OVRCameraRig cameraRig;

    public int rayLength = 10;
    public float delay = 0.0f;
    bool aboutToTeleport = false;

    Vector3 teleportPos = new Vector3();

    public Material tMat;

    private LineRenderer lr;

    // Start is called before the first frame update
    void Start()
    {
        // Create the LineRenderer once in Start
        lr = gameObject.AddComponent<LineRenderer>();
        lr.material = tMat;
        lr.startWidth = 0.01f;
        lr.endWidth = 0.01f;
        lr.positionCount = 2;  // A line needs two points
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        // Perform raycast and update the LineRenderer's positions
        if (Physics.Raycast(transform.position, transform.forward, out hit, rayLength * 10))
        {
            lr.enabled = true; // Enable the line when raycast hits something
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, hit.point);
        }
        else
        {
            lr.enabled = false; // Hide the line if no hit
        }
    }
}
