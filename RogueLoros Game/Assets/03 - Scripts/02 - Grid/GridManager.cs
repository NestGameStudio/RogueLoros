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

    public int maxLinesPerGrid = 6;
    public float offSetBetweenLines = 0.5f;

    private List<List<GameObject>> nodeList = new List<List<GameObject>>();
    private List<GameObject> lineList = new List<GameObject>();

    private float nodeSize;

    private int lineCounter = 0;
    private int removedLineCounter = 0;

    private int maxLineInRun = 10;

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

        maxLineInRun = DifficultyManager.Instance.RunLines[DifficultyManager.Instance.GetCurrentRun()];
    }

    // -------- Funções relativas a criar a grid inicial -----------

    private void createInitialGrid() {

        for (int i=0; i<maxLinesPerGrid - 2; i++) {

            GameObject line = Instantiate(linePrefab, calculatePostitionInWorld(i, initialNode), linePrefab.transform.rotation, this.transform);
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
    }

    private Vector3 calculatePostitionInWorld(int ID, GameObject currentNode) {

        Vector3 linePos;

        // Radomiza se a linha vai ficar deslocada ou não
        int rand = Random.Range(0, 3);

        if (rand % 2 == 0) {
            float offSetBetweenNodes = linePrefab.GetComponent<LineInstance>().offSetBetweenNodes;
            linePos = new Vector3(currentNode.transform.position.x + offSetBetweenNodes/2 , initialNode.transform.position.y + (nodeSize + offSetBetweenLines) + (nodeSize + offSetBetweenLines) * ID, 0);
        } else {
            linePos = new Vector3(currentNode.transform.position.x, initialNode.transform.position.y + (nodeSize + offSetBetweenLines) + (nodeSize + offSetBetweenLines) * ID, 0);
        }
        
        return linePos;
    }

    // -------- Funções relativas a manutencao da grid inicial -----------

    public void AddLineInGrid(GameObject currentNode) {

        if (lineCounter < maxLineInRun) {
            GameObject line = Instantiate(linePrefab, calculatePostitionInWorld(lineCounter, currentNode), linePrefab.transform.rotation, this.transform);
            line.GetComponent<LineInstance>().ID = lineCounter;
            this.lineList.Add(line);

            List<GameObject> nodeLineList = line.GetComponent<LineInstance>().getNodeList();
            this.nodeList.Add(nodeLineList);

            lineCounter++;

            if (lineCounter > maxLinesPerGrid) {
                RemoveLineInGrid(GetLine(lineCounter - maxLinesPerGrid - 1));
            }
            
        } else if (lineCounter == maxLineInRun) {

            GameObject line = Instantiate(linePrefab, calculatePostitionInWorld(lineCounter, currentNode), linePrefab.transform.rotation, this.transform);
            // Cria o Boss
        } 
    }

    public void RemoveLineInGrid(GameObject line)
    {
        this.lineList.Remove(line);
        this.nodeList.Remove(line.GetComponent<LineInstance>().getNodeList());

        Destroy(line);
        
        removedLineCounter++;
    }

    // -------- Funções de acesso a grid -----------

    public List<GameObject> GetAllLines() {

        if (lineList.Count > 0)
            return lineList;
        else
            Debug.LogError("Grid não tem linhas existentes");

        return null;
    }

    public GameObject GetLine(int index) {

        if (lineList[index - removedLineCounter])
            return lineList[index - removedLineCounter];
        else
            Debug.LogError("Index a linha não existe");

        return null;
    }

}
