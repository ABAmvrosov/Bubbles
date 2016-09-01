using UnityEngine;
using System.Collections;

public class MoveController : MonoBehaviour {
    [SerializeField]
    private float _speed = 1f;
    [SerializeField]
    private float _leftStrafeMax = -2f;
    [SerializeField]
    private float _rightStrafeMax = 2f;
    [SerializeField]
    private float _strafeTimer = 1.5f;
    private float _sideStrafe;
    private WaitForSeconds _wait;

    private void Awake()
    {
        _wait = new WaitForSeconds(_strafeTimer);
        _sideStrafe = Random.Range(_leftStrafeMax, _rightStrafeMax);
        StartCoroutine(Strafe());
    }

    private void Update()
    {
        Vector3 velocity = new Vector3(_sideStrafe, 1, 0);
        transform.Translate(velocity * _speed * Time.deltaTime);
    }

    private IEnumerator Strafe()
    {
        while (true) {
            Debug.Log("Change strafe");
            _sideStrafe = Random.Range(_leftStrafeMax, _rightStrafeMax);
            yield return _wait;
        }
    }
}
