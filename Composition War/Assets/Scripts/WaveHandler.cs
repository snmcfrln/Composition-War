using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveHandler : MonoBehaviour {

    public Text countdownText;
    public List<Unit> units = new List<Unit>();

    public float timeTilSpawn = 5;


	// Use this for initialization
	void Start ()
    {
		 
	}
	
	// Update is called once per frame
	void Update () {
        Timer();

        countdownText.text = "Time until next spawn: " + timeTilSpawn.ToString("0");
    }

    private void Spawn()
    {
        foreach (Unit unit in units)
        {
            unit.isActive = true;
        }
    }

    private void Timer()
    {
        timeTilSpawn -= Time.deltaTime;
        if (timeTilSpawn <= 0)
        {
            Spawn();
            timeTilSpawn = 5;
        }
    }
}
