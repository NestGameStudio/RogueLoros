using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunManager : MonoBehaviour
{

    #region Singleton

    private static RunManager _instance;
    public static RunManager Instance { get { return _instance; } }

    private void Awake() {

        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    #endregion

    [HideInInspector] public bool cleanSave = false;

    // Isso tem que ser carregado no save
    private int currentRun = 1;

    public void ResetRun() {

        if (!cleanSave)
            SaveSystem.SaveData(PlayerInstance.Instance);
        else
            SaveSystem.ClearData();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
    }

    public void LoseRun() {

        ExperienceManager.Instance.DisplayUIStats();
    }

    public void WinRun() {

        Debug.Log("Derrotou o boss, venceu a run");

        currentRun += 1;
        // O que acontece depois daqui?
        ExperienceManager.Instance.DisplayUIStats();
    }

    public int getCurrentRun() {
        return currentRun;
    }


}
