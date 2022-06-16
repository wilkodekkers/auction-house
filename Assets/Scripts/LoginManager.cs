using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoginManager : MonoBehaviour
{
    private TMP_InputField _email;
    private TMP_InputField _password;
    private TextMeshProUGUI _error;
    private Button _loginButton;

    private void Start()
    {
        _email = GameObject.Find("email_input_field").GetComponentInChildren<TMP_InputField>();
        _password = GameObject.Find("password_input_field").GetComponentInChildren<TMP_InputField>();
        _error = GameObject.Find("error_text").GetComponent<TextMeshProUGUI>();
        _loginButton = GameObject.Find("login_button").GetComponent<Button>();

        _loginButton.onClick.AddListener(Login);
    }

    private void Login()
    {
        if (_email.text == "" && _password.text == "")
        {
            _error.text = "Your credentials does not match!";
            return;
        }

        PlayerPrefs.SetString("email", _email.text);
        SceneManager.LoadScene("upcoming_auctions");
    }
}