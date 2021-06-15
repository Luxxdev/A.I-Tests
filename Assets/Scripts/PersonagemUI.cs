using UnityEngine;
using UnityEngine.UI;

public class PersonagemUI : MonoBehaviour
{
    [SerializeField]
    private Transform _camera = null;

    [SerializeField]
    private RectTransform _rectTransform = null;

    [SerializeField]
    private Text _speedText = null;
    [SerializeField]
    private Text _lifeText = null;
    [SerializeField]
    private Text _stateText = null;

    void Update()
    {
        _rectTransform.LookAt(_camera.position);

        Vector3 angles = _rectTransform.eulerAngles;
        angles.y += 180.0f;
        _rectTransform.eulerAngles = angles;
    }

    public void UpdateSpeedText(float speed)
    {
        _speedText.text = string.Concat("Velocidade: ", speed.ToString());
    }
    public void UpdateStateText(EState state)
    {
        _stateText.text = string.Concat("Estado: ", state.ToString());
    }
    public void UpdateLifeText(int life)
    {
        _lifeText.text = string.Concat("Vida: ", life.ToString());
    }
}
