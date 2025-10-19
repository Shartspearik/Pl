using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UISoundPlayer : MonoBehaviour
{
    public AudioClip[] soundClips;
    private AudioSource sfxAudioSource;

    [Header("Background Music")]
    public AudioSource bgmAudioSource;
    public AudioSource bgmAudioSource1;
    public AudioClip backgroundMusic;

    public Slider volumeSlider;

    // Управление позиционированием слайдера
    public RectTransform sliderRectTransform;
    public float slideDistance = 300f;
    public float slideDuration = 0.3f;

    private bool isSliderVisible = false;
    private Vector2 sliderHiddenPosition;
    private Vector2 sliderVisiblePosition;
    private Coroutine slideCoroutine;

    private void Awake()
    {
        sfxAudioSource = GetComponent<AudioSource>();
        if (bgmAudioSource != null && backgroundMusic != null)
        {
            bgmAudioSource.clip = backgroundMusic;
            bgmAudioSource.loop = true;
            bgmAudioSource.Play();
        }

        if (volumeSlider != null)
        {
            volumeSlider.onValueChanged.AddListener(SetMusicVolume);
            volumeSlider.value = bgmAudioSource.volume;
        }

        if (sliderRectTransform != null)
        {
            sliderHiddenPosition = sliderRectTransform.anchoredPosition;
            sliderVisiblePosition = sliderHiddenPosition + new Vector2(slideDistance, 0);
        }
    }

    public void PlaySound(int index)
    {
        if (soundClips == null || sfxAudioSource == null || index < 0 || index >= soundClips.Length)
            return;

        sfxAudioSource.PlayOneShot(soundClips[index]);
    }

    public void SetMusicVolume(float volume)
    {
        if (bgmAudioSource != null)
        {
            bgmAudioSource.volume = volume;
            bgmAudioSource1.volume = volume;
        }
    }

    // Метод для переключения состояния слайдера по нажатию
    public void ToggleSlider()
    {
        if (slideCoroutine != null)
        {
            StopCoroutine(slideCoroutine);
        }
        if (isSliderVisible)
        {
            slideCoroutine = StartCoroutine(SlideToPosition(sliderRectTransform, sliderHiddenPosition));
        }
        else
        {
            slideCoroutine = StartCoroutine(SlideToPosition(sliderRectTransform, sliderVisiblePosition));
        }
        isSliderVisible = !isSliderVisible;
    }

    private IEnumerator SlideToPosition(RectTransform rectTransform, Vector2 targetPosition)
    {
        Vector2 startPosition = rectTransform.anchoredPosition;
        float elapsed = 0f;

        while (elapsed < slideDuration)
        {
            rectTransform.anchoredPosition = Vector2.Lerp(startPosition, targetPosition, elapsed / slideDuration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        rectTransform.anchoredPosition = targetPosition;
    }
}
