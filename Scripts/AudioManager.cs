using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource bloodAudio;
    public AudioSource screamAudio;
    public AudioSource blockAudio;
    public AudioSource cheerAudio;
    public List<AudioClip> blockSFX;
    public AudioClip blood;
    public AudioClip scream;
    public AudioClip cheer;
    public AudioClip boo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBlood()
    {
        cheerAudio.volume = 1f;
        cheerAudio.PlayOneShot(blood);
    }

    public void PlayScream()
    {
        cheerAudio.volume = .4f;
        cheerAudio.PlayOneShot(scream);
    }

    public void PlayBlock()
    {
        cheerAudio.volume = 1f;
        int i = Random.Range(0, blockSFX.Count + 1);
        cheerAudio.PlayOneShot(blockSFX[i]);
    }

    public void PlayCheer()
    {
        cheerAudio.volume = .9f;
        cheerAudio.PlayOneShot(cheer);
    }
    public void PlayBoo()
    {
        cheerAudio.volume = .9f;
        cheerAudio.PlayOneShot(boo);
    }
}
