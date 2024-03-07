using UnityEngine;
using UnityEngine.Assertions;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    float projectileSpeed = 600;

    [SerializeField]
    float maxLifetime = 2.2f;

    private Rigidbody2D rb;

    public void Project(Vector2 direction)
    {
        rb = GetComponent<Rigidbody2D>();

        Assert.AreNotEqual(rb, null);
  
        rb.AddForce(direction.normalized * projectileSpeed);
        Destroy(this.gameObject, maxLifetime);
    }

    private void FixedUpdate()
    {
        transform.position = HelperFunctions.WrapAroundViewport(transform.position);
    }
}
