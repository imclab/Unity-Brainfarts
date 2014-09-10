using UnityEngine;

public class CameraControl : MonoBehaviour
{
    private Transform _playerPosition;

	// Use this for initialization
	void Start ()
	{
	    _playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    this.transform.position = _playerPosition.position + Vector3.back;
	}
}
