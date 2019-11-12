using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private static GridManager _instance;
    public static GridManager Instance { get { return _instance; } }

    public GameObject linePrefab;
    public GameObject nodePrefab;   // usado meramente para calcular o numero de linhas na tela
    public GameObject initialNode;

    public float offSetBetweenLines = 0.5f;

    private List<List<GameObject>> nodeList = new List<List<GameObject>>();
    private List<GameObject> lineList = new List<GameObject>();

    private int maxLinesPerGrid = 4;
    private float nodeSize;

    private int lineCounter = 0;

    private void Awake() {
        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }        
    }

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

            List<GameObject> nodeLineList = line.GetComponent<LineInstance>().getNodeList();
            this.nodeList.Add(nodeLineList);

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

    // -------- Funções relativas a manutencao da grid inicial -----------

    public void AddLineInGrid()
    {
        GameObject line = Instantiate(linePrefab, calculatePostitionInWorld(lineCounter), linePrefab.transform.rotation, this.transform);
        line.GetComponent<LineInstance>().ID = lineCounter;
        this.lineList.Add(line);

        List<GameObject> nodeLineList = line.GetComponent<LineInstance>().getNodeList();
        this.nodeList.Add(nodeLineList);

        lineCounter++;
    }

    public void RemoveLineInGrid(GameObject line)
    {
        this.lineList.Remove(line);
        this.nodeList.Remove(line.GetComponent<LineInstance>().getNodeList());

        Destroy(line);
    }

    // -------- Funções de acesso a grid -----------

    public List<GameObject> GetAllLines() {

        if (lineList.Count > 0)
            return lineList;
        else
            Debug.LogError("Linha não tem elementos");

        return null;
    }

    public GameObject GetLine(int index) {

        if (lineList[index])
            return lineList[index];
        else
            Debug.LogError("Index a linha não existe");

        return null;
    }

}
