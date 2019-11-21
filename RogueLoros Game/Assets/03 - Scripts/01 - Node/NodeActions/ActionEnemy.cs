using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionEnemy : NodeAction
{
    // Qual o esquema aqui, o inimigo são de vários tipos, que tem ataques e vidas diferentes - scoobydoos
    // /\ Fazer um script pra cuidar dessa randomização EnemyInstance? 
    // Fazer presets de dificuldade para cada scoobydoo

    // Quando o player dar tap nesse botão, se ele for de combate, ele vai atacar sem sair do lugar
    // Se ele for derrotado, ele vai pro tile
    // Se ele não for derrotado o player sofre o dano e o inimigo tbm


    public override void DoAction() {
        base.DoAction();
        
        Debug.Log("Combate");
        ExperienceManager.Instance.IncreaseXPPoints(100);

    }

    public override void EndAction() {
        base.EndAction();
    }
}
