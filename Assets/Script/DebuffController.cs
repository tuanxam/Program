using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DebuffController : MonoBehaviour
{

    protected Coroutine coroutine;
    private GameObject _target;
    private float _duration;
    private float _timeDelay;
    [HideInInspector] public float damage;
    [HideInInspector] public bool isDebuff;
    protected IEnumerator SpawCoroutine()
    {
        while(_duration > 0)
        {
            if (_target != null)
            {
                ApplyDebuff(_target);
                yield return new WaitForSeconds(_timeDelay);
            }
            _duration--;
        }
        
        RemoveDebuff(_target);
    }

    public void ApplyDebuffToTarget(GameObject target)
    {
        this._target = target;
        _duration = Duration();
        _timeDelay = Delay();
        coroutine = StartCoroutine(SpawCoroutine());
    }

    protected abstract float Duration();
    protected abstract float Delay();
    protected abstract void ApplyDebuff(GameObject target);
    protected abstract void RemoveDebuff(GameObject target);

}
