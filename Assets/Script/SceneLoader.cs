using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    /// <summary>
    /// �V�[���J�ڂ̊֐�
    /// </summary>
    /// <param name="sceneName">�J�ڂ���V�[���̖��O</param>
    public static void SceneChange(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
