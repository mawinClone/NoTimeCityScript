using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance;


    public AudioSource audioSource;
    public List<AudioClip> clipList;
    public float volume=0.5f;

    private void Awake() {
        Instance = this;
    }


    void Start()
    {
        
    }

    public void ShopSound()
    {
        audioSource.PlayOneShot(clipList[0], volume);
    }

    public void CorrectSound()
    {
        audioSource.PlayOneShot(clipList[1], volume);
    }
    public void WrongSound()
    {
        audioSource.PlayOneShot(clipList[2], volume);
    }
    public void ClickSound()
    {
        audioSource.PlayOneShot(clipList[3], volume);
    }




    


}
