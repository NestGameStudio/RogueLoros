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

    private EnemyInstance enemyStats;

    private void Start()
    {
        gameObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
        //gameObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);    
    }

    public override void DoAction()
    {
        base.DoAction();

        enemyStats = this.GetComponent<EnemyInstance>();

        if (this.gameObject.GetComponent<EnemyInstance>().isBossNode)
        {

            Debug.Log("Chegou no boss");
            RunManager.Instance.WinRun();
        }

        // Faz o ataque inimigo no player
        int damageEnemy = Random.Range(enemyStats.Attack.GetMinPossibleAttackRange(), enemyStats.Attack.GetMaxPossibleAttackRange() + 1);
        PlayerInstance.Instance.DecreaseHealth(damageEnemy);

        // Faz o ataque player no inimigo
        int damagePlayer = Random.Range(PlayerInstance.Instance.AP.GetMinPossibleAttackRange(), PlayerInstance.Instance.AP.GetMaxPossibleAttackRange() + 1);
        enemyStats.Life.DecreaseLifePoints(damagePlayer);
        enemyStats.DisplayInHUD();

        //Shake camera
        EZCameraShake.CameraShaker.Instance.ShakeOnce(10, 7, .1f, .1f);
        
        // Player ganhou do inimigo
        if (enemyStats.Life.GetCurrentLife() <= 0 && PlayerInstance.Instance.HP.GetCurrentLife() > 0)
        {

            // Recompensas de matar o inimigo

            gameObject.transform.GetChild(0).GetChild(0).gameObject.SetActive(false);
            gameObject.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);

            ExperienceManager.Instance.IncreaseXPPoints(enemyStats.XPDrop);
            PlayerInstance.Instance.IncreaseMoney(enemyStats.CoinDrop);

            int dropkey = Random.Range(0, 2);
            if (dropkey == 1)
            {
                PlayerInstance.Instance.Keys += 1;
            }

            // Permite o player andar até a posicao do inimigo
            PlayerMovimentation.Instance.MovePlayer(this.gameObject);
            PlayerMovimentation.Instance.allowNextMovimentation();
        }
    }

    public override void EndAction()
    {
        base.EndAction();
    }
}
