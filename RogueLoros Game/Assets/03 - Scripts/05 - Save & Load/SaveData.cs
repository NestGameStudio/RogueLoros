using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData {

    public int HealthLevel = 1;
    public int MagicLevel = 1;
    public int AttackLevel = 1;

    public SaveData(PlayerInstance player) {

        HealthLevel = player.HP.currentLevel;
        MagicLevel = player.MP.currentLevel;
        AttackLevel = player.AP.currentLevel;
    }

    public SaveData() { }

}
