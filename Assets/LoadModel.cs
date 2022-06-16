using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadModel : MonoBehaviour
{
    [SerializeField] private GameObject ModelParent;

    [SerializeField] private GameObject ContractModel;
    [SerializeField] private GameObject BottlingLineModel;
    [SerializeField] private GameObject Press;
    [SerializeField] private GameObject Fridge;

    void Start()
    {
        var modelName = PlayerPrefs.GetString("model");
        GameObject go = null;
        switch (modelName) {
            case "contract":
                go = Instantiate(ContractModel, ModelParent.transform.position, Quaternion.identity);
                break;
            case "bottlingline":
                go = Instantiate(BottlingLineModel, ModelParent.transform.position, Quaternion.identity);
                break;
            case "press":
                go = Instantiate(Press, ModelParent.transform.position, Quaternion.identity);
                break;
            case "fridge":
                go = Instantiate(Fridge, ModelParent.transform.position, Quaternion.identity);
                break;
            default:
                break;
        }
        if (go != null) {
            go.transform.SetParent(ModelParent.transform);
        }
    }
}
