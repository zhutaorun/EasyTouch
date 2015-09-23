using UnityEngine;
using System.Collections;

public class PlayerMoveControl : MonoBehaviour {

    private Transform _mTransform;
    public JoystackControl _mJotstackControl;

    public float moveSpeed = 50;
    public delegate void MoveDelegate();
    public static MoveDelegate moveEnd;
    public static MoveDelegate moveStart;
    public static PlayerMoveControl Instance;
	// Use this for initialization
	void Awake () {

        Instance = this;
        _mTransform = transform;

        moveEnd = OnMoveEnd;
        moveStart = OnMoveStart;
	}
	
	// Update is called once per frame
	void Start () {
	
	}
    void OnMoveEnd()
    {
        _turnBase = false;
    }

    void OnMoveStart()
    { 
        _turnBase= true;
    }

    private float angle;
    private bool _turnBase = false;
    void Update()
    { 
        if(_turnBase)
        {
            Vector3 vecMove = _mJotstackControl.MovePosiNorm * Time.deltaTime * moveSpeed / 10;
            _mTransform.localPosition += vecMove;
            angle = Mathf.Atan2(_mJotstackControl.MovePosiNorm.x,_mJotstackControl.MovePosiNorm.z)*Mathf.Rad2Deg-10;
            _mTransform.localRotation = Quaternion.Euler(Vector3.up * angle); 
        }
    }
}
