using System;
using UnityEngine;
using UnityEngine.UI;

public class LoadingUI : MonoBehaviour
{
    [SerializeField] Slider _sliderLoading;
    [SerializeField] Button[] _ButtonLoading;
    [SerializeField] OptionUI _optionUI;
    bool _isLoading;

    string _nextScene;

    private void Start()
    {
        gameObject.SetActive(true);
        _sliderLoading.value = 0;
        _sliderLoading.gameObject.SetActive(true);
        _optionUI.gameObject.SetActive(false);
        _isLoading = false;
        Data.Instance.LoadingEnd += new EventHandler(LoadingEnd);
        for (int i = 0; i < _ButtonLoading.Length; i++)
        {
            _ButtonLoading[i].gameObject.SetActive(false);
        }
        _optionUI.Init();
    }

    void LoadingEnd(object sender, EventArgs s)
    {
        DisableLoadingSlider();
        _isLoading = true;
    }
    void DisableLoadingSlider()
    {
        _sliderLoading.gameObject.SetActive(false);
        for (int i = 0; i < _ButtonLoading.Length; i++)
        {
            _ButtonLoading[i].gameObject.SetActive(true);
        }
    }

    // 버튼 기능
    // 시작 , 옵션 , 나가기
    public void OnStartBtn()
    {
        Data.Instance.SceneChange();
    }
    public void OnOptionBtn()
    {
        _optionUI.OnOptionUI();
    }
    public void OnExitBtn()
    {
        Application.Quit();
    }
}
