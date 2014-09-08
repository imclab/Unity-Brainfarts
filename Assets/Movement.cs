using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	private Vector2 _movementDirection;
    private Vector2 _shotDirection;

    public float MovementSpeedModifier;

    private GameObject _body;
    private GameObject _turrent;

	// Use this for initialization
	void Start () {
		_movementDirection = Vector2.zero;
	    _shotDirection = Vector2.zero;

	    _body = transform.FindChild("Body").gameObject;
	    _turrent = transform.FindChild("Turrent").gameObject;
	}
	
	// Update is called once per frame
	void Update () {

		_movementDirection = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
        _shotDirection = new Vector2(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2"));

		this.transform.Translate (_movementDirection * Time.deltaTime * MovementSpeedModifier);

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

            _turrent.transform.rotation = Quaternion.Euler(0, 0, Vector2.Angle(new Vector2(1, 0), _shotDirection) * orientationModifier);
        }
	}
}
