using UnityEngine;

public class CameraShake : MonoBehaviour
{

    public float ShakeAmount;
    float ShakeTime;
    Vector3 initialPosition = new Vector3(0f, 0f, -10f);

    //private bool _isShake;

    public void ShakeForTime(float time)
    {
        ShakeAmount = time;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.F)) ShakeForTime(1.5f);

        if(ShakeTime > 0)
        {

        }
        else
        {
            ShakeTime = 0f;
            transform.position = initialPosition;
        }
    }




}
