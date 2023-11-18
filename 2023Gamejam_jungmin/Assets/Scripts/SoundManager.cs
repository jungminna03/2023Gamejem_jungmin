using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public enum ClipName { PLANETSELECT, ENDBUYING, }

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;

    private AudioSource audioSource;
    [SerializeField]
    private AudioClip[] clipList;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        audioSource = instance.GetComponent<AudioSource>();
    }

    //테스트 용
    private ClipName clipName;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        { 
            PlaySound(ClipName.PLANETSELECT);
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            PlaySound(ClipName.ENDBUYING);
        }
    }
    //==============================================

    public static SoundManager getInstance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }

    public void PlaySound(ClipName clipName)
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        AudioClip audioClip = clipList[(int)clipName];
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
