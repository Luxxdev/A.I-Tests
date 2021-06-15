using UnityEngine;
using UnityEngine.AI;

public abstract class Personagem : MonoBehaviour
{
    protected State _currentState = null;
    public NavMeshAgent agent = null;
    public Transform myTransform = null;

    public ItemCatalog itemCatalog = null;

    public bool isEnemy = false;
    public bool haveLoot = false;

    public EState currentState = EState.None;
    public EState lastState = EState.None;

    public float staminaRecoverySpeed = 0.0f;
    public float staminaSpendSpeed = 0.0f;
    public float stamina = 1.0f;
    public float velocidade = 1.0f;
    public int vida = 1;
    public int damage = 1;
    public bool isAlive
    {
        get
        {
            return vida > 0;
        }
    }
    private float _maxStamina = 0.0f;

    public float MaxStamina
    {
        get
        {
            return _maxStamina;
        }
    }

    public Transform collectPoint = null;

    protected Item _targetItem = null;
    public Item TItem
    {
        get
        {
            return _targetItem;
        }
    }

    protected Item _item = null;

    public Item Item
    {
        get
        {
            return _item;
        }
    }

    public PersonagemUI _ui = null;

    protected virtual void Start()
    {
        _maxStamina = stamina;
        _ui.UpdateLifeText(vida);
        _ui.UpdateSpeedText(velocidade);
    }

    public abstract void ChangeState(EState state);
    public abstract void PlayTrigger(EStateTrigger trigger);

    public void TargetItem (Item newItem)
    {
        _targetItem = newItem;
    }

    public void CollectItem(Item newItem)
    {
        _item = newItem;
        _item.personagem = this;

        agent.speed -= _item.SpeedChanger;
        agent.speed = Mathf.Max(agent.speed, 0.5f);
        _ui.UpdateSpeedText(agent.speed);

    }

    public void LeaveItem(bool justLeave)
    {
        _item.Leave(justLeave);

        agent.speed += _item.SpeedChanger;
        agent.speed = Mathf.Min(agent.speed, velocidade);
        _ui.UpdateSpeedText(agent.speed);


        _item = null;
    }

    public bool ReduceStamina()
    {
        stamina -= staminaSpendSpeed * Time.deltaTime;
        stamina = Mathf.Max(stamina, 0.0f);

        return (stamina <= 0.0f);
    }

    public void TakeDamage(int damage)
    {
        vida -= damage;
        vida = Mathf.Max(vida, 0);

        _ui.UpdateLifeText(vida);

        PlayTrigger(EStateTrigger.TakeDamage);
    }
}
