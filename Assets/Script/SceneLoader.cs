using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    /// <summary>
    /// シーン遷移の関数
    /// </summary>
    /// <param name="sceneName">遷移するシーンの名前</param>
    public static void SceneChange(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
