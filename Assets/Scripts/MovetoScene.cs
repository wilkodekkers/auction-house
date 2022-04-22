using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovetoScene : MonoBehaviour
{
    public void ButtonMoveScene() 
    {
        SceneManager.LoadScene("UpcomingAuction");
        Debug.Log("Tapped");
    }
}
