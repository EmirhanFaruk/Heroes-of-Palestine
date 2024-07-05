using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public string sceneName;
    public void LoadScene() {
        // Sahneyi yukler.
        SceneManager.LoadScene(sceneName);
    }
    // Start is called before the first frame update
    public void ExitGame(){
        Application.Quit();
    }
}
