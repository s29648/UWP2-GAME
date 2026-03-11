using UnityEngine;

//Health only manages HP
public class Health : MonoBehaviour
{
  [SerializeField] private int maxHealth = 100;
  [SerializeField] private int currentHealth = 100;

  public int MaxHealth => maxHealth;
  public int CurrentHealth => currentHealth;

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

    currentHealth = Mathf.Min(maxHealth, currentHealth + amount);
    Debug.Log($"Healed {amount} HP. Current health: {currentHealth}/{maxHealth}");
  }

  public void TakeDamage(int amount)
  {
    if (amount <= 0)
    {
      return;
    }

    currentHealth = Mathf.Max(0, currentHealth - amount);
    Debug.Log($"Took {amount} damage. Current health: {currentHealth}/{maxHealth}");
  }
}
