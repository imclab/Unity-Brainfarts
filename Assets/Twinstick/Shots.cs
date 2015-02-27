using UnityEngine;

public class Shots : MonoBehaviour
{

    public float MaxLifetime;
    private float _lifetime;

    private Vector2 _movementDirection;
    public float MovementSpeedModifier;

	// Use this for initialization
	void Start ()
	{
        if (MaxLifetime == 0)
	    {
	        MaxLifetime = 2;
	    }
	    if (MovementSpeedModifier == 0)
	    {
	        MovementSpeedModifier = 1;
	    }

	    _lifetime = 0;
        _movementDirection = Vector2.right;
	}
	
	// Update is called once per frame
	void Update () {
        _lifetime += Time.deltaTime;

        if (_lifetime > MaxLifetime)
        {
            Destroy(gameObject);
        }

        transform.Translate(_movementDirection * Time.deltaTime * MovementSpeedModifier);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Target")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
