using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject playerCharacter;
    public Vector3 cameraRightOffset;
    public Vector3 cameraLeftOffset;
    public float followSpeed;

    private bool playerFlipped;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerFlipped = playerCharacter.GetComponent<SpriteRenderer>().flipX;

        Vector3 targetPosition;
        if (!playerFlipped)
        {
            targetPosition = playerCharacter.transform.position + cameraRightOffset;
        }
        else
        {
            targetPosition = playerCharacter.transform.position + cameraLeftOffset;
        }

        Vector3 direction = targetPosition - transform.position;
        transform.position += direction * followSpeed * Time.deltaTime;
    }
}
