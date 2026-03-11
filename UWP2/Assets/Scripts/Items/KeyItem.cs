using UnityEngine;

public class KeyItem : ItemBase
{
    [SerializeField] private string keyId = "just_a_key";

    protected override bool TryApplyEffect(IInteractionContext context)
    {
        if (context?.Inventory == null)
        {
            return false;
        }

        return context.Inventory.AddStoredItem(keyId);
    }
}
