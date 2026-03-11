using UnityEngine;

public class HealthPotionItem : ItemBase
{
  [SerializeField] private int healAmount = 25;

  protected override bool TryApplyEffect(IInteractionContext context)
  {
    if (context?.Health == null)
    {
      return false;
    }

    context.Health.Heal(healAmount);
    return true;
  }
}
