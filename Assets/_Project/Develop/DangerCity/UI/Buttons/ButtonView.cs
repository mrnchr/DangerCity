using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Zenject;

namespace DangerCity.UI.Buttons
{
  public class ButtonView<TModel> : MonoBehaviour, IPointerDownHandler, ITickable where TModel : ButtonModel
  {
    [SerializeField]
    private Button _button;

    private TModel _model;
    private TickableManager _ticker;

    [Inject]
    public void Construct(TModel model, TickableManager ticker)
    {
      _ticker = ticker;
      _model = model;
      _ticker.Add(this, -1);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
      _model.WasPerformedThisFrame = true;
      _model.FrameCountLost = 0;
    }

    public void Tick()
    {
      if (_model.FrameCountLost > 0)
      {
        _model.WasPerformedThisFrame = false;
        _model.FrameCountLost = 0;
      }
      else
      {
        _model.FrameCountLost++;
      }
    }

    private void OnDestroy()
    {
      _ticker.Remove(this);
    }

    private void Reset()
    {
      _button = GetComponent<Button>();
    }
  }
}