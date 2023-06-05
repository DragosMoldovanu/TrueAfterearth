using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Locomotion")]
    public float acceleration;
    public float speed;
    public float jumpForce;
    public bool underwater;

    [Header("Collider")]
    public float feetColliderWidth = 1.2f;
    public float feetColliderHeight = 6.42f;
    public float feetColliderVertOffset = 0;
    public float bottomCollisionDetectRange = 0.05f;

    [Header("SFX")]
    public AudioSource walkSource;
    public AudioSource jumpSource;

    private Rigidbody2D body;
    private bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        GetComponent<BoxCollider2D>().size = new Vector2(feetColliderWidth, feetColliderHeight);
        GetComponent<BoxCollider2D>().offset = new Vector2(0, feetColliderVertOffset);
        feetColliderWidth *= transform.lossyScale.x;
        feetColliderHeight *= transform.lossyScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 leftOffset = new Vector3(-(feetColliderWidth / 2 - 0.02f), -feetColliderVertOffset - feetColliderHeight / 2 + 0.02f, 0);
        Vector3 rightOffset = new Vector3(feetColliderWidth / 2 - 0.02f, -feetColliderVertOffset - feetColliderHeight / 2 + 0.02f, 0);
        Vector3 centerOffset = new Vector3(0, -feetColliderVertOffset - feetColliderHeight / 2 + 0.02f, 0);

        Debug.DrawRay(transform.position + leftOffset, Vector3.down * bottomCollisionDetectRange, Color.red);
        Debug.DrawRay(transform.position + rightOffset, Vector3.down * bottomCollisionDetectRange, Color.red);
        Debug.DrawRay(transform.position + centerOffset, Vector3.down * bottomCollisionDetectRange, Color.red);

        RaycastHit2D leftHit = Physics2D.Raycast(transform.position + leftOffset, Vector2.down, bottomCollisionDetectRange);
        RaycastHit2D rightHit = Physics2D.Raycast(transform.position + rightOffset, Vector2.down, bottomCollisionDetectRange);
        RaycastHit2D centerHit = Physics2D.Raycast(transform.position + centerOffset, Vector2.down, bottomCollisionDetectRange);

        bool left = leftHit.collider != null;
        bool right = rightHit.collider != null;
        bool center = centerHit.collider != null;
        grounded = left || right || center;
        GetComponent<Animator>().SetBool("grounded", grounded);

        if (Input.GetKey(KeyCode.A))
        {
            body.AddForce(Vector2.left * acceleration * Time.deltaTime);
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            body.AddForce(Vector2.right * acceleration * Time.deltaTime);
            GetComponent<SpriteRenderer>().flipX = false;
        }

        if (!underwater)
        {
            if (Input.GetKeyDown(KeyCode.Space) && grounded)
            {
                body.AddForce(Vector2.up * jumpForce);
                GetComponent<Animator>().SetTrigger("jump");
                jumpSource.Play();
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.Space))
            {
                body.AddForce(Vector2.up * jumpForce * 10 * Time.deltaTime);
                //GetComponent<Animator>().SetTrigger("jump");
                jumpSource.Play();
            }
        }

        // Limit Speed
        if (Mathf.Abs(body.velocity.x) > speed)
        {
            body.velocity = new Vector2(speed * Mathf.Sign(body.velocity.x), body.velocity.y);
        }
        if (underwater)
        {
            if (Mathf.Abs(body.velocity.y) > speed)
            {
                body.velocity = new Vector2(body.velocity.x, speed * Mathf.Sign(body.velocity.y));
            }
        }

        // Animation
        if (grounded && Input.GetKey(KeyCode.A) ^ Input.GetKey(KeyCode.D))
        {
            GetComponent<Animator>().SetBool("walking", true);
            if (!walkSource.isPlaying)
            {
                walkSource.Play();
            }
        }
        else
        {
            GetComponent<Animator>().SetBool("walking", false);
            walkSource.Stop();
        }

        if (body.velocity.y < 0)
        {
            GetComponent<Animator>().SetBool("falling", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("falling", false);
        }
    }
}
