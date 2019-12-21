using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class Enemy : ScriptableObject {

    public Sprite Image;

    public int Life = 0;
    public int AttackMin = 0;
    public int AttackMax = 0;
    public int XPDrop = 0;
    public int CoinDrop = 0;

}
