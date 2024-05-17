using System;
using System.Collections;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public event Action<Cube> LifeTimeOut;
    public event Action<Cube> ContactWithPlatform;

    private bool _isContactWithPlatform = false;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<Platform>())
        {
            if (_isContactWithPlatform == false)
            {
                StartCoroutine(LifeTimeCoroutine());
                ContactWithPlatform?.Invoke(this);
                _isContactWithPlatform = true;
            }
        }
    }

    private IEnumerator LifeTimeCoroutine()
    {
        int _minLifeTime = 2;
        int _maxLifeTime = 5;
        int _delay = 1;
        var wait = new WaitForSeconds(_delay);
        int lifeTime = UnityEngine.Random.Range(_minLifeTime, _maxLifeTime);

        while (lifeTime > 0)
        {
            lifeTime--;
            yield return wait;
        }

        LifeTimeOut?.Invoke(this);
    }
}