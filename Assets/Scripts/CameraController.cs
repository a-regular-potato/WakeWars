using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector2 minWorldBounds;
    public Vector2 maxWorldBounds;
    
    public Vector2 cameraSpeed;

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(
            Input.GetAxis("Horizontal") * cameraSpeed.x * Time.deltaTime,
            Input.GetAxis("Vertical") * cameraSpeed.y * Time.deltaTime
        );
        Vector3 currentPos = transform.position,
            newPos = new Vector3(
                currentPos.x + input.x,
                currentPos.y,
                currentPos.z + input.y);

        transform.position = new Vector3(
            Mathf.Clamp(newPos.x, minWorldBounds.x, maxWorldBounds.x),
            currentPos.y,
            Mathf.Clamp(newPos.z, minWorldBounds.y, maxWorldBounds.y)
        );
    }
}
