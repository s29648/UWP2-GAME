using UnityEngine;

public abstract class ItemBase : MonoBehaviour, IInteractable
{
    [SerializeField] private string itemName = "Item";
    [SerializeField] private bool destroyAfterPickup = true;

    public virtual string Prompt => $"Pick up {itemName}";

    public void Interact(ItemCollector collector)
    {
        if (collector == null)
        {
            return;
        }

        if (!TryApplyEffect(collector))
        {
            return;
        }

        if (destroyAfterPickup)
        {
            Destroy(gameObject);
        }
    }

    protected abstract bool TryApplyEffect(ItemCollector collector);
}
