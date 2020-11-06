 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions.Must;
using TMPro;

public struct VictimLabelParams
{
    public string Name;
    public string Attacker;
    public string EnemyType;
    
}
[RequireComponent(typeof(Text))]
public class VictimLabel : MonoBehaviour
{
    public Text labelText;


    private void Awake()
    {  
        labelText = GetComponent<Text>();
    }

    public void SetVictim(VictimLabelParams victim)
    {
        ColorChange(labelText, victim.EnemyType);
        labelText.text = victim.Attacker+"                 "+victim.Name;
        Destroy(this);
    }
    void ColorChange(Text text,string type)
    {
        switch (type)
        {
            case "simpleUnit":
                text.color = Color.gray;
                break;
            case "mediumUnit":
                text.color = new Color(0, 255, 160);
                break;
            case "boss":
                text.color = Color.red;
                break;
        }
    }
}
