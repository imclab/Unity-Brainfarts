using UnityEngine;

public class LightTrigger : MonoBehaviour
{

    private GameObject _light;

    void Start()
    {
        _light = this.transform.FindChild("Point light").gameObject;
    }

    public void Trigger()
    {
        _light.GetComponent<Light>().intensity = 1;
        _light.GetComponent<Light>().color = Color.white;

        GetComponent<Collider>().enabled = false;
    }


}
