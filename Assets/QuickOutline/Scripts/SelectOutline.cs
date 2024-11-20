/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectOutline : MonoBehaviour
{
    
    public Color outlineColor = Color.white; // Default color is white
    public float outlineWidth = 2f; // Default width
    private Outline outline;

    private void Start()
    {
        outline = GetComponent<Outline>();
        if (outline != null)
        {
            outline.enabled = false; // Initially, outline is disabled
            outline.OutlineColor = outlineColor;
            outline.OutlineWidth = outlineWidth;
        }
    }

    // This method is called when the reticle points at the object
    public void OnPointerEnter()
    {
        if (outline != null)
        {
            outline.enabled = true;
        }
    }

    // This method is called when the reticle leaves the object
    public void OnPointerExit()
    {
        if (outline != null)
        {
            outline.enabled = false;
        }
    }
}*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectOutline : MonoBehaviour
{
    private Transform highlight;
    private Transform selection;
    private RaycastHit hit;
    public int rayLength = 10;
    public float delay = 0.0f;

    public Material tMat;

    public OVRCameraRig cameraRig;

    void Update()
    {
        // Highlight
        if (highlight != null)
        {
            highlight.gameObject.GetComponent<Outline>().enabled = false;
            highlight = null;
        }
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit hit;

        if(!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(transform.position, transform.forward, out hit, rayLength * 10))
        {
            highlight = hit.transform;

            GameObject myLine = new GameObject();
            myLine.transform.position = transform.position;
            myLine.AddComponent<LineRenderer>();

            LineRenderer lr = myLine.GetComponent<LineRenderer>();
            lr.SetColors(Color.yellow, Color.yellow);

            lr.startWidth = 0.01f;
            lr.endWidth = 0.01f;
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, hit.point);
            GameObject.Destroy(myLine, delay);


            if (highlight.CompareTag("Selectable") && highlight != selection) //only to the Object with Selectable Tag
            {
                if (highlight.gameObject.GetComponent<Outline>() != null)
                {
                    highlight.gameObject.GetComponent<Outline>().enabled = true;
                }
                else
                {
                    Outline outline = highlight.gameObject.AddComponent<Outline>();
                    outline.enabled = true;
                    highlight.gameObject.GetComponent<Outline>().OutlineColor = Color.magenta;
                    highlight.gameObject.GetComponent<Outline>().OutlineWidth = 7.0f;
                }
            }
            else
            {
                highlight = null;
            }
        }

        // Selection
        if (OVRInput.Get(OVRInput.Button.Four))
        {
            if (highlight)
            {
                if (selection != null)
                {
                    selection.gameObject.GetComponent<Outline>().enabled = false;
                }
                selection = hit.transform;
                selection.gameObject.GetComponent<Outline>().enabled = true;
                highlight = null;
            }
            else
            {
                if (selection)
                {
                    selection.gameObject.GetComponent<Outline>().enabled = false;
                    selection = null;
                }
            }
        }

        /*if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit)) //Make sure you have EventSystem in the hierarchy before using EventSystem
        {
            highlight = raycastHit.transform;
            if (highlight.CompareTag("Selectable") && highlight != selection) //only to the Object with Selectable Tag
            {
                if (highlight.gameObject.GetComponent<Outline>() != null)
                {
                    highlight.gameObject.GetComponent<Outline>().enabled = true;
                }
                else
                {
                    Outline outline = highlight.gameObject.AddComponent<Outline>();
                    outline.enabled = true;
                    highlight.gameObject.GetComponent<Outline>().OutlineColor = Color.magenta;
                    highlight.gameObject.GetComponent<Outline>().OutlineWidth = 7.0f;
                }
            }
            else
            {
                highlight = null;
            }
        }

        // Selection
        if (Input.GetMouseButtonDown(0))
        {
            if (highlight)
            {
                if (selection != null)
                {
                    selection.gameObject.GetComponent<Outline>().enabled = false;
                }
                selection = raycastHit.transform;
                selection.gameObject.GetComponent<Outline>().enabled = true;
                highlight = null;
            }
            else
            {
                if (selection)
                {
                    selection.gameObject.GetComponent<Outline>().enabled = false;
                    selection = null;
                }
            }
        }*/
    }

}