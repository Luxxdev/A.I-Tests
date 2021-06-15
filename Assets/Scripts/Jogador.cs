using UnityEngine;

public class Jogador : Personagem
{
    public Vector3 direcao = Vector3.zero;
    private Collect _collect = null;
    private Deliver _deliver = null;
    private Search _search = null;
    private MoveTo _moveTo = null;
    private Death _death = null;
    private Rest _rest = null;



    public void Awake()
    {
        _collect = new Collect(this);
        _deliver = new Deliver(this);
        _search = new Search(this);
        _moveTo = new MoveTo(this);
        _death = new Death(this);
        _rest = new Rest(this);
        agent.speed = velocidade;
    }

    protected override void Start()
    {
        ChangeState(EState.Search);

        base.Start();
    }

    public void Update()
    {
        if (_currentState != null)
        {
            _currentState.Action();
        }
    }

    public override void ChangeState(EState state)
    {
        if (_currentState != null)
        {
            _currentState.ExitState();
        }
        lastState = currentState;
        currentState = state;

        _ui.UpdateStateText(currentState);

        switch (state)
        {
            case EState.Collect:
                _currentState = _collect;
                break;

            case EState.Deliver:
                _currentState = _deliver;
                break;

            case EState.Search:
                _currentState = _search;
                break;

            case EState.MoveTo:
                _currentState = _moveTo;
                break;

            case EState.Death:
                _currentState = _death;
                break;

            case EState.Rest:
                _currentState = _rest;
                break;

            default:
                _currentState = null;
                break;
        }

        if (_currentState != null)
        {
            _currentState.EnterState();
        }
    }

    public override void PlayTrigger(EStateTrigger trigger)
    {
        if (trigger == EStateTrigger.TakeDamage)
        {
            if (vida == 0)
            {
                ChangeState(EState.Death);
            }
        }

        else
        {
            if (currentState == EState.Rest)
            {
                return;
            }

            if (_currentState != null)
            {
                _currentState.TriggerAction(trigger);
            }
        }
    }
}
