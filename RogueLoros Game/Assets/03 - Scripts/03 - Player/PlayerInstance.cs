﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInstance: MonoBehaviour
{

    #region Singleton

    private static PlayerInstance _instance;
    public static PlayerInstance Instance { get { return _instance; } }

    private void Awake() {

        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    #endregion

    // Player Stats
    [HideInInspector] public HealthPoints HP;
    [HideInInspector] public MagicPoints MP;
    [HideInInspector] public AttackPoints AP;

    [HideInInspector] public SaveData Data;

    // Start is called before the first frame update
    void Start() {
        HP = this.GetComponent<HealthPoints>();
        MP = this.GetComponent<MagicPoints>();
        AP = this.GetComponent<AttackPoints>();

        Data = SaveSystem.LoadData();

        HP.LoadStat();
        MP.LoadStat();
        AP.LoadStat();

        ExperienceManager.Instance.LoadXP();

        ExperienceManager.Instance.UpdateUI();
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKey(KeyCode.F)) {
            // Player morreu
            RunManager.Instance.LoseRun();
        }

        if (Input.GetKey(KeyCode.R)) {
            // Reseta o save
            RunManager.Instance.cleanSave = true;
        }
        
    }
}
