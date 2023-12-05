using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class Teleport_Player : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private GameObject target;
    [SerializeField] private Transform newLookAtTarget;
    [SerializeField] private Transform newFollowTarget;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;

    [SerializeField] private float fadeDuration = 1f;
    [SerializeField] private Image fadeImage;


    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Player")
        {
            StartCoroutine(TeleportAndFade());
        }
    }

    private IEnumerator TeleportAndFade()
    {
        yield return StartCoroutine(FadeOut());

        player.transform.position = new Vector2(target.transform.position.x, target.transform.position.y);

        ChangeCinemachineTarget();

        yield return StartCoroutine(FadeIn());
    }

    private IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        Color startColor = fadeImage.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1f);

        while(elapsedTime < fadeDuration)
        {
            fadeImage.color = Color.Lerp(startColor, endColor, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        fadeImage.color = endColor;
        Debug.Log("Fading Out");
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        Color startColor = fadeImage.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

        while(elapsedTime < fadeDuration)
        {
            fadeImage.color = Color.Lerp(startColor, endColor, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        fadeImage.color = endColor;
        Debug.Log("Fading In");
    }

    private void ChangeCinemachineTarget()
    {
        if(virtualCamera == null)
        {
            virtualCamera = Camera.main.GetComponent<CinemachineVirtualCamera>();
        }

        virtualCamera.LookAt = newLookAtTarget;
        virtualCamera.Follow = newFollowTarget;
    }
}
