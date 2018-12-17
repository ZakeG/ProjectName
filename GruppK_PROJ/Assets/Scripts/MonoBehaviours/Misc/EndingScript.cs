using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EndingScript : MonoBehaviour {

    public PointerContainer pc;

    void Start () {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
