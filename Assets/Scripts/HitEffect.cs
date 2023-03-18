using UnityEngine;
using UnityEngine.UIElements;

public class HitEffect : MonoBehaviour
{
    [SerializeField] private HoverEffect _hoverEffectPrefab;
    private Resources _resources;
    private int _containingCoins;

    public void Init(int containingCoins, Resources resources, Collider _modelCollider, Material material)
    {
        _containingCoins = containingCoins;
        _resources = resources;
        Physics.IgnoreCollision(transform.GetComponent<Collider>(), _modelCollider);
        transform.GetComponent<Renderer>().material = material;

        Rigidbody _rigidbody = GetComponent<Rigidbody>();
        float velxz = Random.Range(700f, 1000f);
        float angle = Random.Range(3 * Mathf.PI / 4, 7 * Mathf.PI / 4);
        float x = Mathf.Cos(angle) * velxz;
        float z = Mathf.Sin(angle) * velxz;

        Vector3 velocity = new Vector3(x, 1000f, z);
        _rigidbody.AddForce(velocity);
    }
    public void Hover()
    {
        HoverEffect hoverEffect = Instantiate(_hoverEffectPrefab, transform.position, Quaternion.identity);
        hoverEffect.Init(_containingCoins);
        _resources.CollectCoins(_containingCoins, transform.position);
        Destroy(gameObject);
    }
}