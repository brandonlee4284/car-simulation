using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VectorSpace : MonoBehaviour
{
    private bool activateVectorSpace;
    //[SerializeField] private Text titleBox;
    [SerializeField] private GameObject panelBox;
    // Start is called before the first frame update
    void Start()
    {
        activateVectorSpace = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(activateVectorSpace){
            //titleBox.text = "Vector Space";
            panelBox.SetActive(true);
        }else{
            //titleBox.text = "";
            panelBox.SetActive(false);
        }
    }

    public void toggleVectorSpace()
    {
        if(activateVectorSpace){
            activateVectorSpace = false;
        }else{
            activateVectorSpace = true;
        }
    }
}
