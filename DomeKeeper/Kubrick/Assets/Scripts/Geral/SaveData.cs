using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public string obj;

    private void OnEnable()
    {
        if (PlayerPrefs.GetFloat(obj + "X") != 0 || PlayerPrefs.GetFloat(obj + "RotY") != 0)
        {
            transform.localPosition = new Vector3(PlayerPrefs.GetFloat(obj + "X"),
                            PlayerPrefs.GetFloat(obj + "Y"),
                            PlayerPrefs.GetFloat(obj + "Z"));

            transform.eulerAngles = new Vector3(PlayerPrefs.GetFloat(obj + "RotX"),
                                                  PlayerPrefs.GetFloat(obj + "RotY"),
                                                  PlayerPrefs.GetFloat(obj + "RotZ"));

        }
    }

    private void OnDisable()
    {
        Save(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z,
            transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
    }

    public void Save(float x, float y, float z, float rotX, float rotY, float rotZ)
    {
        PlayerPrefs.SetFloat(obj + "X", x);
        PlayerPrefs.SetFloat(obj + "Y", y);
        PlayerPrefs.SetFloat(obj + "Z", z);
        PlayerPrefs.SetFloat(obj + "RotX", rotX);
        PlayerPrefs.SetFloat(obj + "RotY", rotY);
        PlayerPrefs.SetFloat(obj + "RotZ", rotZ);
    }
}
