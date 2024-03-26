using System.Collections;
using TMPro;
using UnityEngine;

public class NumberView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
        
    private float _delay = 0.5f;
    private Coroutine _coroutine;
    private int _number = 0;    

    private void Start()
    {
        _text.text = "0";                 
    }

    private void Update()
    {              
        WaitForSeconds wait = new WaitForSeconds(_delay);

        if (Input.GetMouseButtonDown(0))
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);                
                _coroutine = null;
            }                
            else if (_coroutine == null)
            {
                _coroutine = StartCoroutine(Countdown(wait));                              
            }                      
        }
    }

    private IEnumerator Countdown(WaitForSeconds wait)
    {    
        while (true)
        {
            yield return wait;            
            _number++;
            DisplayCountdown(_number);           
        }
    }    

    private void DisplayCountdown(int number)
    {
        _text.text = number.ToString("");
    }
}
