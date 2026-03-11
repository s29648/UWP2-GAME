using System;
using UnityEngine;

//Health only manages HP
public class Health : MonoBehaviour
{
  [SerializeField] private int maxHealth = 100;
  [SerializeField] private int currentHealth = 100;

  public int MaxHealth => maxHealth;
  public int CurrentHealth => currentHealth;

  public event Action<int, int> HealthChanged;

  private void Awake()
  {
    currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
  }

  public void Heal(int amount)
  {
    if (amount <= 0)
    {
      return;
    }

    int oldValue = currentHealth;
    currentHealth = Mathf.Min(maxHealth, currentHealth + amount);

    if (currentHealth != oldValue)
    {
      HealthChanged?.Invoke(currentHealth, maxHealth);
    }
  }

  public void TakeDamage(int amount)
  {
    if (amount <= 0)
    {
      return;
    }

    int oldValue = currentHealth;
    currentHealth = Mathf.Max(0, currentHealth - amount);

    if (currentHealth != oldValue)
    {
      HealthChanged?.Invoke(currentHealth, maxHealth);
    }
  }
}
