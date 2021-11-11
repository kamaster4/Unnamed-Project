using UnityEngine;
using System.Collections;

/*
 * Sterowanie:
 * Myszka+prawy przycisk myszy
 * przyspieszenie spacja
 * kierunki wsad
 */
public class FlyCamera : MonoBehaviour
{
    float mainSpeed = 10.0f;
    float shiftAdd = 20.0f;
    float maxShift = 80.0f;
    float camSens = 0.2f;
    private Vector3 lastMouse = new Vector3(255, 255, 255);
    private float totalRun = 1.0f;

    void Update()
    {
        lastMouse = Input.mousePosition - lastMouse;
        lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
        lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
        if(Input.GetMouseButton(1))
            transform.eulerAngles = lastMouse;
        lastMouse = Input.mousePosition;
        Vector3 p = GetBaseInput();
        if (Input.GetKey(KeyCode.Space))
        {
            totalRun += Time.deltaTime;
            p = p * totalRun * shiftAdd;
            p.x = Mathf.Clamp(p.x, -maxShift, maxShift);
            p.y = Mathf.Clamp(p.y, -maxShift, maxShift);
            p.z = Mathf.Clamp(p.z, -maxShift, maxShift);
        }
        else
        {
            totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
            p = p * mainSpeed;
        }
        p = p * Time.deltaTime;
        Vector3 newPosition = transform.position;
        transform.Translate(p);
    }
    private Vector3 GetBaseInput()
    {
        float move=1f;
        move = Mathf.SmoothStep(move, move, 1000 * Time.deltaTime);
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey(KeyCode.W))
            p_Velocity += new Vector3(0, 0, move);
        if (Input.GetKey(KeyCode.S))
            p_Velocity += new Vector3(0, 0, -move);
        if (Input.GetKey(KeyCode.A))
            p_Velocity += new Vector3(-move, 0, 0);
        if (Input.GetKey(KeyCode.D))
            p_Velocity += new Vector3(move, 0, 0);
        return p_Velocity;
    }
}