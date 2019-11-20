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

    public bool cleanSave = false;

    public void ResetRun() {

        if (!cleanSave)
            SaveSystem.SaveData(PlayerInstance.Instance);
        else
            SaveSystem.ClearData();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
    }

    public void LoseRun() {

        Debug.Log(ExperienceManager.Instance.GetXPPoints() + " XP CURRENT");
        ExperienceManager.Instance.DisplayUIStats();
    }

}
