using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItemArea : MonoBehaviour
{
    [SerializeField]
    private Personagem _personagem = null;

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Item item))
        {
            if (item.MyTransform.parent != null)
            {
                return;
            }

            if (_personagem.currentState != EState.MoveTo)
            {
                return;
            }

            if (_personagem.Item == null)
            {
                if (_personagem.isEnemy || (!_personagem.isEnemy && !item.CanLeave()))
                {
                    _personagem.CollectItem(item);
                    _personagem.PlayTrigger(EStateTrigger.FindItem);
                }
            }
        }
    }
}
