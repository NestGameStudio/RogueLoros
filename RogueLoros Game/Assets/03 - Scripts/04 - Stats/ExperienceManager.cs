﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceManager: MonoBehaviour
{
    #region Singleton

    private static ExperienceManager _instance;
    public static ExperienceManager Instance { get { return _instance; } }

    private void Awake() {

        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    #endregion

    public GameObject PlayerStatsUI;

    public Button HPLevelUp;
    public Text HPValueLabel;
    public Text HPNextLevelXPLabel;

    public Button MPLevelUp;
    public Text MPValueLabel;
    public Text MPNextLevelXPLabel;

    public Button APLevelUp;
    public Text APValueLabel;
    public Text APNextLevelXPLabel;

    public Text XPPointsLabel;

    private int currentXP = 0;

    // -------- Funções relativas ao load de jogo -----------

    public void LoadXP() {

        if (PlayerInstance.Instance.Data != null) {
            Debug.Log(PlayerInstance.Instance.Data.XP);
            currentXP = PlayerInstance.Instance.Data.XP;
        }
    }

    // -------- Funções relativas a UI de Level UP -----------

    public void DisplayUIStats() {

        if (!PlayerStatsUI.gameObject.activeSelf)
            PlayerStatsUI.SetActive(true);

        updateLevelUpPanelLabels();
        checkIfXPLevelUpButtonIsInteractabel();
    }

    private void updateLevelUpPanelLabels() {

        XPPointsLabel.text = currentXP.ToString();

        HPValueLabel.text = PlayerInstance.Instance.HP.GetMaxPossibleLife().ToString();
        MPValueLabel.text = PlayerInstance.Instance.MP.GetMinPossibleMagicRange().ToString() + "-" + PlayerInstance.Instance.MP.GetMaxPossibleMagicRange().ToString();
        APValueLabel.text = PlayerInstance.Instance.AP.GetMinPossibleAttackRange().ToString() + "-" + PlayerInstance.Instance.AP.GetMaxPossibleAttackRange().ToString();

        HPNextLevelXPLabel.text = PlayerInstance.Instance.HP.GetNextLevelXP() + " XP";
        MPNextLevelXPLabel.text = PlayerInstance.Instance.MP.GetNextLevelXP() + " XP";
        APNextLevelXPLabel.text = PlayerInstance.Instance.AP.GetNextLevelXP() + " XP";
    }

    private void checkIfXPLevelUpButtonIsInteractabel() {

        if (currentXP >= PlayerInstance.Instance.HP.GetNextLevelXP()) {
            HPLevelUp.interactable = true;
        } else { HPLevelUp.interactable = false; }

        if (currentXP >= PlayerInstance.Instance.MP.GetNextLevelXP()) {
            MPLevelUp.interactable = true;
        } else { MPLevelUp.interactable = false; }

        if (currentXP >= PlayerInstance.Instance.AP.GetNextLevelXP()) {
            APLevelUp.interactable = true;
        } else { APLevelUp.interactable = false; }
    }

    // -------- Funções relativas a manutenção do XP -----------

    public void IncreaseLevel(int statType) {

        Stats stat = null;

        switch (statType) {
            // Health
            case 0:
                stat = PlayerInstance.Instance.HP;
                break;
            // Attack
            case 1:
                stat = PlayerInstance.Instance.AP;
                break;
            // Magic
            default:
                stat = PlayerInstance.Instance.MP;
                break;
        }

        DecreaseXPPoints(stat.GetNextLevelXP());
        stat.IncreaseLevel();

        DisplayUIStats();
    }

    private void DecreaseXPPoints(int value) {

        currentXP -= value;
        XPPointsLabel.text = currentXP.ToString();
    }

    public void IncreaseXPPoints(int value) {
        currentXP += value;
    }

    public int GetXPPoints() {
        return currentXP;
    }

}
