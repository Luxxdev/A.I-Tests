using UnityEngine;

public class Inimigo : Personagem
{
    private Attack _attack = null;
    private Patrol _patrol = null;
    private Follow _follow = null;
    private Collect _collect = null;
    private Deliver _deliver = null;
    private Search _search = null;
    private MoveTo _moveTo = null;
    private Rest _rest = null;




    public Personagem jogador = null;

    public DamageArea damageArea = null;

    public Transform[] points = null;

    public void Awake()
    {
        _patrol = new Patrol(this, points);
        _follow = new Follow(this);
        _collect = new Collect(this);
        _deliver = new Deliver(this);
        _attack = new Attack(this);
        _search = new Search(this);
        _moveTo = new MoveTo(this);
        _rest = new Rest(this);


        agent.speed = velocidade;
    }

    protected override void Start()
    {
        ChangeState(EState.Patrol);
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
        if(_currentState != null)
        {
            _currentState.ExitState();
        }

        lastState = currentState;
        currentState = state;

        _ui.UpdateStateText(currentState);

        switch (state)
        {
            case EState.Patrol:
                _currentState = _patrol;
                break;

            case EState.Follow:
                _currentState = _follow;
                break;

            case EState.Collect:
                _currentState = _collect;
                break;

            case EState.Deliver:
                _currentState = _deliver;
                break;

            case EState.MoveTo:
                _currentState = _moveTo;
                break;

            case EState.Attack:
                _currentState = _attack;
                break;

            case EState.Search:
                _currentState = _search;
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
        if(currentState == EState.Rest)
        {
            return;
        }

        if (_currentState != null)
        {
            _currentState.TriggerAction(trigger);
        }
    }
}
