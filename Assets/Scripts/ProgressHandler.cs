using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ProgressHandler : MonoBehaviour
{
    [SerializeField] private Image ProgressImage;
    [SerializeField] private float DefaultSpeed = 1f;
    [SerializeField] private UnityEvent<float> OnProgress; //guna buat display teks barnya
    [SerializeField] private UnityEvent OnCompleted;
    [SerializeField] private GameObject SendButton;
    [SerializeField] private Button TriggerButton;

    private Coroutine AnimationCoroutine;

    private void Awake()
    {
        TriggerButton.onClick.AddListener(() =>
        {
            SetProgress(1f);
            SendButton.SetActive(false);
        });
    }

    public void SetProgress(float progress)
    {
        SetProgress(progress, DefaultSpeed);
    }

    public void SetProgress(float progress, float speed)
    {
        if (progress != ProgressImage.fillAmount)
        {
            if (AnimationCoroutine != null)
            {
                StopCoroutine(AnimationCoroutine);
            }

            AnimationCoroutine = StartCoroutine(AnimateProgress(progress, speed));
        }
    }

    private IEnumerator AnimateProgress(float progress, float speed)
    {
        float time = 0;
        float initialProgress = ProgressImage.fillAmount;

        while (time < 1)
        {
            ProgressImage.fillAmount = Mathf.Lerp(initialProgress, progress, time);
            time += Time.deltaTime * speed;

            OnProgress?.Invoke(ProgressImage.fillAmount);
            yield return null;
        }

        ProgressImage.fillAmount = progress;
        OnProgress?.Invoke(progress);
        OnCompleted?.Invoke();
    }
}
