using UnityEngine;
using UnityEngine.SceneManagement;

public class MovetoScene : MonoBehaviour
{
    [SerializeField] private string levelName;

    public void ButtonMoveScene(string levelName)
    {
        Screen.orientation = ScreenOrientation.Portrait;
        SceneManager.LoadScene(levelName);
    }
}
