using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Camera mainCamera;
    private Renderer objectRenderer;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float hp = 1f;
    [SerializeField] GameObject coin;
    public void SetMoveSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }

    void Start()
    {
        mainCamera = Camera.main;
        objectRenderer = GetComponent<Renderer>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position + objectRenderer.bounds.size / 2);
        if (viewportPosition.y < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // other.gameObject === 충돌한 게임 객체
        if (other.gameObject.tag == "Weapon")
        {
            Weapon weapon = other.GetComponent<Weapon>();
            hp -= weapon.damage;
            if (hp <= 0)
            {
                Destroy(gameObject);
                Instantiate(coin, transform.position, Quaternion.identity);

            }
            Destroy(other.gameObject);
        }
    }
}
