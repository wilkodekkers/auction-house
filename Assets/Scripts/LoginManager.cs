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
    private Firebase.FirebaseApp app;

    private void Start()
    {
        email = GameObject.Find("email_input_field").GetComponentInChildren<TMP_InputField>();
        password = GameObject.Find("password_input_field").GetComponentInChildren<TMP_InputField>();
        error = GameObject.Find("error_text").GetComponent<TextMeshProUGUI>();
        loginButton = GameObject.Find("login_button").GetComponent<Button>();

        loginButton.onClick.AddListener(Login);
    }

    private void SetupFireBase()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                app = Firebase.FirebaseApp.DefaultInstance;

                // Set a flag here to indicate whether Firebase is ready to use by your app.
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });
    }

    private void Login()
    {
        if (email.text == "developer@inchainge.com" && password.text == "inchainge")
        {
            SceneManager.LoadScene("upcoming_auctions");
        }
        else
        {
            error.text = "Your credentials does not match!";
        }
    }
}
