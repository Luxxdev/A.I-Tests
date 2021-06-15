using UnityEngine;
using UnityEngine.UI;

public class ItensUI : MonoBehaviour
{
    [SerializeField]
    private Text _coletadosText = null;
    [SerializeField]
    private Text _restantesText = null;

    public void UpdateUI(int coletados, int restantes)
    {
        _coletadosText.text = string.Format("Itens Coletados: {0}", coletados.ToString("00"));

        _restantesText.text = string.Concat("Itens Restantes: ", restantes.ToString("00"));
    }
}
