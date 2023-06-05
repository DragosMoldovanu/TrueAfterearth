using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoordinatePlayers : MonoBehaviour
{
    public Vector3 worldTwoOffset;
    public Vector3 worldThreeOffset;
    public Vector3 worldFourOffset;

    public Camera camWorldOne;
    public Camera camWorldTwo;
    public Camera camWorldThree;
    public Camera camWorldFour;

    public RenderTexture renderWorldOne;
    public RenderTexture renderWorldTwo;
    public RenderTexture renderWorldThree;
    public RenderTexture renderWorldFour;

    public FollowCursor portalViewOne;
    public FollowCursor portalViewTwo;
    public FollowCursor portalViewThree;
    public FollowCursor portalViewFour;

    public GameObject playerWorldOne;
    public GameObject playerWorldTwo;
    public GameObject playerWorldThree;
    public GameObject playerWorldFour;

    public GameObject wheelOne;
    public GameObject wheelTwo;
    public GameObject wheelThree;
    public GameObject wheelFour;

    public GameObject arrowOne;
    public GameObject arrowTwo;
    public GameObject arrowThree;
    public GameObject arrowFour;

    public bool centerEntered;

    public bool currentOne;
    public bool currentTwo;
    public bool currentThree;
    public bool currentFour;

    public bool portalOne;
    public bool portalTwo;
    public bool portalThree;
    public bool portalFour;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (currentOne)
                ChangeToWorldTwo();
            else if (currentTwo)
                ChangeToWorldThree();
            else if (currentThree)
                ChangeToWorldFour();
            else if (currentFour)
                ChangeToWorldOne();
        }

        if (currentOne)
        {
            camWorldOne.targetTexture = null;
            camWorldTwo.targetTexture = renderWorldTwo;
            camWorldThree.targetTexture = renderWorldThree;
            camWorldFour.targetTexture = renderWorldFour;

            playerWorldOne.GetComponent<GunController>().enabled = true;
            playerWorldTwo.GetComponent<GunController>().enabled = false;
            playerWorldThree.GetComponent<GunController>().enabled = false;
            playerWorldFour.GetComponent<GunController>().enabled = false;

            portalViewOne.chosenCamera = camWorldOne;
            portalViewTwo.chosenCamera = camWorldOne;
            portalViewThree.chosenCamera = camWorldOne;
            portalViewFour.chosenCamera = camWorldOne;
        }
        else if (currentTwo)
        {
            camWorldOne.targetTexture = renderWorldOne;
            camWorldTwo.targetTexture = null;
            camWorldThree.targetTexture = renderWorldThree;
            camWorldFour.targetTexture = renderWorldFour;

            playerWorldOne.GetComponent<GunController>().enabled = false;
            playerWorldTwo.GetComponent<GunController>().enabled = true;
            playerWorldThree.GetComponent<GunController>().enabled = false;
            playerWorldFour.GetComponent<GunController>().enabled = false;

            portalViewOne.chosenCamera = camWorldTwo;
            portalViewTwo.chosenCamera = camWorldTwo;
            portalViewThree.chosenCamera = camWorldTwo;
            portalViewFour.chosenCamera = camWorldTwo;
        }
        else if (currentThree)
        {
            camWorldOne.targetTexture = renderWorldOne;
            camWorldTwo.targetTexture = renderWorldTwo;
            camWorldThree.targetTexture = null;
            camWorldFour.targetTexture = renderWorldFour;

            playerWorldOne.GetComponent<GunController>().enabled = false;
            playerWorldTwo.GetComponent<GunController>().enabled = false;
            playerWorldThree.GetComponent<GunController>().enabled = true;
            playerWorldFour.GetComponent<GunController>().enabled = false;

            portalViewOne.chosenCamera = camWorldThree;
            portalViewTwo.chosenCamera = camWorldThree;
            portalViewThree.chosenCamera = camWorldThree;
            portalViewFour.chosenCamera = camWorldThree;
        }
        else if (currentFour)
        {
            camWorldOne.targetTexture = renderWorldOne;
            camWorldTwo.targetTexture = renderWorldTwo;
            camWorldThree.targetTexture = renderWorldThree;
            camWorldFour.targetTexture = null;

            playerWorldOne.GetComponent<GunController>().enabled = false;
            playerWorldTwo.GetComponent<GunController>().enabled = false;
            playerWorldThree.GetComponent<GunController>().enabled = false;
            playerWorldFour.GetComponent<GunController>().enabled = true;

            portalViewOne.chosenCamera = camWorldFour;
            portalViewTwo.chosenCamera = camWorldFour;
            portalViewThree.chosenCamera = camWorldFour;
            portalViewFour.chosenCamera = camWorldFour;
        }

        if ((currentOne && !centerEntered) || (portalOne && centerEntered))
        {
            playerWorldOne.GetComponent<AudioListener>().enabled = true;
            playerWorldTwo.GetComponent<AudioListener>().enabled = false;
            playerWorldThree.GetComponent<AudioListener>().enabled = false;
            playerWorldFour.GetComponent<AudioListener>().enabled = false;
        }
        if ((currentTwo && !centerEntered) || (portalTwo && centerEntered))
        {
            playerWorldOne.GetComponent<AudioListener>().enabled = false;
            playerWorldTwo.GetComponent<AudioListener>().enabled = true;
            playerWorldThree.GetComponent<AudioListener>().enabled = false;
            playerWorldFour.GetComponent<AudioListener>().enabled = false;
        }
        if ((currentThree && !centerEntered) || (portalThree && centerEntered))
        {
            playerWorldOne.GetComponent<AudioListener>().enabled = false;
            playerWorldTwo.GetComponent<AudioListener>().enabled = false;
            playerWorldThree.GetComponent<AudioListener>().enabled = true;
            playerWorldFour.GetComponent<AudioListener>().enabled = false;
        }
        if ((currentFour && !centerEntered) || (portalFour && centerEntered))
        {
            playerWorldOne.GetComponent<AudioListener>().enabled = false;
            playerWorldTwo.GetComponent<AudioListener>().enabled = false;
            playerWorldThree.GetComponent<AudioListener>().enabled = false;
            playerWorldFour.GetComponent<AudioListener>().enabled = true;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (centerEntered)
        {
            if (portalOne)
            {
                PrioritizeOne();
            }
            else if (portalTwo)
            {
                PrioritizeTwo();
            }
            else if (portalThree)
            {
                PrioritizeThree();
            }
            else if (portalFour)
            {
                PrioritizeFour();
            }
            //PrioritizeIn();
        }
        else
        {
            if (currentOne)
            {
                PrioritizeOne();
            }
            else if (currentTwo)
            {
                PrioritizeTwo();
            }
            else if (currentThree)
            {
                PrioritizeThree();
            }
            else if (currentFour)
            {
                PrioritizeFour();
            }
            //PrioritizeOut();
        }

        if (currentOne)
        {
            if (wheelOne != null)
            {
                wheelTwo.transform.position = wheelOne.transform.position + worldTwoOffset;
                wheelThree.transform.position = wheelOne.transform.position + worldThreeOffset;
                wheelFour.transform.position = wheelOne.transform.position + worldFourOffset;

                arrowTwo.transform.position = arrowOne.transform.position + worldTwoOffset;
                arrowThree.transform.position = arrowOne.transform.position + worldThreeOffset;
                arrowFour.transform.position = arrowOne.transform.position + worldFourOffset;

                arrowTwo.transform.rotation = arrowOne.transform.rotation;
                arrowThree.transform.rotation = arrowOne.transform.rotation;
                arrowFour.transform.rotation = arrowOne.transform.rotation;

                arrowTwo.transform.localScale = arrowOne.transform.localScale;
                arrowThree.transform.localScale = arrowOne.transform.localScale;
                arrowFour.transform.localScale = arrowOne.transform.localScale;
            }
        }
        else if (currentTwo)
        {
            if (wheelTwo != null)
            {
                wheelOne.transform.position = wheelTwo.transform.position - worldTwoOffset;
                wheelThree.transform.position = wheelTwo.transform.position - worldTwoOffset + worldThreeOffset;
                wheelFour.transform.position = wheelTwo.transform.position - worldTwoOffset + worldFourOffset;

                arrowOne.transform.position = arrowTwo.transform.position - worldTwoOffset;
                arrowThree.transform.position = arrowTwo.transform.position - worldTwoOffset + worldThreeOffset;
                arrowFour.transform.position = arrowTwo.transform.position - worldTwoOffset + worldFourOffset;

                arrowOne.transform.rotation = arrowTwo.transform.rotation;
                arrowThree.transform.rotation = arrowTwo.transform.rotation;
                arrowFour.transform.rotation = arrowTwo.transform.rotation;

                arrowOne.transform.localScale = arrowTwo.transform.localScale;
                arrowThree.transform.localScale = arrowTwo.transform.localScale;
                arrowFour.transform.localScale = arrowTwo.transform.localScale;
            }
        }
        else if (currentThree)
        {
            if (wheelThree != null)
            {
                wheelOne.transform.position = wheelThree.transform.position - worldThreeOffset;
                wheelTwo.transform.position = wheelThree.transform.position - worldThreeOffset + worldTwoOffset;
                wheelFour.transform.position = wheelThree.transform.position - worldThreeOffset + worldFourOffset;

                arrowOne.transform.position = arrowThree.transform.position - worldThreeOffset;
                arrowTwo.transform.position = arrowThree.transform.position - worldThreeOffset + worldTwoOffset;
                arrowFour.transform.position = arrowThree.transform.position - worldThreeOffset + worldFourOffset;

                arrowOne.transform.rotation = arrowThree.transform.rotation;
                arrowTwo.transform.rotation = arrowThree.transform.rotation;
                arrowFour.transform.rotation = arrowThree.transform.rotation;

                arrowOne.transform.localScale = arrowThree.transform.localScale;
                arrowTwo.transform.localScale = arrowThree.transform.localScale;
                arrowFour.transform.localScale = arrowThree.transform.localScale;
            }
        }
        else if (currentFour)
        {
            if (wheelFour != null)
            {
                wheelOne.transform.position = wheelFour.transform.position - worldFourOffset;
                wheelTwo.transform.position = wheelFour.transform.position - worldFourOffset + worldTwoOffset;
                wheelThree.transform.position = wheelFour.transform.position - worldFourOffset + worldThreeOffset;

                arrowOne.transform.position = arrowFour.transform.position - worldFourOffset;
                arrowTwo.transform.position = arrowFour.transform.position - worldFourOffset + worldTwoOffset;
                arrowThree.transform.position = arrowFour.transform.position - worldFourOffset + worldThreeOffset;

                arrowOne.transform.rotation = arrowFour.transform.rotation;
                arrowTwo.transform.rotation = arrowFour.transform.rotation;
                arrowThree.transform.rotation = arrowFour.transform.rotation;

                arrowOne.transform.localScale = arrowFour.transform.localScale;
                arrowTwo.transform.localScale = arrowFour.transform.localScale;
                arrowThree.transform.localScale = arrowFour.transform.localScale;
            }
        }
        

        /*bool vertIn = topEntered || bottomEntered;
        bool horzIn = leftEntered || rightEntered;

        if (topEntered && bottomEntered && leftEntered && rightEntered)
        {
            PrioritizeIn();
        }
        else if (vertIn && horzIn)
        {
            bool vertInside = Mathf.Abs(playerInside.GetComponent<Rigidbody2D>().velocity.y) < Mathf.Abs(playerOutside.GetComponent<Rigidbody2D>().velocity.y);
            bool horzInside = Mathf.Abs(playerInside.GetComponent<Rigidbody2D>().velocity.x) < Mathf.Abs(playerOutside.GetComponent<Rigidbody2D>().velocity.x);
            if (vertInside && horzInside)
            {
                PrioritizeIn();
            }
            else if (vertInside && !horzInside)
            {
                HorzOutVertIn();
            }
            else if (!vertInside && horzInside)
            {
                HorzInVertOut();
            }
            else if (!vertInside && !horzInside)
            {
                PrioritizeOut();
            }
        }
        else if (vertIn && !horzIn)
        {
            if (Mathf.Abs(playerInside.GetComponent<Rigidbody2D>().velocity.y) < Mathf.Abs(playerOutside.GetComponent<Rigidbody2D>().velocity.y))
            {
                PrioritizeIn();
            }
            else
            {
                PrioritizeOut();
            }
        }
        else if (!vertIn && horzIn)
        {
            if (Mathf.Abs(playerInside.GetComponent<Rigidbody2D>().velocity.x) < Mathf.Abs(playerOutside.GetComponent<Rigidbody2D>().velocity.x))
            {
                PrioritizeIn();
            }
            else
            {
                PrioritizeOut();
            }
        }
        else if (!vertIn && !horzIn)
        {
            PrioritizeOut();
        }*/
    }

    public void ChangeToWorldOne()
    {
        currentOne = true;
        currentTwo = false;
        currentThree = false;
        currentFour = false;

        portalOne = false;
        portalTwo = false;
        portalThree = false;
        portalFour = false;
        Destroy(GameObject.Find("Portal(Clone)"));
    }

    public void ChangeToWorldTwo()
    {
        currentOne = false;
        currentTwo = true;
        currentThree = false;
        currentFour = false;

        portalOne = false;
        portalTwo = false;
        portalThree = false;
        portalFour = false;
        Destroy(GameObject.Find("Portal(Clone)"));
    }

    public void ChangeToWorldThree()
    {
        currentOne = false;
        currentTwo = false;
        currentThree = true;
        currentFour = false;

        portalOne = false;
        portalTwo = false;
        portalThree = false;
        portalFour = false;
        Destroy(GameObject.Find("Portal(Clone)"));
    }

    public void ChangeToWorldFour()
    {
        currentOne = false;
        currentTwo = false;
        currentThree = false;
        currentFour = true;

        portalOne = false;
        portalTwo = false;
        portalThree = false;
        portalFour = false;
        Destroy(GameObject.Find("Portal(Clone)"));
    }

    private void PrioritizeOne()
    {
        playerWorldTwo.transform.position = playerWorldOne.transform.position + worldTwoOffset;
        playerWorldThree.transform.position = playerWorldOne.transform.position + worldThreeOffset;
        playerWorldFour.transform.position = playerWorldOne.transform.position + worldFourOffset;

        playerWorldTwo.GetComponent<Rigidbody2D>().velocity = playerWorldOne.GetComponent<Rigidbody2D>().velocity;
        playerWorldThree.GetComponent<Rigidbody2D>().velocity = playerWorldOne.GetComponent<Rigidbody2D>().velocity;
        playerWorldFour.GetComponent<Rigidbody2D>().velocity = playerWorldOne.GetComponent<Rigidbody2D>().velocity;

        playerWorldTwo.GetComponent<Rigidbody2D>().isKinematic = true;
        playerWorldThree.GetComponent<Rigidbody2D>().isKinematic = true;
        playerWorldFour.GetComponent<Rigidbody2D>().isKinematic = true;

        playerWorldOne.GetComponent<Rigidbody2D>().isKinematic = false;
    }

    private void PrioritizeTwo()
    {
        playerWorldOne.transform.position = playerWorldTwo.transform.position - worldTwoOffset;
        playerWorldThree.transform.position = playerWorldTwo.transform.position - worldTwoOffset + worldThreeOffset;
        playerWorldFour.transform.position = playerWorldTwo.transform.position - worldTwoOffset + worldFourOffset;

        playerWorldOne.GetComponent<Rigidbody2D>().velocity = playerWorldTwo.GetComponent<Rigidbody2D>().velocity;
        playerWorldThree.GetComponent<Rigidbody2D>().velocity = playerWorldTwo.GetComponent<Rigidbody2D>().velocity;
        playerWorldFour.GetComponent<Rigidbody2D>().velocity = playerWorldTwo.GetComponent<Rigidbody2D>().velocity;

        playerWorldOne.GetComponent<Rigidbody2D>().isKinematic = true;
        playerWorldThree.GetComponent<Rigidbody2D>().isKinematic = true;
        playerWorldFour.GetComponent<Rigidbody2D>().isKinematic = true;

        playerWorldTwo.GetComponent<Rigidbody2D>().isKinematic = false;
    }

    private void PrioritizeThree()
    {
        playerWorldOne.transform.position = playerWorldThree.transform.position - worldThreeOffset;
        playerWorldTwo.transform.position = playerWorldThree.transform.position - worldThreeOffset + worldTwoOffset;
        playerWorldFour.transform.position = playerWorldThree.transform.position - worldThreeOffset + worldFourOffset;

        playerWorldOne.GetComponent<Rigidbody2D>().velocity = playerWorldThree.GetComponent<Rigidbody2D>().velocity;
        playerWorldTwo.GetComponent<Rigidbody2D>().velocity = playerWorldThree.GetComponent<Rigidbody2D>().velocity;
        playerWorldFour.GetComponent<Rigidbody2D>().velocity = playerWorldThree.GetComponent<Rigidbody2D>().velocity;

        playerWorldOne.GetComponent<Rigidbody2D>().isKinematic = true;
        playerWorldTwo.GetComponent<Rigidbody2D>().isKinematic = true;
        playerWorldFour.GetComponent<Rigidbody2D>().isKinematic = true;

        playerWorldThree.GetComponent<Rigidbody2D>().isKinematic = false;
    }

    private void PrioritizeFour()
    {
        playerWorldOne.transform.position = playerWorldFour.transform.position - worldFourOffset;
        playerWorldTwo.transform.position = playerWorldFour.transform.position - worldFourOffset + worldTwoOffset;
        playerWorldThree.transform.position = playerWorldFour.transform.position - worldFourOffset + worldThreeOffset;

        playerWorldOne.GetComponent<Rigidbody2D>().velocity = playerWorldFour.GetComponent<Rigidbody2D>().velocity;
        playerWorldTwo.GetComponent<Rigidbody2D>().velocity = playerWorldFour.GetComponent<Rigidbody2D>().velocity;
        playerWorldThree.GetComponent<Rigidbody2D>().velocity = playerWorldFour.GetComponent<Rigidbody2D>().velocity;

        playerWorldOne.GetComponent<Rigidbody2D>().isKinematic = true;
        playerWorldTwo.GetComponent<Rigidbody2D>().isKinematic = true;
        playerWorldThree.GetComponent<Rigidbody2D>().isKinematic = true;

        playerWorldFour.GetComponent<Rigidbody2D>().isKinematic = false;
    }

    private void PrioritizeOut()
    {
        /*playerInside.transform.position = playerOutside.transform.position + worldOffset;
        playerInside.GetComponent<Rigidbody2D>().velocity = playerOutside.GetComponent<Rigidbody2D>().velocity;

        playerInside.GetComponent<Rigidbody2D>().isKinematic = true;
        playerOutside.GetComponent<Rigidbody2D>().isKinematic = false;*/
    }

    private void PrioritizeIn()
    {
        /*playerOutside.transform.position = playerInside.transform.position - worldOffset;
        playerOutside.GetComponent<Rigidbody2D>().velocity = playerInside.GetComponent<Rigidbody2D>().velocity;

        playerInside.GetComponent<Rigidbody2D>().isKinematic = false;
        playerOutside.GetComponent<Rigidbody2D>().isKinematic = true;*/
    }

    private void HorzOutVertIn()
    {
        /*PrioritizeOut();
        return;

        Vector2 velocity = new Vector2(playerOutside.GetComponent<Rigidbody2D>().velocity.x, playerInside.GetComponent<Rigidbody2D>().velocity.x);
        Vector3 position = (playerInside.transform.position + worldOffset + playerOutside.transform.position) / 2;

        playerInside.GetComponent<Rigidbody2D>().velocity = velocity;
        playerOutside.GetComponent<Rigidbody2D>().velocity = velocity;

        playerInside.transform.position = position;
        playerOutside.transform.position = position - worldOffset;*/
    }

    private void HorzInVertOut()
    {
        /*PrioritizeOut();
        return;

        Vector2 velocity = new Vector2(playerInside.GetComponent<Rigidbody2D>().velocity.x, playerOutside.GetComponent<Rigidbody2D>().velocity.x);
        Vector3 position = (playerInside.transform.position + worldOffset + playerOutside.transform.position) / 2;

        playerInside.GetComponent<Rigidbody2D>().velocity = velocity;
        playerOutside.GetComponent<Rigidbody2D>().velocity = velocity;

        playerInside.transform.position = position;
        playerOutside.transform.position = position - worldOffset;*/
    }
}
