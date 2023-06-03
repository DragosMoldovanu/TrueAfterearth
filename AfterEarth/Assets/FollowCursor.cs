using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowCursor : MonoBehaviour
{
    public GameObject canvas;
    public GameObject objectToFollow;
    public Camera chosenCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (objectToFollow != null)
        {
            Vector3 screenPlayerPos = chosenCamera.WorldToViewportPoint(objectToFollow.transform.position);
            GetComponent<RectTransform>().position = new Vector3(screenPlayerPos.x * Screen.width, screenPlayerPos.y * Screen.height, 0);
            transform.GetChild(0).GetComponent<RectTransform>().position = Vector3.zero;

            canvas.GetComponent<CanvasScaler>().referenceResolution = new Vector2(Screen.width, Screen.height);

            float screenSize = WorldToScreenSize(objectToFollow.transform.localScale.x);
            GetComponent<RectTransform>().sizeDelta = new Vector2(screenSize, screenSize);

            transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector3(Screen.width, Screen.height, 0);
        }
        else
        {
            GetComponent<RectTransform>().sizeDelta = Vector2.zero;
        }
    }

    void LateUpdate()
    {
        
    }

    private float WorldToScreenSize(float value)
    {
        
        return (value * Screen.height / (2 * chosenCamera.orthographicSize));
    }
}
