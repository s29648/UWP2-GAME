using UnityEngine;

public class CoinItem : ItemBase
{
  [SerializeField] private readonly int amount = 1;

  protected override bool TryApplyEffect(ItemCollector collector)
  {
    if (collector.Inventory == null)
    {
      return false;
    }

    collector.Inventory.AddCoins(amount);
    return true;
  }
}
