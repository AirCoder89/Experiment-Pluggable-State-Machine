using Core;
using Extensions;
using PathologicalGames;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public LayerMask ignoreLayers;
    private Rigidbody _rb;
    public Rigidbody rigidBody
    {
        get
        {
            if (_rb == null) _rb = GetComponent<Rigidbody>();
            return _rb;
        }
    }

    private bool _isInitialized;
    private SpawnPool _pool;
    private GameObject _owner;
    private float _damage;
    
    public void Initialize(SpawnPool pool, GameObject owner, float damage)
    {
        _damage = damage;
        _owner = owner;
        if(_isInitialized) return;
        _isInitialized = true;
        _pool = pool;
    }
    
    public void Remove() => _pool.Despawn(this.transform, _pool.transform);

    private void OnCollisionEnter(Collision other)
    {
        if(ignoreLayers.CompareLayer(other.gameObject.layer)) return;
        if(_owner == other.gameObject) return;
        var destroyable = other.gameObject.GetComponent<IDestroyable>();
        if (destroyable == null)
        {
            Remove();
            return;
        }
        Remove();
        destroyable.ApplyDamage(this._damage);
    }

}