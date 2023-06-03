using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Camera currentMainCam;
    public GameObject portalPrefab;
    public GameObject wheelPrefab;
    public GameObject arrowPrefab;

    private CoordinatePlayers coordinator;
    private FollowCursor portalViewOne;
    private FollowCursor portalViewTwo;
    private FollowCursor portalViewThree;
    private FollowCursor portalViewFour;
    private GameObject portal;

    private GameObject selectWheelOne;
    private GameObject selectWheelTwo;
    private GameObject selectWheelThree;
    private GameObject selectWheelFour;

    private GameObject arrowOne;
    private GameObject arrowTwo;
    private GameObject arrowThree;
    private GameObject arrowFour;

    // Start is called before the first frame update
    void Start()
    {
        coordinator = GameObject.Find("WorldCoordinator").GetComponent<CoordinatePlayers>();
        portalViewOne = GameObject.Find("PortalView1").GetComponent<FollowCursor>();
        portalViewTwo = GameObject.Find("PortalView2").GetComponent<FollowCursor>();
        portalViewThree = GameObject.Find("PortalView3").GetComponent<FollowCursor>();
        portalViewFour = GameObject.Find("PortalView4").GetComponent<FollowCursor>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(1))
        {
            if (portal == null)
            {
                Vector3 cursorPos = currentMainCam.ScreenToWorldPoint(Input.mousePosition);
                portal = Instantiate(portalPrefab, new Vector3(cursorPos.x, cursorPos.y, 0), Quaternion.identity);
                portalViewFour.objectToFollow = portal;
            }
            else
            {
                portal.GetComponent<ClosePortal>().Close();
            }
        }*/

        if (Input.GetMouseButtonDown(1))
        {
            if (portal == null)
            {
                Vector3 cursorPos = currentMainCam.ScreenToWorldPoint(Input.mousePosition);

                selectWheelOne = Instantiate(wheelPrefab, new Vector3(cursorPos.x, cursorPos.y, 0), Quaternion.identity);
                selectWheelTwo = Instantiate(wheelPrefab, new Vector3(cursorPos.x, cursorPos.y, 0), Quaternion.identity);
                selectWheelThree = Instantiate(wheelPrefab, new Vector3(cursorPos.x, cursorPos.y, 0), Quaternion.identity);
                selectWheelFour = Instantiate(wheelPrefab, new Vector3(cursorPos.x, cursorPos.y, 0), Quaternion.identity);

                arrowOne = Instantiate(arrowPrefab, new Vector3(cursorPos.x, cursorPos.y, 0), Quaternion.identity);
                arrowTwo = Instantiate(arrowPrefab, new Vector3(cursorPos.x, cursorPos.y, 0), Quaternion.identity);
                arrowThree = Instantiate(arrowPrefab, new Vector3(cursorPos.x, cursorPos.y, 0), Quaternion.identity);
                arrowFour = Instantiate(arrowPrefab, new Vector3(cursorPos.x, cursorPos.y, 0), Quaternion.identity);

                coordinator.wheelOne = selectWheelOne;
                coordinator.wheelTwo = selectWheelTwo;
                coordinator.wheelThree = selectWheelThree;
                coordinator.wheelFour = selectWheelFour;

                coordinator.arrowOne = arrowOne;
                coordinator.arrowTwo = arrowTwo;
                coordinator.arrowThree = arrowThree;
                coordinator.arrowFour = arrowFour;

                Time.timeScale = 0.1f;

                if (coordinator.currentOne)
                {
                    portal = Instantiate(portalPrefab, selectWheelOne.transform.position, Quaternion.identity);
                }
                else if (coordinator.currentTwo)
                {
                    portal = Instantiate(portalPrefab, selectWheelTwo.transform.position, Quaternion.identity);
                }
                else if (coordinator.currentThree)
                {
                    portal = Instantiate(portalPrefab, selectWheelThree.transform.position, Quaternion.identity);
                }
                else if (coordinator.currentFour)
                {
                    portal = Instantiate(portalPrefab, selectWheelFour.transform.position, Quaternion.identity);
                }
            }
            else
            {
                portal.GetComponent<ClosePortal>().Close();
            }
        }
        if (Input.GetMouseButton(1))
        {
            if (selectWheelOne != null)
            {
                Vector3 cursorPos = currentMainCam.ScreenToWorldPoint(Input.mousePosition);

                float angle;
                if (coordinator.currentOne)
                {
                    Vector3 midPoint = new Vector3((selectWheelOne.transform.position.x + cursorPos.x) / 2, (selectWheelOne.transform.position.y + cursorPos.y) / 2, 0);
                    arrowOne.transform.position = midPoint;
                    angle = Vector3.SignedAngle(Vector3.right, new Vector3(cursorPos.x, cursorPos.y, 0) - selectWheelOne.transform.position, Vector3.forward);
                    arrowOne.transform.eulerAngles = new Vector3(0, 0, angle);
                    float distance = Vector3.Distance(new Vector3(cursorPos.x, cursorPos.y, 0), selectWheelOne.transform.position);
                    arrowOne.transform.localScale = new Vector3(distance, arrowOne.transform.localScale.y, 1);
                }
                else if (coordinator.currentTwo)
                {
                    Vector3 midPoint = new Vector3((selectWheelTwo.transform.position.x + cursorPos.x) / 2, (selectWheelTwo.transform.position.y + cursorPos.y) / 2, 0);
                    arrowTwo.transform.position = midPoint;
                    angle = Vector3.SignedAngle(Vector3.right, new Vector3(cursorPos.x, cursorPos.y, 0) - selectWheelTwo.transform.position, Vector3.forward);
                    arrowTwo.transform.eulerAngles = new Vector3(0, 0, angle);
                    float distance = Vector3.Distance(new Vector3(cursorPos.x, cursorPos.y, 0), selectWheelTwo.transform.position);
                    arrowTwo.transform.localScale = new Vector3(distance, arrowTwo.transform.localScale.y, 1);
                }
                else if (coordinator.currentThree)
                {
                    Vector3 midPoint = new Vector3((selectWheelThree.transform.position.x + cursorPos.x) / 2, (selectWheelThree.transform.position.y + cursorPos.y) / 2, 0);
                    arrowThree.transform.position = midPoint;
                    angle = Vector3.SignedAngle(Vector3.right, new Vector3(cursorPos.x, cursorPos.y, 0) - selectWheelThree.transform.position, Vector3.forward);
                    arrowThree.transform.eulerAngles = new Vector3(0, 0, angle);
                    float distance = Vector3.Distance(new Vector3(cursorPos.x, cursorPos.y, 0), selectWheelThree.transform.position);
                    arrowThree.transform.localScale = new Vector3(distance, arrowThree.transform.localScale.y, 1);
                }
                else if (coordinator.currentFour)
                {
                    Vector3 midPoint = new Vector3((selectWheelFour.transform.position.x + cursorPos.x) / 2, (selectWheelFour.transform.position.y + cursorPos.y) / 2, 0);
                    arrowFour.transform.position = midPoint;
                    angle = Vector3.SignedAngle(Vector3.right, new Vector3(cursorPos.x, cursorPos.y, 0) - selectWheelFour.transform.position, Vector3.forward);
                    arrowFour.transform.eulerAngles = new Vector3(0, 0, angle);
                    float distance = Vector3.Distance(new Vector3(cursorPos.x, cursorPos.y, 0), selectWheelFour.transform.position);
                    arrowFour.transform.localScale = new Vector3(distance, arrowFour.transform.localScale.y, 1);
                }

                angle = arrowOne.transform.eulerAngles.z;
                if (angle >= 0 && angle < 90 && !coordinator.currentOne)
                {
                    portalViewOne.objectToFollow = portal;
                    coordinator.portalOne = true;
                }
                else
                {
                    portalViewOne.objectToFollow = null;
                    coordinator.portalOne = false;
                }
                if (angle >= 90 && angle < 180 && !coordinator.currentTwo)
                {
                    portalViewTwo.objectToFollow = portal;
                    coordinator.portalTwo = true;
                }
                else
                {
                    portalViewTwo.objectToFollow = null;
                    coordinator.portalTwo = false;
                }
                if (angle >= 180 && angle < 270 && !coordinator.currentThree)
                {
                    portalViewThree.objectToFollow = portal;
                    coordinator.portalThree = true;
                }
                else
                {
                    portalViewThree.objectToFollow = null;
                    coordinator.portalThree = false;
                }
                if (angle >= 270 && angle < 360 && !coordinator.currentFour)
                {
                    portalViewFour.objectToFollow = portal;
                    coordinator.portalFour = true;
                }
                else
                {
                    portalViewFour.objectToFollow = null;
                    coordinator.portalFour = false;
                }
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            if (selectWheelOne != null)
            {
                float angle = arrowOne.transform.eulerAngles.z;
                Debug.Log(angle);
                if (angle >= 0 && angle < 90 && coordinator.currentOne)
                {
                    portal.GetComponent<ClosePortal>().Close();
                }
                if (angle >= 90 && angle < 180 && coordinator.currentTwo)
                {
                    portal.GetComponent<ClosePortal>().Close();
                }
                if (angle >= 180 && angle < 270 && coordinator.currentThree)
                {
                    portal.GetComponent<ClosePortal>().Close();
                }
                if (angle >= 270 && angle < 360 && coordinator.currentFour)
                {
                    portal.GetComponent<ClosePortal>().Close();
                }

                Destroy(selectWheelOne);
                Destroy(selectWheelTwo);
                Destroy(selectWheelThree);
                Destroy(selectWheelFour);

                Destroy(arrowOne);
                Destroy(arrowTwo);
                Destroy(arrowThree);
                Destroy(arrowFour);

                Time.timeScale = 1f;
            }
        }
    }

    public void ForceCancelPortal()
    {
        Destroy(selectWheelOne);
        Destroy(selectWheelTwo);
        Destroy(selectWheelThree);
        Destroy(selectWheelFour);

        Destroy(arrowOne);
        Destroy(arrowTwo);
        Destroy(arrowThree);
        Destroy(arrowFour);

        Time.timeScale = 1f;
    }
}
