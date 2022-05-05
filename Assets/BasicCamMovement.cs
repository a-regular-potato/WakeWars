using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCamMovement : MonoBehaviour
{
    bool Look;

    public float MouseSensitivty;
    public Transform Body;

    public float Speed;

    public float MinSpeed = 10f;
    public float MaxSpeed = 100f;

    private float xRot = 0f;
    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Look = true;
        }
        if (Input.GetButtonUp("Fire2"))
        {
            Look = false;
        }

        if (Look)
        {
            Cursor.lockState = CursorLockMode.Locked;
            float mouseX = Input.GetAxis("Mouse X") * MouseSensitivty * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * MouseSensitivty * Time.deltaTime;

            xRot -= mouseY;
            transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
            Body.Rotate(Vector3.up * mouseX);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKey(KeyCode.W))
        {
            Body.transform.position += (Speed * this.transform.forward * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Body.transform.position += (Speed * this.transform.forward * Time.deltaTime) * -1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            Body.transform.position += (Speed * this.transform.right * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Body.transform.position += (Speed * this.transform.right * Time.deltaTime) * -1f;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Body.transform.position += (Speed * this.transform.up * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Body.transform.position += (Speed * this.transform.up * Time.deltaTime) * -1f;
        }

        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if(Speed < MaxSpeed)
            {
                Speed += 1f;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (Speed > MinSpeed)
            {
                Speed -= 1f;
            }
        }
    }
}
