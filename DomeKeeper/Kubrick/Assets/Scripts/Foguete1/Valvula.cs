using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Valvula : MonoBehaviour
{
    public float rotationSpeed = 100f;
    //public float maxRotation = 360f;

    private bool isTurning = false, playingSound;
    private float previousMouseAngle = 0f;

    public Image pression;
    public ValvulaManager valvulaManager;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && valvulaManager.win == false)
        {
            isTurning = true;
            previousMouseAngle = GetMouseAngle();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (playingSound)
            {
                SoundManager.instance.Stop("CrankSewer1");
                playingSound = false;
            }

            isTurning = false;
            valvulaManager.CheckWin();
        }

        if (isTurning)
        {
            if (!playingSound)
            {
                playingSound = true;
                SoundManager.instance.Play("CrankSewer", 1);
            }

            float currentMouseAngle = GetMouseAngle();
            float rotationAmount = Mathf.DeltaAngle(currentMouseAngle, previousMouseAngle);
            previousMouseAngle = currentMouseAngle;

            RotateManivela(rotationAmount * rotationSpeed * Time.deltaTime);
            pression.fillAmount -= rotationAmount * 0.0025f;
        }
    }

    private float GetMouseAngle()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 objectPosition = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 mouseOffset = mousePosition - objectPosition;
        return Mathf.Atan2(mouseOffset.y, mouseOffset.x) * Mathf.Rad2Deg;
    }

    private void RotateManivela(float rotationAmount)
    {
        float currentRotation = transform.localEulerAngles.z;
        //float newRotation = Mathf.Clamp(currentRotation + (rotationAmount * -1f), 0f, maxRotation);
        float newRotation = currentRotation + (rotationAmount * -1f);

        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y, newRotation);

        //transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, newRotation);
    }
}
