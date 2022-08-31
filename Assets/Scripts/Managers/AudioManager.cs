using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AudioClip collectSound;

    public void PlayCollectAudio(Vector3 position)
    {
        AudioSource.PlayClipAtPoint(collectSound, position);
    }
}
