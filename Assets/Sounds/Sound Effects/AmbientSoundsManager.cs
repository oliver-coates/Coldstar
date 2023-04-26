using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmbientSoundsManager : MonoBehaviour
{
    public List<AudioClip> sounds;
    
    public List<AudioSource> audioSources;

    [SerializeField]
    private float randomTimeLower;
    [SerializeField]
    private float randomTimeUpper;

    [SerializeField]
    private float randomVolumeUpper;

    [SerializeField]
    private float soundPlayedRandomTimeIncreaseAmount;

    [SerializeField]
    private float randomVolumeLower;
    

    private AudioClip lastPlayedSound;
    
    [SerializeField]
    private float cooldownTime;

    // Start is called before the first frame update
    void Start()
    {
        cooldownTime = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTime -= Time.deltaTime;

        if (cooldownTime < 0f)
        {
            PlayRandomSound();
            cooldownTime = UnityEngine.Random.Range(randomTimeLower, randomTimeUpper);
            randomTimeUpper += soundPlayedRandomTimeIncreaseAmount;

        }
    }

    private AudioSource GetRandomAudioSource()
    {
        return audioSources[UnityEngine.Random.Range(0,audioSources.Count)];
    }

    private AudioClip GetRandomSound()
    {
        while (true)
        {
            AudioClip clip = sounds[UnityEngine.Random.Range(0, sounds.Count)];
            if (clip != lastPlayedSound)
            {
                lastPlayedSound = clip;
                return clip;
            }
        }
    }

    private float GetRandomVolume()
    {
        return UnityEngine.Random.Range(randomVolumeLower, randomVolumeUpper);
    }

    private void PlayRandomSound()
    {
        GetRandomAudioSource().PlayOneShot(GetRandomSound(), GetRandomVolume());
    }
}
