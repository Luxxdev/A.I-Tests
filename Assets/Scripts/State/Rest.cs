using UnityEngine;

public class Rest : State
{
    public Rest(Personagem personagem)
    {
        this.personagem = personagem;
    }

    public override void EnterState()
    {
        personagem.agent.isStopped = true;
    }

    public override void Action()
    {
        personagem.stamina += personagem.staminaRecoverySpeed * Time.deltaTime;
        personagem.stamina = Mathf.Min(personagem.stamina, personagem.MaxStamina);

        if(personagem.stamina >= personagem.MaxStamina)
        {
            personagem.ChangeState(personagem.lastState);
        }
    }

    public override void ExitState()
    {
        personagem.agent.isStopped = false;
    }

    public override void TriggerAction(EStateTrigger trigger)
    {
    }
}
