using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace DangerCity.UI.Buttons
{
    public class ButtonView<TModel> : MonoBehaviour, IPointerDownHandler, ITickable where TModel : ButtonModel
    {
        private TModel _model;
        private TickableManager _ticker;

        [Inject]
        public void Construct(TModel model, TickableManager ticker)
        {
            _ticker = ticker;
            _model = model;
            _ticker.Add(this, -1);
        }

        private void OnDestroy()
        {
            _ticker.Remove(this);
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
    }
}