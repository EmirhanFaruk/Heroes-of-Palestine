using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void LoadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
    // Start is called before the first frame update
    public void ExitGame(){
        Application.Quit();
    }
}
