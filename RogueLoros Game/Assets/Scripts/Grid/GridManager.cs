using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int maxLinesPerGrid = 5;
    public GameObject linePrefab;

    private List<List<GameObject>> grid = new List<List<GameObject>>();

    /*GridManager() {
        createInitialGrid();
        Debug.Log("Criei Grid");
    }*/

    private void Start() {
        createInitialGrid();
    }

    // -------- Funções relativas a criar a grid -----------

    private void createInitialGrid() {

        for (int i=0; i<maxLinesPerGrid; i++) {

            GameObject line = Instantiate(linePrefab);
            line.transform.SetParent(this.transform);

            List<GameObject> nodeList = line.GetComponent<LineInstance>().getNodeList();
            grid.Add(nodeList);
        }

    }


}
