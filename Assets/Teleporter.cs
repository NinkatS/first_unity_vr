using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public OVRCameraRig cameraRig;

    public int rayLength = 10;
    public float delay = 0.0f;
    bool aboutToTeleport = false;

    Vector3 teleportPos = new Vector3();

    public Material tMat;

    //public GameObject Summoning;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, rayLength * 10))
        {
            GameObject myLine = new GameObject();
            myLine.transform.position = transform.position;
            myLine.AddComponent<LineRenderer>();

            LineRenderer lr = myLine.GetComponent<LineRenderer>();
            lr.material = tMat;

            lr.startWidth = 0.01f;
            lr.endWidth = 0.01f;
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, hit.point);
            GameObject.Destroy(myLine, delay);
        }


        /*
             * 1. Create a script on your hand,and add a component called line renderer
                2. In the script attach the lineRenderer component
                3. make a simple raycast hit
                4. get the position of the hit object
                5. set the first position of the actual hand and the second to the hit object like this:

                lineRenderer.SetPosition(0,transform.position); 
                lineRenderer.SetPosition(1,hitObject.transform.position);

                And it draw a line from your hand to the hit object, remember to change the lineRender parameter to make a beautiful line
             */






        /*if (OVRInput.Get(OVRInput.Button.Three)) //X button
        {


            if(Physics.Raycast(transform.position, transform.forward, out hit, rayLength * 10)) {

            if (hit.collider.gameObject.tag == "ground")
            {
                    //aboutToTeleport = true;
                    //teleportPos = hit.point;

                    

                    //Summoning.transform.position = hit.point;
                }
                else
                {
                    aboutToTeleport = false;
                    Vector3 v1 = transform.position;
                    v1 = transform.TransformPoint(Vector3.forward * rayLength);

                    GameObject myLine = new GameObject();
                    myLine.transform.position = transform.position;
                    myLine.AddComponent<LineRenderer>();

                    LineRenderer lr = myLine.GetComponent<LineRenderer>();

                    lr.startColor = new Color(0, 0, 0);
                    lr.endColor = new Color(1, 1, 1); //
                    lr.startWidth = 0.01f;
                    lr.endWidth = 0.01f;
                    lr.SetPosition(0, transform.position);
                    lr.SetPosition(1, v1);
                    GameObject.Destroy(myLine, delay);

                }
            }
        }*/

        /*if (OVRInput.Get(OVRInput.Button.Four)) //X button
        {

            if (Physics.Raycast(transform.position, transform.forward, out hit, rayLength * 10))
            {

                //if (hit.collider.gameObject.tag == "ground")
                {
                    aboutToTeleport = true;
                    teleportPos = hit.point;

                    GameObject myLine = new GameObject();
                    myLine.transform.position = transform.position;
                    myLine.AddComponent<LineRenderer>();

                    LineRenderer lr = myLine.GetComponent<LineRenderer>();
                    lr.material = tMat;

                    lr.startWidth = 0.01f;
                    lr.endWidth = 0.01f;
                    lr.SetPosition(0, transform.position);
                    lr.SetPosition(1, hit.point);
                    GameObject.Destroy(myLine, delay);

                    cameraRig.transform.position = hit.point;
                }
                
            }
        }*/


    }
}
