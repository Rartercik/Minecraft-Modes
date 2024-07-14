using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Game.MenuComponetns
{
    public class SwipeHandler : MonoBehaviour
    {
        [SerializeField] private Scrollbar _scrollbar;
        [SerializeField] private Transform[] _elements;
        [SerializeField] private Image[] _elementsImages;
        [SerializeField] private Color _unselectedColor;
        [SerializeField] private int _initialIndex;
        [SerializeField] private float _reducedScale = 0.8f;
        [SerializeField] private float _changeSpeed = 0.1f;

        private float[] _positions;
        private float _scrollPosition;
        private float _distance;

        private void Start()
        {
            _positions = new float[_elements.Length];
            _distance = 1f / (_positions.Length - 1f);

            for (int i = 0; i < _positions.Length; i++)
            {
                _positions[i] = _distance * i;
            }
            _scrollPosition = _positions[_initialIndex];
            StartCoroutine(SetScrollBarValue(_scrollbar, _scrollPosition));
            SetElementsScales(1f);
            SetColors(1f);
        }

        private void Update()
        {
            HandleScrollBarPosition();
            SetElementsScales(_changeSpeed);
            SetColors(_changeSpeed);
        }

        private void HandleScrollBarPosition()
        {
            if (Input.GetMouseButton(0))
            {
                _scrollPosition = _scrollbar.value;
            }
            else
            {
                for (int i = 0; i < _positions.Length; i++)
                {
                    if (_scrollPosition < _positions[i] + (_distance / 2) && _scrollPosition > _positions[i] - (_distance / 2))
                    {
                        _scrollbar.value = Mathf.Lerp(_scrollbar.value, _positions[i], _changeSpeed);
                    }
                }
            }
        }

        private void SetElementsScales(float scaleChangeSpeed)
        {
            for (int i = 0; i < _positions.Length; i++)
            {
                if (_scrollPosition < _positions[i] + (_distance / 2) && _scrollPosition > _positions[i] - (_distance / 2))
                {
                    _elements[i].localScale = Vector2.Lerp(_elements[i].localScale, new Vector2(1f, 1f), scaleChangeSpeed);
                    for (int j = 0; j < _positions.Length; j++)
                    {
                        if (j != i)
                        {
                            _elements[j].localScale = Vector2.Lerp(_elements[j].localScale, new Vector2(_reducedScale, _reducedScale), scaleChangeSpeed);
                        }
                    }
                }
            }
        }

        private IEnumerator SetScrollBarValue(Scrollbar scrollbar, float value)
        {
            yield return null;

            scrollbar.value = value;
        }

        private void SetColors(float colorChangeSpeed)
        {
            for (int i = 0; i < _positions.Length; i++)
            {
                if (_scrollPosition < _positions[i] + (_distance / 2) && _scrollPosition > _positions[i] - (_distance / 2))
                {
                    _elementsImages[i].color = Color.Lerp(_elementsImages[i].color, Color.white, colorChangeSpeed);
                    for (int j = 0; j < _positions.Length; j++)
                    {
                        if (j != i)
                        {
                            _elementsImages[j].color = Color.Lerp(_elementsImages[j].color, _unselectedColor, colorChangeSpeed);
                        }
                    }
                }
            }
        }
    }
}