public abstract class State
{
    public Personagem personagem;

    public abstract void EnterState();
    public abstract void TriggerAction(EStateTrigger trigger);
    public abstract void Action();
    public abstract void ExitState();

}

public enum EState
{
    None = -1,
    Patrol = 0,
    Follow,
    Collect,
    Deliver,
    Search,
    Attack,
    Death,
    Hide,
    MoveTo,
    Rest
}

public enum EStateTrigger
{
    TakeDamage = 0,
    FindItem = 1,
    ArriveDestination = 2,
    GetClose = 3
}
