using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class StagingArea : MonoBehaviour {

    public Color startColor;
    public Color hoverColor;
    Renderer rend;

    // Use this for initialization
    void Start ()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        hoverColor = new Color(startColor.r + 0.1f, startColor.g + 0.1f, startColor.b + 0.1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

}
