using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstance : MonoBehaviour
{
    // escolhe qual scoobydoo randomizado esse inimigo vai ser 
    // Faz os ajustes de dificuldade - poe o inimigo no preset certo dele

    // tem uma funcao onde quando é intanciado e é boss, carrega os dados do boss
    [HideInInspector]
    public bool isBossNode = false;

    // Start is called before the first frame update
    void Start()
    {
        isBossNode = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
