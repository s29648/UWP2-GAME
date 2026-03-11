using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class ItemCollector : MonoBehaviour
{
  public enum PickupMode
  {
    PressKey,
    AutomaticOnEnter
  }

  [Header("Dependencies")]
  [SerializeField] private Inventory inventory;
  [SerializeField] private Health health;

  [Header("Interaction")]
  [SerializeField] private PickupMode pickupMode = PickupMode.PressKey;
  [SerializeField] private KeyCode interactKey = KeyCode.E;

  private readonly List<IInteractable> nearbyItems = new List<IInteractable>();

  public Inventory Inventory => inventory;
  public Health Health => health;

  private void Reset()
  {
    Collider triggerCollider = GetComponent<Collider>();
    if (triggerCollider != null)
    {
      triggerCollider.isTrigger = true;
    }
  }

  private void Update()
  {
    if (pickupMode != PickupMode.PressKey)
    {
      return;
    }

    if (Input.GetKeyDown(interactKey))
    {
      TryCollectClosest();
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    IInteractable interactable = other.GetComponentInParent<IInteractable>();
    if (interactable == null)
    {
      return;
    }

    if (!nearbyItems.Contains(interactable))
    {
      nearbyItems.Add(interactable);
    }

    if (pickupMode == PickupMode.AutomaticOnEnter)
    {
      Collect(interactable);
    }
  }

  private void OnTriggerExit(Collider other)
  {
    IInteractable interactable = other.GetComponentInParent<IInteractable>();

    if (interactable == null)
    {
      return;
    }

    nearbyItems.Remove(interactable);
  }

  private void TryCollectClosest()
  {
    nearbyItems.RemoveAll(item => item == null);
    if (nearbyItems.Count == 0)
    {
      return;
    }

    Collect(nearbyItems[0]);
  }

  private void Collect(IInteractable interactable)
  {
    if (interactable == null)
    {
      return;
    }

    interactable.Interact(this);
    nearbyItems.Remove(interactable);
  }
}
