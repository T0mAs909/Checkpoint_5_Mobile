using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Player player;
    ScoreUI scoreUI;
    [SerializeField] int life;
    [SerializeField] float speed;
    public event Action<int> OnHealthChanged;

    void Start()
    {
        scoreUI = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreUI>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        if (life <= 0)
        {
            Destroy(gameObject);
            scoreUI.AddScore(1);
        }
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            player.TakeDamage(1);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(other.gameObject);
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
        OnHealthChanged?.Invoke(life);
    }
}