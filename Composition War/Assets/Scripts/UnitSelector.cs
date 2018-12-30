using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelector : MonoBehaviour {

    public GameObject stagingArea;
    public GameObject[] units;
    public GameObject selectedUnit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SelectWarrior()
    {
        selectedUnit = units[0];
    }
    public void SelectArcher()
    {
        selectedUnit = units[1];
    }
}
