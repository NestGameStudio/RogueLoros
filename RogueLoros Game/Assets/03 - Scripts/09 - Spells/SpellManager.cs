using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpellType { None, Fireball, MegaFireball, Fenix, Heal, SuperHeal, Protection, Armor, SuperArmor, Arcane, Curse }

public class SpellManager : MonoBehaviour
{
    #region Singleton

    private static SpellManager _instance;
    public static SpellManager Instance { get { return _instance; } }

    private void Awake() {

        if (_instance != null && _instance != this) {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    #endregion

    [SerializeField]
    public List<GameObject> SpellTypes;

    public GameObject SpellsParent;

    public GameObject CreateRandomSpell() {

        int index = Random.Range(0, SpellTypes.Count);

        return CreateSpell((SpellType)index);
    }

    public GameObject CreateSpell (SpellType type) {

        GameObject seletedSpell = null;

        switch (type) {
            case SpellType.Fireball:

                foreach (GameObject spell in SpellTypes) {
                    if (spell.GetComponent<SpellActionFireball>()) {
                        seletedSpell = spell;
                        break;
                    }
                }

                break;
            case SpellType.MegaFireball:

                foreach (GameObject spell in SpellTypes){
                    if (spell.GetComponent<SpellActionMegaFireball>()){
                        seletedSpell = spell;
                        break;
                    }
                }

                break;
            case SpellType.Fenix:

                foreach (GameObject spell in SpellTypes) {
                    if (spell.GetComponent<SpellActionFenix>()) {
                        seletedSpell = spell;
                        break;
                    }
                }

                break;
            case SpellType.Heal:

                foreach (GameObject spell in SpellTypes) {
                    if (spell.GetComponent<SpellActionHeal>()) {
                        seletedSpell = spell;
                        break;
                    }
                }

                break;
            case SpellType.SuperHeal:

                foreach (GameObject spell in SpellTypes) {
                    if (spell.GetComponent<SpellActionSuperHeal>()) {
                        seletedSpell = spell;
                        break;
                    }
                }

                break;
            case SpellType.Protection:

                foreach (GameObject spell in SpellTypes) {
                    if (spell.GetComponent<SpellActionProtection>()) {
                        seletedSpell = spell;
                        break;
                    }
                }

                break;
            case SpellType.Armor:

                foreach (GameObject spell in SpellTypes) {
                    if (spell.GetComponent<SpellActionArmor>()) {
                        seletedSpell = spell;
                        break;
                    }
                }

                break;
            case SpellType.SuperArmor:

                foreach (GameObject spell in SpellTypes) {
                    if (spell.GetComponent<SpellActionSuperArmor>()) {
                        seletedSpell = spell;
                        break;
                    }
                }

                break;
            case SpellType.Arcane:

                foreach (GameObject spell in SpellTypes) {
                    if (spell.GetComponent<SpellActionArcane>()) {
                        seletedSpell = spell;
                        break;
                    }
                }

                break;
            case SpellType.Curse:

                foreach (GameObject spell in SpellTypes) {
                    if (spell.GetComponent<SpellActionCurse>()) {
                        seletedSpell = spell;
                        break;
                    }
                }

                break;
            default:
                Debug.LogError("Feitico nao existe");
                break;
        }

        GameObject Spell = Instantiate(seletedSpell, SpellsParent.transform);

        return Spell;
    }
}
