using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MessageState
{
    moving,idle
}
public class Message : MonoBehaviour
{
    public float speed;
    public Vector3  direction;
    public static bool ifItCanGoUp;
    public MessageState messageState;
    private static Message message;
    public static Message messagee
    {
        get
        {
            if (message == null)
            {
                message = GameObject.FindObjectOfType<Message>();
            }
            return message;
        }
    }
    void Start()
    {
        direction = Vector3.up;
        ifItCanGoUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        float translation = speed * Time.deltaTime;
        if (messageState== MessageState.moving)
        {
            transform.Translate(direction * translation);
        }

    }
    public void GoUp()
    {

    }
}
