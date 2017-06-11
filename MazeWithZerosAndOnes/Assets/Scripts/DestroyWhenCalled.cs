using UnityEngine;
using System.Collections;

public class DestroyWhenCalled : MonoBehaviour
{
    #region PrivateVariables
    private float _movementSpeed = 15;              //movement speed
    private int _destroyAfterSeconds = 5;           //alive time
    #endregion

    #region Unity
    void Awake()
    {
        WaitForDeath();                             //stat the timer
    }

    void Update()
    {
        transform.localPosition += transform.forward * Time.deltaTime * _movementSpeed;     //move forward
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "EnemyB" && other.gameObject.tag != "EnemyNutral")
        {
            DestroyMe();                                            //destroy this
        }
    }
    #endregion

    #region PasIn
    public void DestroyMe()
    {
        Destroy(gameObject);                        //destroy this
    }
    #endregion

    #region Enumerator
    IEnumerator WaitForDeath()
    {
        yield return new WaitForSeconds(_destroyAfterSeconds);      //wait
        DestroyMe();                                                //destroy this
    }
    #endregion
}
