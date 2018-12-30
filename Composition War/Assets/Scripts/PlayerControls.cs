using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerControls : MonoBehaviour
{
    private GameObject unit;
    public GameObject unitHandler;
    public UnitSelector unitScript;

    // Use this for initialization
    void Start()
    {
        unitScript = unitHandler.GetComponent<UnitSelector>();
    }

    // Update is called once per frame
    void Update()
    {
        Interact();
    }

    void Interact()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
            }
            if(hit.collider.gameObject.tag == "StagingArea")
            {
                StagingArea stage = hit.transform.GetComponent<StagingArea>();
                Debug.Log(mousePos2D.x);
                //Instantiate(unit, hit.transform.position, hit.transform.rotation);
                //unitSelector.transform.position = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
                //unitSelector.SetActive(true);
                if(unitScript.selectedUnit != null && !stage.hasSpawned)
                {
                    stage.hasSpawned = true;
                    unit = unitScript.selectedUnit;
                    Instantiate(unit, hit.transform.position, hit.transform.rotation);
                }
                else
                {
                    return;
                }
            }
        }
    }
}
