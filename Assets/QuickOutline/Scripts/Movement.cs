using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed = 1.0f;
    public OVRCameraRig cameraRig;


    // Start is called before the first frame update
    void Start()
    {
        var p = cameraRig.transform.localPosition;
        p.z = OVRManager.profile.eyeDepth;
        cameraRig.transform.localPosition = p;

    }


    /*void Awake()
    {
        Controller = gameObject.GetComponent<CharacterController>();

        if (Controller == null)
            Debug.LogWarning("OVRPlayerController: No CharacterController attached.");

        // We use OVRCameraRig to set rotations to cameras,
        // and to be influenced by rotation
        OVRCameraRig[] CameraRigs = gameObject.GetComponentsInChildren<OVRCameraRig>();

        if (CameraRigs.Length == 0)
            Debug.LogWarning("OVRPlayerController: No OVRCameraRig attached.");
        else if (CameraRigs.Length > 1)
            Debug.LogWarning("OVRPlayerController: More then 1 OVRCameraRig attached.");
        else
            CameraRig = CameraRigs[0];

        InitialYRotation = transform.rotation.eulerAngles.y;
    }*/

    void Update()
    {
        OVRInput.Update();
        OVRInput.FixedUpdate();

        /*if (OVRInput.GetActiveController() != OVRInput.Controller.LTouch)
            Debug.Log("OVRPlayerController: No CharacterController attached.");*/

        /*Vector3 forward = cameraRig.transform.forward;
        Vector3 right = cameraRig.transform.right;

        forward.y = 0f;
        right.y = 0f;*/



        
        Vector2 axisInput = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        Vector2 directionInput = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);

        //Vector3 direction = (forward * axisInput.y + right * axisInput.x).normalized;

        


        transform.Translate(new Vector3(axisInput.x, 0, axisInput.y) * speed * Time.deltaTime);
        //transform.Translate(direction * speed * Time.deltaTime);


        transform.Rotate(new Vector3(directionInput.x, 0, directionInput.y) * speed * Time.deltaTime);
        //transform.Rotate(direction3 * speed * Time.deltaTime);


    }


}

/*
 
     private void UpdateMovement() {
        Vector2 direction = moveAction.action.ReadValue<Vector2>();
        var xAxis = direction.x * speed;
        var zAxis = direction.y * speed;

        // Move in relation to where the player is looking.
        moveVector = headTrackerTransform.TransformDirection(direction.x, 0f, direction.y).normalized;
        playerRigidbody.velocity = new Vector3(moveVector.x * speed, playerRigidbody.velocity.y, moveVector.z * speed);
    }
 
 */