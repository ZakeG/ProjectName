using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FailMessageHandler : MonoBehaviour {

    [SerializeField]
    private GameObject failMessageBackground;
    [SerializeField]
    private Text failText;

    public IEnumerator ShowFailMessage(FailedItemCombination fic)
    {
        failMessageBackground.SetActive(true);
        failText.text = fic.GetFailMessage();
        yield return new WaitForSeconds(2);
        failText.text = string.Empty;
        failMessageBackground.SetActive(false);
    }
    public IEnumerator ShowDefaultFailMessage()
    {
        failMessageBackground.SetActive(true);
        failText.text = "That combination doesn't work!";
        yield return new WaitForSeconds(2);
        failText.text = string.Empty;
        failMessageBackground.SetActive(false);
    }
}
