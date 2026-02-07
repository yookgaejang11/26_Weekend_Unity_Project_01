using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float rotSpeed = 200f;

    float mx;
    float my;

    public float rotateLimit = 45;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        mx += mouseX * rotSpeed * Time.deltaTime;
        my += mouseY * rotSpeed * Time.deltaTime;

        my = Mathf.Clamp(my, rotateLimit, rotateLimit);
    }
}
