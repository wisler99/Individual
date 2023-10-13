using UnityEditor.Rendering;
using UnityEngine;

public class LightControll : MonoBehaviour
{
    float _maxRot;
    float _lightRot;
    private void Start()
    {
        RenderSettings.fog = true;
        _maxRot = 240f;
    }
    private void Update()
    {
        LightRot();
        FogContorll();
    }
    void LightRot()
    {
        if (GameManager.Instance.isMorning)
        {
            transform.Rotate(Vector3.right, Time.deltaTime * (180f/70f));
        }
        else if(GameManager.Instance.isMorning == false)
        {
            transform.Rotate(Vector3.right, Time.deltaTime * (180f / 30f));
        }
    }
    void FogContorll()
    {
        if(GameManager.Instance.isMorning == false)
        {
            float fogValue = 0f;
            if(fogValue <= 0f) fogValue = GameManager.Instance.timer * (1f / 50f);
            else if (fogValue >= 1f) fogValue = 1 - GameManager.Instance.timer * (1f / 50f);
            RenderSettings.fogDensity = fogValue;
        }
    }
}
