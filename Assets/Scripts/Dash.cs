using UnityEngine;

public class Dash : MonoBehaviour
{
    [SerializeField]
    float movementSpeed = 1f;

    //Variables used within this script
    Rigidbody2D rigidBody;
    Collider2D coll2D;
    float timer = 0f;
    Vector2 playerHalfSize = Vector2.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        if (rigidBody == null)
        {
            Debug.Log("This object is missing a rigidbody!");
        }

        coll2D = GetComponent<Collider2D>();
        if (coll2D != null)
        {
            playerHalfSize = coll2D.bounds.extents;
        }
    }
    void Update()
    {
        timer -= Time.deltaTime;
        if (rigidBody == null)
        {
            return;
        }

        Vector2 direction = Vector2.zero;

        float verticalBound = Camera.main.orthographicSize - playerHalfSize.y;
        float horizontalBound = Camera.main.orthographicSize * Camera.main.aspect - playerHalfSize.x;

        if (transform.position.y < verticalBound && (Input.GetKey(KeyCode.UpArrow) || (Input.GetKey(KeyCode.W))))
        {
            direction.y = 1;
        }
        if (transform.position.y > -verticalBound && (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)))
        {
            direction.y = -1;
        }
        if (transform.position.x < horizontalBound && (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)))
        {
            direction.x = 1;
        }
        if (transform.position.x > -horizontalBound && (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)))
        {
            direction.x = -1;

        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && timer < 0)
        {
            movementSpeed = 20;
            Invoke("ResetSpeed", 0.17f);
            timer = 2f;
        }
        rigidBody.linearVelocity = direction.normalized * movementSpeed;

    }
    private void ResetSpeed()
    {
        movementSpeed = 4;
    }

}
