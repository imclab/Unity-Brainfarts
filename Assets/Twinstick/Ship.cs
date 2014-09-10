using UnityEngine;

public class Ship : MonoBehaviour {

	private Vector2 _movementDirection;
    private Vector2 _shotDirection;

    public float MovementSpeedModifier;

    private GameObject _body;
    private GameObject _turrent;
    public GameObject ShotPrefab;
    private GameObject _shots;

    public float ShotTimer;
    private float _currentShotTimer;

	// Use this for initialization
	void Start () {
		_movementDirection = Vector2.right;
	    _shotDirection = Vector2.right;

	    _body = transform.FindChild("Body").gameObject;
	    _turrent = transform.FindChild("Turrent").gameObject;
	    _shots = GameObject.Find("Shots");
	}
	
	// Update is called once per frame
	void Update () {

		_movementDirection = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
        _shotDirection = new Vector2(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2"));

		this.transform.Translate (_movementDirection * Time.deltaTime * MovementSpeedModifier);

	    _currentShotTimer -= Time.deltaTime;

        if (_movementDirection != Vector2.zero)
        {
            int orientationModifier = 1;

            if (_movementDirection.y >= 0)
            {
                orientationModifier = 1;
            }
            else if (_movementDirection.y < 0)
            {
                orientationModifier = -1;
            }

            _body.transform.rotation = Quaternion.Euler(0, 0, Vector2.Angle(new Vector2(1, 0), _movementDirection) * orientationModifier);
        }
        
        if (_shotDirection != Vector2.zero)
        {
            int orientationModifier = 1;

            if (_shotDirection.y >= 0)
            {
                orientationModifier = 1;
            }
            else if (_shotDirection.y < 0)
            {
                orientationModifier = -1;
            }

            _turrent.transform.rotation = Quaternion.Euler(0, 0,
               Vector2.Angle(new Vector2(1, 0), _shotDirection) * orientationModifier);

            if (_currentShotTimer < 0)
            {
                GameObject _shot =
                    Instantiate(ShotPrefab,
                        this.transform.position + new Vector3(_shotDirection.x, _shotDirection.y)*0.4f,
                        _turrent.transform.rotation) as GameObject;
                _shot.transform.parent = _shots.transform;

                _currentShotTimer = ShotTimer;
            }
        }
	}
}
