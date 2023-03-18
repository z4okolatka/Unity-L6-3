using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Clickable : MonoBehaviour
{

    [SerializeField] private AnimationCurve _scaleCurve;
    [SerializeField] private float _scaleTime = 0.25f;
    [SerializeField] private HitEffect _hitEffectPrefab;
    [SerializeField] private Resources _resources;

    private int _coinsPerClick = 1;
    private Collider _collider;
    private MeshRenderer _renderer;

    private void Start()
    {
        _collider = GetComponent<Collider>();
        _renderer = GetComponentInChildren<MeshRenderer>();
    }

    public void AddCoinsPerClick(int value)
    {
        _coinsPerClick += value;
    }

    public void Hit()
    {
        Vector3 position = transform.position;
        position.y += 1f;
        HitEffect hitEffect = Instantiate(_hitEffectPrefab, position, Quaternion.identity);
        hitEffect.Init(_coinsPerClick, _resources, _collider, _renderer.material);
        StartCoroutine(HitAnimation());
    }

    private IEnumerator HitAnimation()
    {
        for (float t = 0; t < 1f; t += Time.deltaTime / _scaleTime)
        {
            float scale = _scaleCurve.Evaluate(t);
            transform.localScale = Vector3.one * scale;
            yield return null;
        }
        transform.localScale = Vector3.one;
    }

}
