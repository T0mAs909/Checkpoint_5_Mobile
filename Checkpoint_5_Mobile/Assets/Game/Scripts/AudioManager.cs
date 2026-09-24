using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Player player;
    [SerializeField] AudioClip[] audioClips;
    public AudioSource aus;

    public int PLAYERHIT = 0;
    public int PLAYERSHOOT = 1;

    void OnEnable()
    {
        player.OnHealthChanged += PlayDamageSound;
        player.OnShoot += PlayShootSound;
    }

    void OnDisable()
    {
        player.OnHealthChanged -= PlayDamageSound;
    }

    public void PlayDamageSound(int health)
    {
        aus.clip = audioClips[0];
        aus.Play();
    }

    public void PlayShootSound()
    {
        aus.clip = audioClips[1];
        aus.Play();
    }
}