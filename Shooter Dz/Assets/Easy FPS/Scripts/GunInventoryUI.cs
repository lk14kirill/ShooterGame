using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.UI;

public class GunInventoryUI : MonoBehaviour
{
    public GunInventory gInv;
    
    public KeyCode InterractKey = KeyCode.Tab;
    public Canvas Inventory;
    public static bool revealed;
    [Header("Frames")]
    public List<Image> Frames = new List<Image>();
    public Image currentFrame;
    public Image prevFrame;
    [Header("Buttons")]
    public List<Button> Buttons = new List<Button>();
    public Button currentButton;
    public Button prevButton;


    void TurnOffWeaponButton(int number)
    {
        prevButton.enabled = true;
        currentButton = Buttons[number];
        currentButton.enabled = false;
        prevButton = currentButton;
    }
    void Revealing(Canvas inventory)
    {
        if (inventory.enabled)
        {
            inventory.enabled = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            revealed = false;
        }
        else
        {
            inventory.enabled = true;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            revealed = true;
        }

    }
    private void Start()
    {
        
        Revealing(Inventory);
        prevFrame = Frames[0];
        prevButton = Buttons[0];
        Cursor.lockState = CursorLockMode.Locked;
        prevFrame.color = new Color(0, 255, 0);
    }
    void Update()
    {
        if (Input.GetKeyDown(InterractKey))
        {
            Revealing(Inventory);
        }
    }
    public void TakeGun(int gunNumber)
    {
        gInv.switchWeaponCooldown = 0;
        //print("name:"+ GetComponentInChildren<Button>().name);
        //gunNumber = int.Parse(GetComponent<GunInventoryUI>().name);
        //print("number:" + gunNumber);
        TurnOffWeaponButton(gunNumber);
        DrawCorrespondingImage(gunNumber);
        gInv.StartCoroutine("Spawn", gunNumber);
        gunNumber = 0;
    }
    void DrawCorrespondingImage(int number)
    {
        prevFrame.color = new Color(255, 255, 255);
        currentFrame = Frames[number];
        currentFrame.color = new Color(0, 255, 0);
        prevFrame = currentFrame;

    }
    
}
