using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour

{
    static public AudioManager instance;
    private List<GameObject> activeAudioGameObjects;
    private AudioManager audioManager;
    public AudioClip jumpSound;
    void Awake()
    {
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            activeAudioGameObjects = new List<GameObject>();
            DontDestroyOnLoad(gameObject);
        }
    }




    //volumen: [0, 1]
    public AudioSource PlayAudio(AudioClip clip, float volume = 1)
    {
        GameObject sourceObj = new GameObject(clip.name); //crea un nuevo objeto
        activeAudioGameObjects.Add(sourceObj);
        sourceObj.transform.SetParent(this.transform); //Lo transforma en padre
        AudioSource source = sourceObj.AddComponent<AudioSource>();
        source.clip = clip; //para meter el archivo
        source.volume = volume;  //se ajusta el volumen
        source.Play();
        StartCoroutine(PlayAudio(source)); //empieza el audio
        return source;

    }

    public AudioSource PlayAudioOnLoop(AudioClip clip, float volume = 1)
    {
        GameObject sourceObj = new GameObject(clip.name);
        activeAudioGameObjects.Add(sourceObj);
        sourceObj.transform.SetParent(this.transform);
        AudioSource source = sourceObj.AddComponent<AudioSource>();
        source.clip = clip;
        source.volume = volume;
        source.loop = true;
        source.Play();
        return source;
    }

    public void ClearAudioList()
    {
        foreach (GameObject go in activeAudioGameObjects)
        {
            Destroy(go);
        }
        activeAudioGameObjects.Clear();
    }
    IEnumerator PlayAudio(AudioSource source)
    {
        while (source && source.isPlaying)
        {
            yield return null;
        }
        if (source)
        {
            activeAudioGameObjects.Remove(source.gameObject);
            Destroy(source.gameObject);
        }
    }
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void Jump()
    {
        if (Input.GetKeyUp(KeyCode.Space))
            audioManager.GetComponent<AudioSource>().clip = audioManager.jumpSound;
        audioManager.GetComponent<AudioSource>().Play();
    }
}

