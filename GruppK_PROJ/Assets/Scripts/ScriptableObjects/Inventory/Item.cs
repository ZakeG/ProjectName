﻿using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public Sprite sprite;
    public string itemName;
    public Condition pickUpCondition;
    public string tooltipMessage;
}
