using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGAnimation : MonoBehaviour
{
    /*public Image []Images = new Image[3];
    public float ChangingBG;
    public float Delay;
    public float Scale;

    private float _duration;
    private int _indexBG;
    private bool _isAppear;
    private RectTransform _rectT;
    private int _nextBG;
    private bool _isDisappear;

    private void Awake()
    {
        Delay = 5f;
        ChangingBG = 2f;
        _duration = 0f;
        _indexBG = 0;
        _isAppear = false;
        _isDisappear = false;
        Scale = 0.001f;
        _rectT = Images[_indexBG].rectTransform;
        _nextBG = _indexBG + 1;
    }

    private void Start()
    {
        Images[1].enabled = Images[2].enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        _duration += Time.deltaTime;

        _rectT.localScale = new Vector3(_rectT.localScale.x + Scale, _rectT.localScale.y + Scale, _rectT.localScale.z + Scale);

        if(_duration > ChangingBG + Delay)
        {
            Images[_indexBG].enabled = false;
            _rectT.localScale = new Vector3(1, 1, 1);
            _indexBG = (_indexBG+1) % 3;
            _nextBG = (_nextBG + 1) % 3;
            _rectT = Images[_indexBG].rectTransform;

            _duration = 0f;
            _isAppear = false;
        }
        else if (_duration > Delay)
        {
            if(!_isAppear)
            {
                //Images[_nextBG].enabled = true;
                _isAppear = true;
            }

            ChangeAlpha(ref Images[_indexBG].color, false);
            ChangeAlpha(Images[_nextBG].color, true);
        }
        
    }

    private void SetAlpha(ref Color color, float alpha)
    {
        alpha = (alpha < 0 ? 0 : alpha);
        alpha = (alpha > 1 ? 1 : alpha);

        color = new Vector4(color.r, color.g, color.b, alpha);
    }

    private void ChangeAlpha(ref Color color, bool sign)
    {
        float newAlpha;

        if (sign)
        {
            newAlpha = color.a + Time.deltaTime / ChangingBG;
            SetAlpha(ref color, newAlpha);
        }
        else
        {
            newAlpha = color.a - Time.deltaTime / ChangingBG;
            SetAlpha(ref color, newAlpha);
        }

           
    }*/
}
