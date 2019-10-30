using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeInstance : MonoBehaviour
{
    [SerializeField]
    public List<GameObject> NodeType;

    private void Start() {
        Debug.Log("Criei Node");
    }

}
