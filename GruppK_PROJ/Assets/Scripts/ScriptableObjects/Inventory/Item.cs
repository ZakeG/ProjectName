﻿using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public Sprite sprite;
    public string itemName;
    public Condition pickedUp;
}
