using UnityEngine;

public class KeyItem : ItemBase
{
    [SerializeField] private string keyId = "DefaultKey";

    protected override bool TryApplyEffect(ItemCollector collector)
    {
        if (collector.Inventory == null)
        {
            Debug.LogWarning("KeyItem: missing Inventory reference on ItemCollector.");
            return false;
        }

        return collector.Inventory.AddStoredItem(keyId);
    }
}
