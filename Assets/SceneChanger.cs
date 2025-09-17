    using UnityEngine;
    using UnityEngine.SceneManagement; // Important!

    public class SceneChanger : MonoBehaviour
    {
        public void LoadSpecificScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public void LoadNextScene()
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }