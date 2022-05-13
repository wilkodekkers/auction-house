using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovetoScene : MonoBehaviour
{
    [SerializeField] private string levelName;

    public void ButtonMoveScene(string levelName) 
    {
        SceneManager.LoadScene(levelName);
    }
}
