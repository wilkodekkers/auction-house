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
            "contract" => Instantiate(contractModel, Position, Quaternion.identity),
            "bottlingline" => Instantiate(bottlingLineModel, Position, Quaternion.identity),
            "press" => Instantiate(pressModel, Position, Quaternion.identity),
            "fridge" => Instantiate(fridgeModel, Position, Quaternion.identity),
            _ => Instantiate(bottlingLineModel, Position, Quaternion.identity)
        };
        Go.transform.SetParent(transform);
    }
}