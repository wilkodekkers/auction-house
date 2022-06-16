using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadModel : MonoBehaviour
{   
    [SerializeField] private GameObject ContractModel;
    [SerializeField] private GameObject BottlingLineModel;
    [SerializeField] private GameObject PressModel;
    [SerializeField] private GameObject FridgeModel;

    void Start()
    {
        GameObject go = null;
        switch (PlayerPrefs.GetString("model")) {
            case "contract":
                go = Instantiate(ContractModel, transform.position, Quaternion.identity);
                break;
            case "bottlingline":
                go = Instantiate(BottlingLineModel, transform.position, Quaternion.identity);
                break;
            case "press":
                go = Instantiate(PressModel, transform.position, Quaternion.identity);
                break;
            case "fridge":
                go = Instantiate(FridgeModel, transform.position, Quaternion.identity);
                break;
            default:
                go =  Instantiate(BottlingLineModel, transform.position, Quaternion.identity);
                break;
        }
        go.transform.SetParent(transform);
    }
}
