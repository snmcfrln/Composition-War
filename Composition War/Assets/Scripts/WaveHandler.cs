using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveHandler : MonoBehaviour {

    public Text countdownText;
    public List<Unit> units = new List<Unit>();

    public List<GameObject> stagingObjects = new List<GameObject>();
    public List<StagingArea> stages = new List<StagingArea>();
    public bool hasSorted;

    public float timeTilSpawn = 5;


	// Use this for initialization
	void Start ()
    {
        stagingObjects.AddRange(GameObject.FindGameObjectsWithTag("StagingArea"));
    }
	
	// Update is called once per frame
	void Update () {
        Timer();

        countdownText.text = "Time until next spawn: " + timeTilSpawn.ToString("0");

        if (!hasSorted)
        {
            foreach (GameObject stageObject in stagingObjects)
            {
                stages.Add(stageObject.GetComponent<StagingArea>());
            }
        }
    }

    private void Spawn()
    {
        foreach (Unit unit in units)
        {
            unit.isActive = true;
        }
        foreach (StagingArea stage in stages)
        {
            stage.hasSpawned = false;
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
