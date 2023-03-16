using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AmbientSoundsManager : MonoBehaviour
{
    public List<SoundSchedule> sounds;

    [SerializeField]
    private float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (sounds.Count == 0) { return; }

        if (timeElapsed > sounds[0].timeToPlay)
        {
            
            Debug.Log("Playing sound: " + sounds[0].clip.name);
            // Play sound
            sounds[0].sourceToPlayAt.PlayOneShot(sounds[0].clip, sounds[0].volume);

            // Remove from list
            sounds.RemoveAt(0);
        }
    }
}

[Serializable]
public class SoundSchedule
{
    public AudioClip clip;
    public AudioSource sourceToPlayAt;
    public float timeToPlay;
    public float volume;
}