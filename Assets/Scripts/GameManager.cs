using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    AudioSource _audio;

    bool _isGameScene;
    public bool isGameScene
    {
        get { return _isGameScene; }
        set { _isGameScene = value; }
    }



    #region 싱글턴
    private static GameManager instance = null;
    private void Awake()
    {
        if (null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        _isGameScene = false;
    }
    public static GameManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
    #endregion

    private void Update()
    {
        if (_isGameScene)
        {
            DayTimer();
            DisPlayerLife();
        }
    }
    #region 월드 타이머

    int _dayCount = 1;
    float _time = 300;
    float _timer = 0;
    public float timer
    {
        get { return _timer; }
        set { _timer = value; }
    }

    bool _isMorning = true;
    public bool isMorning
    {
        get { return _isMorning; }
        set { _isMorning = value; }
    }


    public void DayTimer()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);
        if (UIManager.Instance != null) UIManager.Instance.TimeBarUpdate((int)_timer / _time, _dayCount);
        if ((int)_timer / _time > 1)
        {
            timer = 0;
            _dayCount++;
        }
        if (timer == 0) isMorning = true;
        if (timer == 150) isMorning = false;
    }
    #endregion

    #region 배고픔 목마름 증가
    // 6초마다 배고픔 목마름 게이지가 1씩 떨어짐
    float _playerLifeTimer = 0;
    void DisPlayerLife()
    {
        _playerLifeTimer += Time.deltaTime;
        if(_playerLifeTimer > 6)
        {
            PlayerControl.Instance.hungryValue -= 1;
            PlayerControl.Instance.thirstValue -= 1;
            _playerLifeTimer = 0;
        }
    }


    #endregion

    public void SoundVolumControll(float value)
    {
        _audio.volume = value;
    }
}
