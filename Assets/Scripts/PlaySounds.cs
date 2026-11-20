using UnityEngine;

public class PlaySounds : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void PlayFootSteps()
    {
        SfxScript.PlaySfcClip(SfxScript.SoundType.Walk);
    }
}
