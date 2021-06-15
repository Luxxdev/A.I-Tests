using UnityEngine;

public class ItemCatalog : MonoBehaviour
{
    [SerializeField]
    private ItensUI _ui = null;

    [SerializeField]
    private Item[] _items = null;

    public Item[] Items
    {
        get
        {
            return _items;
        }
    }

    private void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        int coletados = 0;
        int restantes = 0;

        for(int i = 0; i < _items.Length; i++)
        {
            if (_items[i].Entregue)
            {
                coletados++;
            }
            else
            {
                restantes++;
            }
        }

        _ui.UpdateUI(coletados, restantes);
    }
}
