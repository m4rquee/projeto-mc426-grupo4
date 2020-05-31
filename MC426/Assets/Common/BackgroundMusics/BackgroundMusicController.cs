using UnityEngine;

public class BackgroundMusicController : MonoSingleton<BackgroundMusicController>
{
    [SerializeField] private AudioSource _backgroundMusic;

    // Start is called before the first frame update
    private void Start()
    {
        _backgroundMusic.Play();
    }
}
