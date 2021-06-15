public class MoveTo : State
{
    public MoveTo (Personagem personagem)
    {
        this.personagem = personagem;
    }
    public override void Action()
    {
        if (personagem.ReduceStamina())
        {
            personagem.ChangeState(EState.Rest);
            return;
        }

        if (personagem.isEnemy)
        {
            if (personagem.TItem.IsSafe())
            {
                personagem.ChangeState(EState.Patrol);
                return;
            }
        }

        SetDestination();
    }

    public override void EnterState()
    {
        personagem.agent.isStopped = false;
    }

    public override void ExitState()
    {
        personagem.agent.isStopped = true;
    }

    public override void TriggerAction(EStateTrigger trigger)
    {
        switch (trigger)
        {
            case EStateTrigger.FindItem:
                personagem.ChangeState(EState.Collect);
                break;
        }
    }
    public void SetDestination()
    {
        personagem.agent.SetDestination(personagem.TItem.MyTransform.position);
    }
}
