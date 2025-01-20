using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestHandler : MonoBehaviour
{

    public int fontSize;
    public Font font;
    public float detectionRadius;
    public KeyCode interactionKey;
    private bool isActive;
    private GameObject closestObject;
    private InterActiveItem interActiveItem;

    void Update()
    {
        //catch all colliders within range in the layer "InterActive"
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius, 1 << LayerMask.NameToLayer("InterActive"));
        //set your outline shader for the closest object within detectionRadius
        if (hitColliders.Length != 0)
        {
            closestObject = hitColliders[0].gameObject;
            isActive = true;
            
        }
        else if (hitColliders.Length == 0 && closestObject != null)
        {
            isActive = false;
            closestObject = null;
        }

        if (isActive && Input.GetKeyDown(interactionKey))
        {
            interActiveItem = closestObject.GetComponent<InterActiveItem>();
            interActiveItem.swapObject();
        }
    }
    void OnGUI()
    {
        if (isActive)
        {
            Vector3 objectScreenPosition = Camera.main.WorldToScreenPoint(closestObject.transform.position);
            //acces what you need to be displayed from the InterActiveItem script... check GUI.Window in the documentation, thats what i would use
            GUIStyle myStyle = new GUIStyle();
            myStyle.fontSize = fontSize;
            myStyle.font = font;
            myStyle.normal.textColor = Color.white;
            GUI.Label(new Rect(objectScreenPosition.x, objectScreenPosition.y, 50, 100), "Press F", myStyle);
        }
    }
}
