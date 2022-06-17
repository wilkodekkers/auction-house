using UnityEngine;

public class LoadModel : MonoBehaviour
{
    [SerializeField] private GameObject contractModel;
    [SerializeField] private GameObject bottlingLineModel;
    [SerializeField] private GameObject pressModel;
    [SerializeField] private GameObject fridgeModel;

    private void Start()
    {
        var Position = transform.position;
        var Go = PlayerPrefs.GetString("model") switch
        {
            "contract" => LoadContractModel(),
            "bottlingline" => LoadBottlingLine(),
            "press" => Instantiate(pressModel, Position, Quaternion.identity),
            "fridge" => Instantiate(fridgeModel, Position, Quaternion.identity),
            _ => Instantiate(bottlingLineModel, Position, Quaternion.identity)
        };
        Go.transform.SetParent(transform);
    }

    private GameObject LoadContractModel()
    {
        var Model = Instantiate(contractModel, transform.position, Quaternion.identity);
        Model.transform.localScale = new Vector3(.3f, .3f, .3f);
        Model.transform.position += new Vector3(0f, .3f, 0f);

        return Model;
    }

    private GameObject LoadBottlingLine()
    {
        var Model = Instantiate(bottlingLineModel, transform.position, Quaternion.identity);
        Model.transform.localScale = new Vector3(.1f, .1f, .1f);
        Model.transform.position += new Vector3(-2f, .3f, -4f);

        return Model;
    }
}