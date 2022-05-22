using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    private readonly Dictionary<string, AudioClip> clipsByName = new Dictionary<string, AudioClip>();

    public void Initialize()
    {
        var clips = Resources.LoadAll<AudioClip>("Sounds");
        foreach (var clip in clips)
        {
            clipsByName.Add(clip.name, clip);
        }
    }

    public void PlayOneShot(string clipName)
    {
        if (clipsByName.TryGetValue(clipName, out var clip))
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
