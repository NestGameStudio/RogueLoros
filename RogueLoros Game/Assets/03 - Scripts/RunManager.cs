using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunManager : MonoBehaviour
{
    public void ResetRun() {

        SaveSystem.SaveData(PlayerInstance.Instance);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
