using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

    public Transform target;
    float speed = 5;
    Vector3[] path;
    int targetIndex;

    private GameObject gameHandler;
    private WaveHandler waveHandler;
    public bool isActive;
    public bool hasActivated = false;
    private Rigidbody2D rigid;

	// Use this for initialization
	void Start ()
    {
        rigid = GetComponent<Rigidbody2D>();
        gameHandler = GameObject.Find("GameHandler");
        waveHandler = gameHandler.GetComponent<WaveHandler>();
        waveHandler.units.Add(this);

        PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
    }

    public void OnPathFound(Vector3[] newPath, bool pathSuccess)
    {
        if (pathSuccess)
        {
            path = newPath;
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }
    }

    IEnumerator FollowPath()
    {
        Vector3 currentWaypoint = path[0];

        while (true)
        {
            if (transform.position == currentWaypoint)
            {
                targetIndex++;
                if (targetIndex >= path.Length)
                {
                    yield break;
                }
                else
                {
                    currentWaypoint = path[targetIndex];
                }
                transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed);
                yield return null;
            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isActive && !hasActivated)
        {
            hasActivated = true;
        }
	}
}
