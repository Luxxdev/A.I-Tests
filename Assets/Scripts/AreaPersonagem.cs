using UnityEngine;

public class AreaPersonagem : MonoBehaviour
{
    [SerializeField]
    private Personagem _personagem = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Personagem _))
        {
            _personagem.PlayTrigger(EStateTrigger.GetClose);
        }
    }

}
