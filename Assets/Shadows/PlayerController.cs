using System;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerController : MonoBehaviour {

    private Vector2 _movementDirection;
    public float MovementSpeedModifier;

    private Vector2 _positionLastFrame;

    private GameObject _playerLight;

    private Transform _goal;

	// Use this for initialization
	void Start ()
	{
	    _playerLight = this.transform.FindChild("PlayerLight").gameObject;
	    _goal = GameObject.FindGameObjectWithTag("Finish").transform;

        _movementDirection = Vector2.right;

	    if (MovementSpeedModifier == 0)
	        MovementSpeedModifier = 1;

	    _positionLastFrame = Vector2.zero;
	}
	
	// Update is called once per frame
	void Update () {
        _movementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        _positionLastFrame = this.transform.position;
	    this.transform.Translate(_movementDirection * Time.deltaTime * MovementSpeedModifier);

        float distance = (this.transform.position - _goal.position).magnitude;
	    float intensityModifier = distance/90;
	    float shakeModifier = Mathf.Clamp(distance/400, 0, 0.09f);
        //Debug.Log("Shake: " + shakeModifier + ", Intensity: " + intensityModifier);


	    if (Time.frameCount%5 == 1)
        {
	        _playerLight.GetComponent<Light>().intensity = Random.Range(0.5f - intensityModifier, 0.5f);
            _playerLight.transform.localPosition = new Vector3(Random.Range(-shakeModifier, shakeModifier), Random.Range( -shakeModifier, shakeModifier),0);
	    }

	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Finish")
        {
            Debug.Log("You Win!");
            _playerLight.GetComponent<Light>().color = new Color(1,0,0);
        }

        this.transform.position = _positionLastFrame;
    }
}
