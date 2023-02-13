using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialAmbient : MonoBehaviour
{
    public AudioClip ambientmusic;
    [Range(0, 1)]
    public float volumeMusic;


    // Start is called before the first frame update
    void Start()
    {
        AudioManager.instance.PlayAudioOnLoop(ambientmusic, volumeMusic);
    }

}
