using UnityEngine;
using System;

[RequireComponent(typeof(AudioSource)), ExecuteInEditMode]

public class SfxScript : MonoBehaviour
{

    public enum SoundType
    {
        Walk,
    }
    [SerializeField] private SoundList[] soundList;
    public static SfxScript sfx;
    private AudioSource audioSource;

    private void Awake()
    {
        sfx = this;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySfcClip(SoundType sounds, float volume = 1)
    {
       
        AudioClip[] clips = sfx.soundList[(int)sounds].Sounds;
        AudioClip randomClip = clips[UnityEngine.Random.Range(0, clips.Length)];
        sfx.audioSource.PlayOneShot(randomClip, volume);
    }


#if UNITY_EDITOR

    private void OnEnable()
    {
        string[] names = Enum.GetNames(typeof(SoundType));
        Array.Resize(ref soundList, names.Length);

        for(int i = 0; i < soundList.Length; i++)
        {
            soundList[i].name = names[i];
        }
    }

#endif

    [Serializable]
    public struct SoundList
    {
        public AudioClip[] Sounds { get => sounds; }
        [HideInInspector] public string name;
        [SerializeField] private AudioClip[] sounds;
        
    }
}







