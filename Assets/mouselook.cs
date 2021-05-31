using UnityEngine;

public class mouselook : MonoBehaviour
{   
    public float mouseSens=100f;
    public Transform player;
    float roatationy = 0f;
    float roatationx = 0f;
    void Start(){
        Cursor.lockState=CursorLockMode.Locked;
    }
    void FixedUpdate()
    {
        float mouseX=Input.GetAxis("Mouse X")*mouseSens*Time.deltaTime;
        float mouseY=Input.GetAxis("Mouse Y")*mouseSens*Time.deltaTime;
        roatationy-=mouseY;
        roatationx+=mouseX;
        roatationy=Mathf.Clamp(roatationy,-90f,70f);
        roatationx=Mathf.Clamp(roatationx,-70f,70f);
        transform.localRotation=Quaternion.Euler(roatationy,0f,0f);
        player.transform.localRotation=Quaternion.Euler(0f,roatationx,0f);
    }
}

