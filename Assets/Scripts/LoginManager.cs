using Firebase.Database;
using Firebase.Extensions;
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
    DatabaseReference reference;

    private void Start()
    {
/*        SetupFireBase();*/
        reference = FirebaseDatabase.DefaultInstance.RootReference;

        /*Auction auction1 = new Auction(502000, "Super line");
        Auction auction2 = new Auction(41700, "Juicy juicer");
        string auction1Json = JsonUtility.ToJson(auction1);
        string auction2Json = JsonUtility.ToJson(auction2);

        reference.Child("Auctions").Child("Auction 1").SetRawJsonValueAsync(auction1Json);
        reference.Child("Auctions").Child("Auction 2").SetRawJsonValueAsync(auction2Json)
;*/

        reference.Child("Auctions").GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                DataSnapshot snapshot = task.Result;
                Debug.Log(snapshot.Child("Auction 1").Child("CurrentBid").Value.ToString());
            }

            else
            {
                Debug.Log("Nee");
            }
        });


        email = GameObject.Find("email_input_field").GetComponentInChildren<TMP_InputField>();
        password = GameObject.Find("password_input_field").GetComponentInChildren<TMP_InputField>();
        error = GameObject.Find("error_text").GetComponent<TextMeshProUGUI>();
        loginButton = GameObject.Find("login_button").GetComponent<Button>();

        loginButton.onClick.AddListener(Login);
    }

    private void SetupFireBase()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
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

    public void GetDatabaseReference()
    {
        reference = FirebaseDatabase.DefaultInstance.RootReference;
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

    public class Auction
    {
        public int CurrentBid;
        public string ItemName;

        public Auction(int bid, string name)
        {
            this.CurrentBid = bid;
            this.ItemName = name;
        }
    }

}
