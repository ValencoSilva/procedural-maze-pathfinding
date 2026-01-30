using UnityEngine;
using UnityEngine.SceneManagement;

///Controls the switching of scenes between Game to Menu

public class SceneLoader : MonoBehaviour
{
  

    public void LoadMenu()
    {
        SceneManager.LoadScene("UI");
    }

   
}
