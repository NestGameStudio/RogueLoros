using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Chest", menuName = "Chest")]
public class Chest : ScriptableObject
{
    public Sprite Image;

    public int Coin = 0;
    public int HealValue = 0;
    public int XP = 0;

    public List<SpellType> Feiticos;
}
