using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRoadManager : MonoBehaviour
{
    public AudioLoudnessDetection detector;

    public float loudnessSensitivity = 10000;
    public float threshold = 0f;
    public float baseSpeed = 2f;
    private float currentSpeed;

    // Start is called before the first frame update
    void Start()
    {


        currentSpeed = baseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (detector == null) return;

        // Get loudness from the microphone and adjust speed
        float loudness = detector.GetLoudnessFromMicrophone() * loudnessSensitivity;
        //Debug.Log(loudness);
        if (loudness < threshold)
        {
            loudness = 0;
        }


        currentSpeed = baseSpeed + loudness;


        MoveRoadObjects();
    }

    private void MoveRoadObjects()
    {
        GameObject[] roads = GameObject.FindGameObjectsWithTag("Road");
        foreach (GameObject road in roads)
        {
            road.transform.position += new Vector3(0, 0, -currentSpeed) * Time.deltaTime;
        }
    }
}
