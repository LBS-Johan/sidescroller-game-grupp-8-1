using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    int maxHealth = 1;

    int health;

    [SerializeField]
    AudioClip hurtSound;

    [SerializeField]
    GameObject deathObject;

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        health = maxHealth;
    }

    public void Hurt(int amount)
    {
        health -= amount;
        if (audioSource != null && hurtSound != null)
        {
            audioSource.PlayOneShot(hurtSound);
        }

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (deathObject != null)
        {
            GameObject go = Instantiate(deathObject, transform.position, Quaternion.identity);
            Destroy(go, 0.6f);
        }

        Destroy(gameObject);
    }
}
