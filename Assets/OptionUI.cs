using UnityEngine;
using UnityEngine.UI;

public class OptionUI : MonoBehaviour
{
    [SerializeField] Slider _sliderSound;
    [SerializeField] Toggle _toggleSound;
    [SerializeField] Button _buttonEnd;

    public void Init()
    {
        _sliderSound.gameObject.SetActive(true);
        _toggleSound.gameObject.SetActive(true);
        _buttonEnd.gameObject.SetActive(true);
    }

    public void SoundSliderOnValue(float value)
    {
        _sliderSound.value = value;
        GameManager.Instance.SoundVolumControll(value);
    }
    public void SoundToggleOnValue(bool _bool)
    {
        if (_bool) _sliderSound.value = 0f;
        else return;
    }

    public void OnOptionUI()
    {
        gameObject.SetActive(true);
    }
    public void OffOptionUI()
    {
        gameObject.SetActive(false);
    }

}
