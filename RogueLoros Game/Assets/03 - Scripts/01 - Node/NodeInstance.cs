using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public enum NodeType { None, Health, Enemy }

public class NodeInstance : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> NodeTypes;

    //private NodeType tipo = NodeType.None;

    public GameObject RandomizeType() {

        int rand = Random.Range(0, NodeTypes.Count);
        return NodeTypes[rand];
    }
    


}
