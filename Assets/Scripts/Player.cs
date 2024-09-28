using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    [SerializeField] private GameObject[] weapons;
    private int weaponIndex = 0;
    [SerializeField] private Transform shootTransform;

    [SerializeField] private float shootInterval = 0.1f;
    [SerializeField] private float hp = 1f;
    private float lastShotTime = 0f;

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float toX = Mathf.Clamp(mousePos.x, -2.8f, 2.8f);
        transform.position = new Vector3(toX, transform.position.y);

        Shoot();
    }

    void Shoot()
    {
        if (Time.time - lastShotTime > shootInterval)
        {
            Instantiate(weapons[weaponIndex], shootTransform.position, Quaternion.identity);
            lastShotTime = Time.time;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("게임 종료");
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Coin")
        {
            int totalCoin = GameManager.instance.IncreaseCoin();
            UpgradeWeapon(totalCoin);
            Destroy(other.gameObject);
        }
    }

    private void UpgradeWeapon(int coin)
    {
        if (coin >= 15)
        {
            weaponIndex = Math.Min(2, weapons.Length);
            return;
        }
        if (coin >= 5)
        {
            weaponIndex = Math.Min(1, weapons.Length);
            return;
        }
        weaponIndex = Math.Min(0, weapons.Length);
    }
}
