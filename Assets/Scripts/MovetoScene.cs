using UnityEngine;
using UnityEngine.SceneManagement;

public class MovetoScene : MonoBehaviour
{
    [SerializeField] private string levelName;
    [SerializeField] private string modelName;

    public void ButtonMoveScene(string levelName)
    {
        Screen.orientation = ScreenOrientation.Portrait;
        PlayerPrefs.SetString("model", modelName);
        SceneManager.LoadScene(levelName);
    }
}
