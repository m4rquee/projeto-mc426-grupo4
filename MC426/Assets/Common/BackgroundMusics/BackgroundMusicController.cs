using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusicController : MonoSingleton<BackgroundMusicController>
{
    [SerializeField] private AudioSource _backgroundMusic;
    
    // Start is called before the first frame update
    void Start()
    {
        _backgroundMusic.Play();
    }

}
