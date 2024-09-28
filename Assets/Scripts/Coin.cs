using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Jump();
    }
    private void OnBecameInvisible()
    {
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(transform.position);
        if (viewportPosition.y < 0)
        {
            Destroy(gameObject);
        }

    }

    void Jump()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        Vector2 jumpVelocity = new Vector2(Random.Range(-2f, 2f), Random.Range(4f, 8f));
        rigidbody.AddForce(jumpVelocity, ForceMode2D.Impulse);
    }
}
