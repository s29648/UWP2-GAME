using UnityEngine;

public abstract class ItemBase : MonoBehaviour, IInteractable
{
  private bool destroyAfterPickup = true;

  public void Interact(IInteractionContext context)
  {
    if (context == null)
    {
      return;
    }

    if (!TryApplyEffect(context))
    {
      return;
    }

    if (destroyAfterPickup)
    {
      Destroy(gameObject);
    }
  }

  protected abstract bool TryApplyEffect(IInteractionContext context);
}
