using System;
using System.Collections.Generic;
using UnityEngine;

//Inventory only manages coins and stored items
public class Inventory : MonoBehaviour
{
  [SerializeField] private int coins;

  private readonly HashSet<string> storedItems = [];

  public int Coins => coins;

  public event Action<int> CoinsChanged;
  public event Action<string> StoredItemAdded;

  public void AddCoins(int amount)
  {
    if (amount <= 0)
    {
      return;
    }

    coins += amount;
    CoinsChanged?.Invoke(coins);
  }

  public bool AddStoredItem(string itemId)
  {
    if (string.IsNullOrWhiteSpace(itemId))
    {
      return false;
    }

    bool added = storedItems.Add(itemId);
    if (added)
    {
      StoredItemAdded?.Invoke(itemId);
    }

    return added;
  }

  public bool HasStoredItem(string itemId)
  {
    return !string.IsNullOrWhiteSpace(itemId) && storedItems.Contains(itemId);
  }
}
