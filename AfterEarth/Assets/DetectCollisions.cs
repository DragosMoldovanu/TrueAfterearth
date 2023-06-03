using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private CoordinatePlayers worldCoord;

    // Start is called before the first frame update
    void Start()
    {
        worldCoord = GameObject.Find("WorldCoordinator").GetComponent<CoordinatePlayers>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.name)
        {
            case "CenterCollider":
                worldCoord.centerEntered = true;
                break;
            default:
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.gameObject.name)
        {
            case "CenterCollider":
                worldCoord.centerEntered = false;
                break;
            default:
                break;
        }
    }
}
