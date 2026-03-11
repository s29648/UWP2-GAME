using UnityEngine;

// H calls TakeDamage, J calls Heal
public class HealthTester : MonoBehaviour
{
  [SerializeField] private Health health;
  [SerializeField] private int step = 10;

  private void Awake()
  {
    if (health == null) health = GetComponent<Health>();
    Debug.Log($"HP: {health.CurrentHealth}/{health.MaxHealth}");
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.H))
    {
      health.TakeDamage(step);
    }

    if (Input.GetKeyDown(KeyCode.J))
    {
      health.Heal(step);
    }
  }
}