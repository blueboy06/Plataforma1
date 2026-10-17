using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent (typeof(Collider2D))]
public class Health : MonoBehaviour
{
    Collider2D collider2d;

    float currentHealth;
    [SerializeField] int maxHealth = 100;
    [SerializeField] bool canDie = true;
    bool isVulnerable = true;
    public float invulnerabilityTime = 2f;

    public bool IsVulnerable => isVulnerable;

    SpriteRenderer spriteRenderer;
    [SerializeField] float flashTime = 0.2f;
    Color flashColor;
    Color originalColor;

    public UnityEvent OnHealthChanged;
    public UnityEvent OnDamageTaken;
    public UnityEvent OnHealthIncreased;
    public UnityEvent OnDeath;

    //Getters
    public float CurrentHealth => currentHealth;
    public float MaxHealth => maxHealth;

    private void Start()
    {
        ChangeHealth(maxHealth);

        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        flashColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0.3f);
    }

    private void ChangeHealth(float newHealth)
    {
        currentHealth = newHealth;
        OnHealthChanged.Invoke();
    }

    public void TakeDamage(float damage)
    {
        ChangeHealth(Mathf.Max(0, currentHealth - damage));
        OnDamageTaken.Invoke();

        if (currentHealth == 0 && canDie)
        {
            OnDeath.Invoke();
        }
    }

    public void IncreaseHealth(float amountToHeal)
    {
        ChangeHealth(Mathf.Min(maxHealth, currentHealth + amountToHeal));
        OnHealthIncreased.Invoke();
    }

    public void HandleVulnerabilityOnHit()
    {
        isVulnerable = false;
        StartCoroutine(WaitToMakeVulnerable());
        StartCoroutine(InvulnerabilityFlash());
    }

    IEnumerator WaitToMakeVulnerable()
    {
        yield return new WaitForSeconds(invulnerabilityTime);
        isVulnerable = true;
    }

    IEnumerator InvulnerabilityFlash()
    {
        while (!isVulnerable)
        {
            spriteRenderer.color = flashColor;
            yield return new WaitForSeconds(flashTime);
            spriteRenderer.color = originalColor;
            yield return new WaitForSeconds(flashTime);
        }
    }
}


