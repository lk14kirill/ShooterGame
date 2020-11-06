using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MessageUI : MonoBehaviour
{
    public GameObject MessagePrefab;


    public RectTransform canvasTransform;

    private static MessageUI instance;
    public static MessageUI Instance 
    {
        get
        {
            if(instance == null)
            {
                instance = GameObject.FindObjectOfType<MessageUI>();
            }
            return instance;
        }
    }

    IEnumerator Scroll()
    {

        GetComponentInChildren<Message>().messageState = MessageState.moving;
        yield return new WaitForSeconds(5);
        

    }
    public void CreateMessage()
    {
        GameObject message = Instantiate(MessagePrefab, new Vector3(1300, 700, 0), Quaternion.identity);
        message.transform.SetParent(canvasTransform);
        message.GetComponent<RectTransform>();
        Destroy(message, 5);
        StartCoroutine("Scroll");
    }




}
