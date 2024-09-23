using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Camera mainCamera;
    private Renderer objectRenderer;
    [SerializeField] float moveSpeed = 5f;
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
}
