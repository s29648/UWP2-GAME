using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
  [SerializeField] private int coins;

  private readonly HashSet<string> storedItems = new HashSet<string>();

  public int Coins => coins;

  public void AddCoins(int amount)
  {
    if (amount <= 0)
    {
      return;
    }

    coins += amount;
  }

  public bool AddStoredItem(string itemId)
  {
    return storedItems.Add(itemId);
  }

  public bool HasStoredItem(string itemId)
  {
    return storedItems.Contains(itemId);
  }
}
