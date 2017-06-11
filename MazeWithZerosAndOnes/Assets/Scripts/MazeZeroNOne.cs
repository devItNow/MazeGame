using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MazeZeroNOne : MonoBehaviour
{

    // 0  = NO Wall
    // 1 - Brick Wall
    // 2 = Player Starting Point
    // 3 = End Of Maze
    // 4 = Turret
    // 5 = Turret +

    #region Maze_0_Variables
    private int[] _z_20 = new int[40];
    private int[] _z_19 = new int[40];
    private int[] _z_18 = new int[40];
    private int[] _z_17 = new int[40];
    private int[] _z_16 = new int[40];
    private int[] _z_15 = new int[40];
    private int[] _z_14 = new int[40];
    private int[] _z_13 = new int[40];
    private int[] _z_12 = new int[40];
    private int[] _z_11 = new int[40];
    private int[] _z_10 = new int[40];
    private int[] _z_9 = new int[40];
    private int[] _z_8 = new int[40];
    private int[] _z_7 = new int[40];
    private int[] _z_6 = new int[40];
    private int[] _z_5 = new int[40];
    private int[] _z_4 = new int[40];
    private int[] _z_3 = new int[40];
    private int[] _z_2 = new int[40];
    private int[] _z_1 = new int[40];
    private int[] _z_0 = new int[40];
    #endregion

    #region PublicVariables
    public GameObject wallPrefab;               //cube prefab
    public GameObject completePrefab;           //complete obj
    public GameObject playerObj;                //player
    public GameObject turretPrefab;             //turret enemy 1
    public GameObject turret2Prefab;            //turret enemy 2
    #endregion

    #region PrivateVariables
    private float _wallSize = 2;                //wall height and length
    private List<int> _map_0 = new List<int>(); //arreys get added into this
    private int _xLength = 40;                  //amount of cubes on x
    private int _zLength = 21;                  //amount of cubes on z
    private CurMap _curMap = CurMap.Map_1;      //Default
    private MapMaker _mapMaker;                 //ref
    private Vector3 _playerStartPosition;       //start position
    #endregion

    #region Unity
    void Start ()
    {
        _mapMaker = gameObject.GetComponent<MapMaker>();    //set ref
        GetMap();                                           //get map from MapMaker.cs
        AddMap_0();                                         //choose map and add
        InstantiateMap();                                   //spawn
    }
    #endregion

    #region CalculateMap
    private void GetMap()
    {
        _curMap = _mapMaker.curMap;     //get map to spawn

        if (_curMap == CurMap.Map_1)
        {
            _z_0 = _mapMaker.z_0();     //add to array
            _z_1 = _mapMaker.z_1();
            _z_2 = _mapMaker.z_2();
            _z_3 = _mapMaker.z_3();
            _z_4 = _mapMaker.z_4();
            _z_5 = _mapMaker.z_5();
            _z_6 = _mapMaker.z_6();
            _z_7 = _mapMaker.z_7();
            _z_8 = _mapMaker.z_8();
            _z_9 = _mapMaker.z_9();
            _z_10 = _mapMaker.z_10();
            _z_11 = _mapMaker.z_11();
            _z_12 = _mapMaker.z_12();
            _z_13 = _mapMaker.z_13();
            _z_14 = _mapMaker.z_14();
            _z_15 = _mapMaker.z_15();
            _z_16 = _mapMaker.z_16();
            _z_17 = _mapMaker.z_17();
            _z_18 = _mapMaker.z_18();
            _z_19 = _mapMaker.z_19();
            _z_20 = _mapMaker.z_20();
        }
    }

    private void AddMap_0()
    {
        for(int i = 0; i < _xLength; i++)
        {
            if (_curMap == CurMap.Map_1)
            {
                _map_0.Add(_z_0[i]);                //add map to list in this order because they will be spawn in this order
                _map_0.Add(_z_1[i]);
                _map_0.Add(_z_2[i]);
                _map_0.Add(_z_3[i]);
                _map_0.Add(_z_4[i]);
                _map_0.Add(_z_5[i]);
                _map_0.Add(_z_6[i]);
                _map_0.Add(_z_7[i]);
                _map_0.Add(_z_8[i]);
                _map_0.Add(_z_9[i]);
                _map_0.Add(_z_10[i]);
                _map_0.Add(_z_11[i]);
                _map_0.Add(_z_12[i]);
                _map_0.Add(_z_13[i]);
                _map_0.Add(_z_14[i]);
                _map_0.Add(_z_15[i]);
                _map_0.Add(_z_16[i]);
                _map_0.Add(_z_17[i]);
                _map_0.Add(_z_18[i]);
                _map_0.Add(_z_19[i]);
                _map_0.Add(_z_20[i]);
            }
        }
    }

    private void InstantiateMap()
    {
        int count = 0;                          //use to get the int in the list

        for (int x = 0; x < _xLength; x++)
        {
            for (int z = 0; z < _zLength; z++)
            {
                float _z = z * _wallSize;       //set z position
                float _x = x * _wallSize;       //set x position

                if (_map_0[count] == 0)
                {
                    //blank
                }
                else if (_map_0[count] == 1)
                {
                    Instantiate(wallPrefab, new Vector3(_x, _wallSize / 2, _z), Quaternion.identity);
                }
                else if (_map_0[count] == 2)
                {
                    playerObj.transform.position = new Vector3(_x, _wallSize / 2, _z);
                    _playerStartPosition = playerObj.transform.position;
                }
                else if (_map_0[count] == 3)
                {
                    Instantiate(completePrefab, new Vector3(_x, _wallSize / 2, _z), Quaternion.identity);
                }
                else if (_map_0[count] == 4)
                {
                    Instantiate(turretPrefab, new Vector3(_x, 0, _z), Quaternion.identity);
                }
                else if (_map_0[count] == 5)
                {
                    Instantiate(turret2Prefab, new Vector3(_x, 0, _z), Quaternion.identity);
                }
                else
                {
                    Debug.LogError(x.ToString() + " " + z.ToString() + " unknown number");
                }

                count++;        //net on list
            }
        }

    }
    #endregion

    #region PassIn
    public Vector3 GetStartPosition()
    {
        return _playerStartPosition;
    }
    #endregion
}
public enum CurMap
{
    None,
    Map_1
}