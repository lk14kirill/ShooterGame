 using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Security.Policy;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;
using UnityEngineInternal;

public struct GameHitInfo
{
    public RaycastUI Instagator;
    public GameObject Victim;
    public Sprite weaponIcon;
    public string enemyType;
}
public class RaycastUI : MonoBehaviour
{
   
        GunInventory ginv;

    private static RaycastUI ray;
    public static RaycastUI Ray
    {
        get
        {
            if (ray == null)
            {
                ray = GameObject.FindObjectOfType<RaycastUI>();
            }
            return ray;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        ginv = GetComponent<GunInventory>();
    }

    // Update is called once per frame
    void Update()
    {

          


        
    }
   public  IEnumerator  RayShoot()
    {
        Ray CameraRay = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        
        if (Physics.Raycast(CameraRay, out RaycastHit hit))
        {
            if (hit.collider.gameObject.CompareTag("Dead")&& hit.collider.gameObject.GetComponent<AIManager>().state == States.dead)
            {


                    MessageUI.Instance.CreateMessage();
                    
                GameHitInfo gameHitInfo;
                gameHitInfo.Instagator = this;
                gameHitInfo.Victim = hit.collider.gameObject;
                gameHitInfo.weaponIcon = ginv.currentGun.GetComponent<GunScript>().Icon;
                gameHitInfo.enemyType = hit.collider.gameObject.GetComponent<AIManager>().type;
                yield return new WaitForSeconds(1);
                   
                LevelUI.GetLevelUI.OnSomebodyHitted(gameHitInfo);
                   

            }
        }
    }
    public void Setting(RaycastHit hit)
    {
        
    }
}
