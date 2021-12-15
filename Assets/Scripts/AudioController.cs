using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    // Start is called before the first frame update

    public static AudioController instance = null;

    [SerializeField] AudioSource audioPlayerJump;

    public void Start()
    {
        instance = this;
    }

    public void PlayAudioJump()
    {
        audioPlayerJump.Play();
    }
}
