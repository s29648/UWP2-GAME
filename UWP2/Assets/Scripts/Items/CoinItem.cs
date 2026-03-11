using UnityEngine;

public class CoinItem : ItemBase
{
  [SerializeField] private int amount = 1;

  protected override bool TryApplyEffect(IInteractionContext context)
  {
    if (context?.Inventory == null)
    {
      return false;
    }

    context.Inventory.AddCoins(amount);
    return true;
  }
}
