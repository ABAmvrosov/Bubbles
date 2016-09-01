using System.Collections;
using UnityEngine;

public class MainStateMachine : MonoBehaviour {
    
    private IMainState CurrentState
    {
        get { return _currentState; }
        set {
            _currentState = value;
            _currentCoroutine = _currentState.GetCoroutine();
        }
    }
    private IMainState _currentState;
    private IEnumerator _currentCoroutine;

    private void Awake() {
        if (CurrentState == null) {
            CurrentState = new MainMenuLoadState();
        }
        StartCoroutine(_currentCoroutine);
    }
        
    public void ChangeState(IMainState state) {
        StopCoroutine(_currentCoroutine);
        CurrentState = state;
        StartCoroutine(_currentCoroutine);
    }    
}
