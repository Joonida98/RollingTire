using UnityEngine.SceneManagement;
using UnityEngine;

public class Events : MonoBehaviour
{
    public void ReplayGame()
    {
        SceneManager.LoadScene("Level 1"); //이동할 씬
    }

    public void QuitGame()
    {
        Application.Quit();  //게임 종료
    }
}
