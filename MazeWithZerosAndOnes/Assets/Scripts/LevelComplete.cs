using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour {

    #region PrivateVariables
    private GameObject _wonTextObj;                 //ref
    #endregion

    #region Unity
    void Start()
    {
        _wonTextObj = GameObject.FindGameObjectWithTag("WonText") as GameObject;    //set ref
        _wonTextObj.GetComponent<Text>().text = "You have Won";                     //change text
        _wonTextObj.SetActive(false);                                               //turn this off
    }

   void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _wonTextObj.SetActive(true);                                            //turn text on
        }
    }
    #endregion
}
