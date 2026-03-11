using UnityEngine;


// H calls TakeDamage, J calls Heal
public class HealthTester : MonoBehaviour
{
  [SerializeField] private Health health;
  [SerializeField] private int step = 10;

  private void Awake()
  {
    if (health == null) health = GetComponent<Health>();

    health.HealthChanged += OnHealthChanged;
    Debug.Log($"Start HP: {health.CurrentHealth}/{health.MaxHealth}");
  }

  private void OnDestroy()
  {
    if (health != null) health.HealthChanged -= OnHealthChanged;
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.H))
      health.TakeDamage(step);

    if (Input.GetKeyDown(KeyCode.J))
      health.Heal(step);
  }

  private void OnHealthChanged(int current, int max)
  {
    Debug.Log($"HP: {current}/{max}");
  }
}