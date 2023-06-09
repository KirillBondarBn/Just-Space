using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject spaceship; //An object camera will follow

    float lerpTime = 5000f;
    float currentLerpTime;

    float moveDistance = 10f;

    protected void Update()
    {
        //reset when we press spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentLerpTime = 0f;
        }

        //increment timer once per frame
        currentLerpTime = 10f;

        //lerp!
        float perc = currentLerpTime / lerpTime;
        transform.position = Vector3.Lerp(transform.position, spaceship.transform.position + Vector3.up * 15, perc);
    }
}
