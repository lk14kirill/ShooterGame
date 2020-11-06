using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct IconParams
{
    public Sprite icon;
}
[RequireComponent(typeof(Image))]
public class IconUI : MonoBehaviour
{
    public Image WeaponIcon;
    // Start is called before the first frame update
    private void Awake()
    {
        WeaponIcon = GetComponent<Image>();
    }

    public void SetIcon(IconParams iconparams)
    {
        WeaponIcon.color = new Color(0, 0, 0, 200);
        WeaponIcon.sprite = iconparams.icon;
        Destroy(this);
    }
}
