using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePortal : MonoBehaviour
{
    public float spawnTime;
    public float closeTime;
    public float maxSize;

    private float time = 0;
    private bool spawning = true;
    private bool closing = false;
    private bool canceled = false;

    private GameObject coordinator;

    // Start is called before the first frame update
    void Start()
    {
        coordinator = GameObject.Find("WorldCoordinator");
    }

    // Update is called once per frame
    void Update()
    {
        if (spawning)
        {
            if (time >= spawnTime)
            {
                time = 0;
                closing = true;
                spawning = false;
            }
            else
            {
                time += Time.deltaTime;
                float size = Mathf.Lerp(0, maxSize, time / spawnTime);
                transform.localScale = new Vector3(size, size, size);
            }
        }
        else if (closing)
        {
            if (time >= closeTime)
            {
                coordinator.GetComponent<CoordinatePlayers>().portalOne = false;
                coordinator.GetComponent<CoordinatePlayers>().portalTwo = false;
                coordinator.GetComponent<CoordinatePlayers>().portalThree = false;
                coordinator.GetComponent<CoordinatePlayers>().portalFour = false;
                Destroy(gameObject);
            }
            else
            {
                time += Time.deltaTime;
                float size = Mathf.Lerp(maxSize, 0, time * time / (closeTime * closeTime));
                transform.localScale = new Vector3(size, size, size);
            }
        }
    }

    public void Close()
    {
        if (!canceled)
        {
            canceled = true;

            spawning = false;
            closing = true;
            maxSize = transform.localScale.x;
            time = 0;
            closeTime = 0.3f;
        }
    }
}
