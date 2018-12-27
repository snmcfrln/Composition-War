using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

    private GameObject gameHandler;
    private WaveHandler waveHandler;

    public bool isActive;

	// Use this for initialization
	void Start ()
    {
        gameHandler = GameObject.Find("GameHandler");
        waveHandler = gameHandler.GetComponent<WaveHandler>();
        waveHandler.units.Add(this);
    }
	
	// Update is called once per frame
	void Update () {
        if (isActive)
        {
            Activate();
        }
	}

    private void Activate()
    {
        transform.Translate(Vector3.up * Time.deltaTime * 3);
    }
}
