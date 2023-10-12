using UnityEngine;

public class LightControll : MonoBehaviour
{
    private void Update()
    {
        gameObject.transform.rotation= Quaternion.Euler(0f, 0f, 0f);
        LightRot();
    }
    void LightRot()
    {
        float lightRot = GameManager.Instance.timer * (360 / 300);
        gameObject.transform.rotation = Quaternion.Euler(lightRot, 0f, 0f);
        //RenderSettings.fog.
    }
}
