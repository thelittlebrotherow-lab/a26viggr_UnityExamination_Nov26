using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VolumeScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] Slider volumeSlider;
    [SerializeField] private Slider pitchSlider;
    [SerializeField] private TextMeshProUGUI valueText;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = volumeSlider.value;
        audioSource.pitch = pitchSlider.value;

        valueText.text = $"{volumeSlider.value}%";
    }
}
