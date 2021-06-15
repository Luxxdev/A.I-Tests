using UnityEngine;

public class Search : State
{
    public Search(Personagem personagem)
    {
        this.personagem = personagem;
    }
    public override void EnterState()
    {
        personagem.agent.isStopped = true;
    }
    public override void Action()
    {
        float distance = float.MaxValue;
        float tempDistance;
        int index = 0;

        for (int i = 0; i < personagem.itemCatalog.Items.Length; i++)
        {
            if (personagem.itemCatalog.Items[i].HasParent)
            {
                continue;
            }

            if (personagem.itemCatalog.Items[i].CanLeave())
            {
                continue;
            }

            tempDistance = Vector3.Distance(personagem.myTransform.position, personagem.itemCatalog.Items[i].MyTransform.position);

            if (tempDistance < distance)
            {
                distance = tempDistance;
                index = i;
            }
        }

        personagem.TargetItem(personagem.itemCatalog.Items[index]);
        personagem.ChangeState(EState.MoveTo);
    }
    public override void TriggerAction(EStateTrigger trigger)
    {
    }
    public override void ExitState()
    {
    }
}
