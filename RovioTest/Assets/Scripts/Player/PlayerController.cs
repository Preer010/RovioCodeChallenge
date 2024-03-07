using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 10;
    [SerializeField]
    float rotationSpeed = 10;

    PlayerWeapon weapon;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        weapon = GetComponent<PlayerWeapon>(); 
    }

    private void FixedUpdate()
    {
        Movement(Input.GetAxis("Vertical"));
        Rotate(Input.GetAxis("Horizontal"));

        transform.position = HelperFunctions.WrapAroundViewport(transform.position);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            weapon.Shoot();
        }
    }
    private void Movement(float VerticalInput)
    {
        rb.AddForce(VerticalInput * transform.up * moveSpeed);
    }    

    private void Rotate(float HorizontalInput)
    {
        transform.Rotate(new Vector3(0,0, -HorizontalInput * rotationSpeed));
    }

}
