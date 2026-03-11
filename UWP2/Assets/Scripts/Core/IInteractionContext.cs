using UnityEngine;

public interface IInteractionContext
{
  Inventory Inventory { get; }
  Health Health { get; }
}
