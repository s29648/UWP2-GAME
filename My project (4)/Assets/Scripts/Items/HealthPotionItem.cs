using UnityEngine;

public class HealthPotionItem : ItemBase
{
  [SerializeField] private readonly int healAmount = 25;

  protected override bool TryApplyEffect(ItemCollector collector)
  {
    if (collector.Health == null)
    {
      return false;
    }

    collector.Health.Heal(healAmount);
    return true;
  }
}
