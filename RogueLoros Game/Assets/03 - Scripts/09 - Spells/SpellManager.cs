using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SpellType { None, Fireball, MegaFireball, Fenix, Heal, SuperHeal, Protection, Armor, SuperArmor, Arcane, Curse }

public class SpellManager: MonoBehaviour
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

    [Header("HUD Itens")]
    public List<Button> SpellsSlots;

    public Sprite EmptySlotImage;


    public GameObject CreateRandomSpell() {

        int index = Random.Range(0, SpellTypes.Count);

        return CreateSpell((SpellType)index);
    }

    public GameObject CreateSpell (SpellType type) {

        GameObject seletedSpell = null;

        // Verifica se tem espaço na HUD
        if (HasSpaceInHUD()) {

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

                foreach (GameObject spell in SpellTypes) {
                    if (spell.GetComponent<SpellActionMegaFireball>()) {
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
            AddSpell(Spell);

            return Spell;
        }

        return null;
    }

    // -------- Cuida das coisas da HUD de feitiços ---------

    private bool HasSpaceInHUD() {

        bool hasSpace = false;

        foreach(Button spellSlot in SpellsSlots) {
            if (spellSlot.GetComponent<SpellInstance>().CurrentSpell == null) {
                hasSpace = true;
                break;
            }
        }

        return hasSpace;
    }

    // Depois de usar uma spell reorganiza elas puxando para a esquerda
    private void ReorganizeSpellSlots() {

        for (int i=0; i==SpellsSlots.Count-1; i++) {

            if (SpellsSlots[i].GetComponent<SpellInstance>().CurrentSpell == null &&
                SpellsSlots[i+1].GetComponent<SpellInstance>().CurrentSpell != null) {

                AddSpell(SpellsSlots[i + 1].GetComponent<SpellInstance>().CurrentSpell);
                RemoveSpell(i+1);

                break;

            }

        }

    } 

    // Adiciona a Spell no primeiro espaço disponível
    private void AddSpell(GameObject spell) {

        foreach (Button spellSlot in SpellsSlots) {
            if (spellSlot.GetComponent<SpellInstance>().CurrentSpell == null) {
                spellSlot.GetComponent<SpellInstance>().CurrentSpell = spell;

                // Mudar para sprite no futuro
                spellSlot.GetComponent<Image>().color = spell.GetComponent<SpellAction>().HUDImage;

                break;
            }
        }
    }

    // Remove a Spell do espaço atual
    public void RemoveSpell(int index) {

        Destroy(SpellsSlots[index].GetComponent<SpellInstance>().CurrentSpell);
        SpellsSlots[index].GetComponent<SpellInstance>().CurrentSpell = null;
        // mudar isso pra sprite quando mudar
        SpellsSlots[index].GetComponent<Image>().color = Color.white;

        ReorganizeSpellSlots();
    }

    // Remove Spell direto do slot
    public void RemoveSpell(Button slot) {
        int counter = 0;

        foreach (Button spellSlot in SpellsSlots) {
            if (spellSlot == slot) {
                RemoveSpell(counter);
            }
            counter += 1;
        }
    }

}
