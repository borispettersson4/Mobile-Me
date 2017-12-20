using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

	public void restartScene()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void goToScene(string s)
    {
        //   SceneManager.UnloadScene(SceneManager.GetActiveScene());
        //  SceneManager.LoadScene(s);
        StartCoroutine(goToSceneDelayed(s));
    }

    public void exitGame()
    {
        Application.Quit();
    }

    IEnumerator goToSceneDelayed(string s)
    {
        yield return new WaitForSeconds(1f);

        SceneManager.UnloadScene(SceneManager.GetActiveScene());
        SceneManager.LoadScene(s);
    }


}
