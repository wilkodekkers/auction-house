using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    private TMP_InputField email;
    private TMP_InputField password;
    private TextMeshProUGUI error;
    private Button loginButton;

    private void Start()
    {
        email = GameObject.Find("email_input_field").GetComponentInChildren<TMP_InputField>();
        password = GameObject.Find("password_input_field").GetComponentInChildren<TMP_InputField>();
        error = GameObject.Find("error_text").GetComponent<TextMeshProUGUI>();
        loginButton = GameObject.Find("login_button").GetComponent<Button>();

        loginButton.onClick.AddListener(Login);
    }

    private void Login()
    {
        if (email.text == "developer@inchainge.com" && password.text == "inchainge")
        {
            SceneManager.LoadScene("upcomming_auctions");
        }
        else
        {
            error.text = "Your credentials does not match!";
        }
    }
}
