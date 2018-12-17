using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour
{
    public event Action BeforeSceneUnload;
    public event Action AfterSceneLoad;
    public event Action SlowAfterSceneLoad;


    public CanvasGroup faderCanvasGroup;
    public float fadeDuration = 1f;
    public string startingSceneName;
    public string initialStartingPositionName;
    public SaveData playerSaveData;

    private bool isFading;

    private IEnumerator Start ()
    {
        faderCanvasGroup.alpha = 1f;

        playerSaveData.Save (PlayerMovement.startingPositionKey, initialStartingPositionName);

        yield return StartCoroutine(LoadSceneAndSetActive(startingSceneName));
        if (AfterSceneLoad != null)
        {
            AfterSceneLoad();
        }
        if (SlowAfterSceneLoad != null)
        {
            SlowAfterSceneLoad();
        }

        StartCoroutine(Fade(0));
    }


    public void FadeAndLoadScene (SceneReaction sceneReaction)
    {
        if (!isFading)
        {
            StartCoroutine(FadeAndSwitchScenes(sceneReaction.sceneName));
        }
    }

    public void ClosePersistentScene()
    {
        SceneManager.LoadSceneAsync("Ending");
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("Persistent"));
    }

    private IEnumerator FadeAndSwitchScenes(string sceneName)
    {
        yield return StartCoroutine(Fade(1));
        if (BeforeSceneUnload != null)
        {
            BeforeSceneUnload();
        }
        yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        yield return StartCoroutine(LoadSceneAndSetActive(sceneName));
        if (AfterSceneLoad != null)
        {
            AfterSceneLoad();
        }
        if (SlowAfterSceneLoad != null)
        {
            SlowAfterSceneLoad();
        }
        yield return StartCoroutine(Fade(0));
    }


    private IEnumerator LoadSceneAndSetActive(string sceneName)
    {
        yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        Scene newlyLoadedScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
        SceneManager.SetActiveScene(newlyLoadedScene);
    }

    private IEnumerator Fade(float finalAlpha)
    {
        isFading = true;
        faderCanvasGroup.blocksRaycasts = true;

        float fadeSpeed = Mathf.Abs(faderCanvasGroup.alpha - finalAlpha)/fadeDuration;

        while (!Mathf.Approximately(faderCanvasGroup.alpha, finalAlpha))
        {
            faderCanvasGroup.alpha = Mathf.MoveTowards(faderCanvasGroup.alpha, finalAlpha, fadeSpeed*Time.deltaTime);
            yield return null;
        }

        isFading = false;
        faderCanvasGroup.blocksRaycasts = false;
    }
}
