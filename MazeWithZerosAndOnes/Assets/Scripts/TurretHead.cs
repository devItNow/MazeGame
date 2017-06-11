using UnityEngine;
using System.Collections;

public class TurretHead : MonoBehaviour {
    
    #region PublicVariables
    public GameObject turretHead;           //this is the object that will turn to the player
    public GameObject bullet;               //bullet prefab
    public GameObject m1;                   //turret gun one
    public GameObject m2;                   //turret gun two
    public float turnSpeed = 3.5f;	        //controls the rotation  
    public float bulletSpawnSpeed = .05f;   //bullet span speed
    #endregion

    #region PrivateVariables
    private GameObject _target;             //rotate to this
    private bool active = false;            //turret on/off ?
    private bool _rightShot = true;         //switch between left and right turret
    private float _maxAliveTime = 3.5f;     //turn off after this time
    private AudioSource _aS;                //ref
    #endregion

    #region Unity
    void Awake()
    {
        _aS = gameObject.GetComponent<AudioSource>();               //get ref
    }

    void Update()
    {
        if(active)  
        {
            Quaternion rotation = Quaternion.LookRotation(_target.transform.position - turretHead.transform.position);                  //calculate rotation
            turretHead.transform.rotation = Quaternion.Slerp(turretHead.transform.rotation, rotation, Time.deltaTime * turnSpeed);      //apply rotation with speed
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _target = other.gameObject;             //set the target
            active = true;                          //start the rotation
            StartCoroutine("SpawnB");               //start bullet spawn
            _aS.Play();                             //start the sound
            StartCoroutine("AliveFor");             //turn off after a certain amount of time  
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _target = null;                         //set the target to none
            active = false;                         //stop rotation
            _aS.Stop();                             //stop music
            StopAllCoroutines();                    //stop all 
        }
    }
    #endregion

    #region Enumerator
    IEnumerator SpawnB()
    {
        yield return new WaitForSeconds(bulletSpawnSpeed);                                                  //wait
        _rightShot = !_rightShot;                                                                           //change spawn mount
        if(_rightShot)
        {
            GameObject a = Instantiate(bullet, m1.transform.position, Quaternion.identity) as GameObject;   //spawn
            a.transform.SetParent(m1.transform);                                                            //parent it to mount 1
            a.transform.rotation = m1.transform.rotation;                                                   //match parent rotation
            a.transform.localPosition = Vector3.zero;                                                       //match parent position
            a.transform.SetParent(null);                                                                    //unparent
        }
        else
        {
            GameObject a = Instantiate(bullet, m2.transform.position, Quaternion.identity) as GameObject;   //same as above, but to mount 2
            a.transform.SetParent(m2.transform);
            a.transform.rotation = m2.transform.rotation;
            a.transform.localPosition = Vector3.zero;
            a.transform.SetParent(null);
        }

        StartCoroutine("SpawnB");                                                                           //rerun
    }

    IEnumerator AliveFor()  //turn this turret off after certain time
    {
        yield return new WaitForSeconds(_maxAliveTime);
        _target = null;
        active = false;
        StopAllCoroutines();
    }
    #endregion
}
