using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private ItemCatalog _itemCatalog = null;

    [SerializeField]
    private Collider _collider = null;

    private bool _entregue = false;

    public bool Entregue
    {
        get
        {
            return _entregue;
        }
    }

    [SerializeField]
    private Transform _transform = null;
    public Transform MyTransform
    {
        get
        {
            return _transform;
        }
    }

    [SerializeField]
    private Transform _deliverPoint = null;
    public Transform DeliverPoint
    {
        get
        {
            return _deliverPoint;
        }
    }
    [SerializeField]
    private Transform _leavePoint = null;
    public Transform LeavePoint
    {
        get
        {
            return _leavePoint;
        }
    }

    [SerializeField, Min(0.1f)]
    private float _peso = 0.0f;
    [SerializeField]
    private float _pesoMultiply = 1.0f;

    public float SpeedChanger
    {
        get
        {
            return _peso * _pesoMultiply;
        }
    }

    public Personagem personagem = null;

    public bool HasParent
    {
        get
        {
            return (_transform.parent != null && personagem != null);
        }
    }

    public void SetNewParent(Transform newParent)
    {
        _collider.enabled = false;
        _transform.SetParent(newParent);
        transform.localPosition = Vector3.zero;
    }

    public void Leave(bool justLeave)
    {
        personagem = null;
        _transform.SetParent(null);
        _collider.enabled = true;


        if (justLeave)
        {
            Vector3 pos = _transform.position;
            pos += Random.insideUnitSphere * 5;
            pos.y = 0.56f;

            transform.position = pos;
            return;
        }

        if (IsSafe())
        {
            _entregue = false;
            _transform.localPosition = _deliverPoint.position;
        }
        else
        {
            _entregue = true;
            _transform.localPosition = _leavePoint.position;
        }

        _itemCatalog.UpdateUI(); 
    }

    public bool IsSafe()
    {
        return Vector3.Distance(_transform.position, _deliverPoint.position) <= 5.0f;
    }

    public bool CanLeave()
    {
        return Vector3.Distance(_transform.position, _leavePoint.position) <= 1.0f;
    }
}
