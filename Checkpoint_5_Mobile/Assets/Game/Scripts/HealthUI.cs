using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public Player player;
    public TextMeshProUGUI textLife;

    void OnEnable()
    {
        player.OnHealthChanged += UpdateHealth;
        textLife.text = "Life: " + player.health;
    }

    void OnDisable()
    {
        player.OnHealthChanged -= UpdateHealth;
    }

    public void UpdateHealth(int health)
    {
        textLife.text = "Life: " + health;
    }
}