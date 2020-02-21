using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float tilt;

    private void Update()
    {
        if(Pause.Active)
            return;
        
        float mouseRotation = Input.GetAxis("Mouse Y");
        tilt = Mathf.Clamp(tilt - mouseRotation, -15f, 15f);
        transform.localRotation = Quaternion.Euler(tilt, 0,0);
    }
}
