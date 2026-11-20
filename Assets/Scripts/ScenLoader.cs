using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenLoader : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    enum Scene
    {
        MainMenuScene,
        PlayScene,

    }

    [SerializeField] Scene scene;

    public void LoadScene()
    {
        SceneManager.LoadScene($"{scene}");
    }

    
      
    
}
