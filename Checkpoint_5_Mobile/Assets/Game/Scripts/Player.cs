using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int health;
    public event Action<int> OnHealthChanged;
    public event Action OnShoot;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform weaponPosition;
    bool canShoot = true;
    [SerializeField] TextMeshProUGUI textGameOver;

    void Start()
    {
        Time.timeScale = 1;
        textGameOver.enabled = false;
    }

    void Update()
    {
        if (Time.timeScale > 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                if (canShoot)
                {
                    Instantiate(bullet, weaponPosition.position, Quaternion.identity);
                    canShoot = false;
                    StartCoroutine(Recharge());
                    OnShoot();
                }
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("GameScene");
            }
        }
        if (health <= 0)
        {
            Time.timeScale = 0;
            textGameOver.enabled = true;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        OnHealthChanged?.Invoke(health);
    }

    IEnumerator Recharge()
    {
        yield return new WaitForSeconds(1);
        canShoot = true;
    }
}