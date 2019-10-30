using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public GameObject linePrefab;
    public GameObject nodePrefab;   // usado meramente para calcular o numero de linhas na tela
    public GameObject initialNode;

    public float offSetBetweenLines = 0.5f;

    private List<List<GameObject>> nodeList = new List<List<GameObject>>();
    private List<GameObject> lineList = new List<GameObject>();

    private int maxLinesPerGrid = 4;
    private float nodeSize;

    private int lineCounter = 0;

    private void Start() {
        calculateMaxNumOfLines();
        createInitialGrid();
    }

    // -------- Funções relativas a criar a grid inicial -----------

    private void createInitialGrid() {

        for (int i=0; i<maxLinesPerGrid; i++) {

            GameObject line = Instantiate(linePrefab, calculatePostitionInWorld(i), linePrefab.transform.rotation, this.transform);
            line.GetComponent<LineInstance>().ID = lineCounter;
            this.lineList.Add(line);

            List<GameObject> nodeList = line.GetComponent<LineInstance>().getNodeList();
            this.nodeList.Add(nodeList);

            lineCounter++;
        }

    }

    private void calculateMaxNumOfLines() {

        int height = Screen.height;

        // Utiliza o tamanho do node para calcular quantas linhas caberão na tela - fake
        nodeSize = nodePrefab.GetComponent<Renderer>().bounds.size.y;

        // substituir maxLinesPerGrid = numLinesVertical quando for essa funcao estiver direita
        int numLinesVertical = (int) (height / (nodeSize + offSetBetweenLines));
        //Debug.Log(numLinesVertical);
    }

    private Vector3 calculatePostitionInWorld(int i) {

        Vector3 linePos = new Vector3(0, initialNode.transform.position.y + (nodeSize + offSetBetweenLines) + (nodeSize + offSetBetweenLines) * i, 0);
        //Vector3 lineWorldPos = Camera.main.ScreenToWorldPoint(linePos);

        return linePos;

    }


}
