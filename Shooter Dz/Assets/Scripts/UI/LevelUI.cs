using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    public static LevelUI GetLevelUI{get;private set;}

    public VictimLabel victimLabel;
    public IconUI UIIcon;

    private void Update()
    {
        victimLabel = GetComponentInChildren<VictimLabel>();
        UIIcon = GetComponentInChildren<IconUI>();
    }
    public void OnSomebodyHitted(GameHitInfo gameHitInfo)
    {
        VictimLabelParams victimlabelparams;
        IconParams iconparams;
        victimlabelparams.Name = gameHitInfo.Victim.name;
        victimlabelparams.Attacker = gameHitInfo.Instagator.name;
        victimlabelparams.EnemyType = gameHitInfo.enemyType;
        iconparams.icon = gameHitInfo.weaponIcon;
        victimLabel.SetVictim(victimlabelparams);
        UIIcon.SetIcon(iconparams);
    }
    private void Awake()
    {
        GetLevelUI = this;
    }
}
