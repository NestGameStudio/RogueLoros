using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyInstance))]
public class ActionEnemy : NodeAction
{
    // Qual o esquema aqui, o inimigo são de vários tipos, que tem ataques e vidas diferentes - scoobydoos
    // /\ Fazer um script pra cuidar dessa randomização EnemyInstance? 
    // Fazer presets de dificuldade para cada scoobydoo

    // Quando o player dar tap nesse botão, se ele for de combate, ele vai atacar sem sair do lugar
    // Se ele for derrotado, ele vai pro tile
    // Se ele não for derrotado o player sofre o dano e o inimigo tbm


    // Randomiza o ataque dentro do range do inimigo e desconta da vida do player
    // Faz o ataque do player no inimigo e desconta da vida do enemy
    // Se a vida do inimigo nao chegar a 0, nada acontece até que o player escolha atacar de novo
    // Se a vida do inimigo chegou a zero, o player recebe o XP e coin do inimigo e pode andar no tile
    // Chama a funcao de andar que está no PlayerMovimentation

    public override void DoAction() {
        base.DoAction();

        if (this.gameObject.GetComponent<EnemyInstance>().isBossNode) {

            Debug.Log("Chegou no boss");
            RunManager.Instance.WinRun();
        }
        
        //Debug.Log("Combate");
        ExperienceManager.Instance.IncreaseXPPoints(100);

        // Permite o player andar até o inimigo
        PlayerMovimentation.Instance.MovePlayer(this.gameObject);
        PlayerMovimentation.Instance.allowNextMovimentation();

    }

    public override void EndAction() {
        base.EndAction();
    }
}
