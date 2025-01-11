using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLoudnessDetection : MonoBehaviour
{

    public int sampleWindow = 64;
    private AudioClip MicrophoneClip;

    void Start()
    {
        MicrophoneToAudioClip();
        Debug.Log(Microphone.devices[0]);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public float GetLoudnessFromMicrophone()
    {
        return GetLoadnessFromAudioClip(Microphone.GetPosition(Microphone.devices[0]), MicrophoneClip);
    }

    public void MicrophoneToAudioClip()
    {
        string microphoneName = Microphone.devices[0];
        MicrophoneClip = Microphone.Start(microphoneName, true, 20, AudioSettings.outputSampleRate);
    }

    public float GetLoadnessFromAudioClip(int clipPosition, AudioClip clip)
    {
        int startPosition = clipPosition - sampleWindow;

        if (startPosition < 0)
        {
            startPosition = 0;
        }
        float[] waveData = new float[sampleWindow];
        clip.GetData(waveData, startPosition);

        //Compute loudness
        float totalLoudness = 0;

        for (int i = 0; i < sampleWindow; i++)
        {
            totalLoudness += Mathf.Abs(waveData[i]);

        }

        return totalLoudness / sampleWindow;
    }
}
