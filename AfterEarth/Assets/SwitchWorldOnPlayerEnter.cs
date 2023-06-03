using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWorldOnPlayerEnter : MonoBehaviour
{
    public enum World
    {
        Green,
        Red,
        Yellow,
        Blue
    }

    public World changeTo;
    public bool oneTimeUse;

    private CoordinatePlayers coordinator;

    // Start is called before the first frame update
    void Start()
    {
        coordinator = GameObject.Find("WorldCoordinator").GetComponent<CoordinatePlayers>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!collision.gameObject.GetComponent<GunController>().enabled)
            {
                return;
            }

            if (Time.timeScale != 1)
            {
                collision.gameObject.GetComponent<GunController>().ForceCancelPortal();
            }

            GameObject portal = GameObject.Find("Portal(Clone)");
            if (portal != null)
            {
                Destroy(portal);
            }

            coordinator.currentOne = false;
            coordinator.currentTwo = false;
            coordinator.currentThree = false;
            coordinator.currentFour = false;

            switch (changeTo)
            {
                case World.Green:
                    coordinator.currentOne = true;
                    break;
                case World.Red:
                    coordinator.currentTwo = true;
                    break;
                case World.Yellow:
                    coordinator.currentThree = true;
                    break;
                case World.Blue:
                    coordinator.currentFour = true;
                    break;
                default:
                    break;
            }

            if (oneTimeUse)
            {
                Destroy(gameObject);
            }
        }
    }
}
