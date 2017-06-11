using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHitPoints : MonoBehaviour
{
    #region PublicVariables
    public Text text;                               //health ref
    public GameObject parent;                       //the player obj [this script must be on the player or player children]
    public MazeZeroNOne mazeZNO;                    //ref
    #endregion

    #region PrivateVariables
    private int _maxHealth = 100;                   //health
    private int _curHealth = 100;                   //cur health
    private int _damageTaken = 1;                   //damage take per hit
    private Vector3 _startPosition;                 //player spawn position
    #endregion

    #region Unity
    void Start()
    {
        _curHealth = _maxHealth;                    //set health
        UpdateHealthDisplay();                      //update UI
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyB")                               //hit by enemy?
        {
            other.gameObject.GetComponent<DestroyWhenCalled>().DestroyMe(); //tell the bullet to die
            _curHealth -= _damageTaken;                                     //reduce damage
            if(_curHealth <=0)
            {
                parent.transform.position = mazeZNO.GetStartPosition();     //go back to start
                _curHealth = _maxHealth;                                    //reset health
                UpdateHealthDisplay();                                      //update UI
            }
            else
            {
                UpdateHealthDisplay();                                      //update UI
            }
        }
    }
    #endregion

    #region UI
    private void UpdateHealthDisplay()
    {
        if(_curHealth < 0)          //fix health
        {
            _curHealth = 0;
        }
        text.text = _curHealth.ToString() + " / " + _maxHealth.ToString();  //update health
    }
    #endregion
}
