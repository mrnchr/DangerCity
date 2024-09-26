using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace DangerCity.Gameplay.Lamp
{
  [AddComponentMenu(ACC.Names.LAMP_VIEW)]
  [RequireComponent(typeof(SpriteRenderer))]
  public class LampView : MonoBehaviour
  {
    [FormerlySerializedAs("Green")]
    [SerializeField]
    private Color OpenColor;

    private SpriteRenderer _spriteRenderer;

    [Inject]
    public void Construct(ILampPresenter presenter)
    {
      _spriteRenderer = GetComponent<SpriteRenderer>();
      presenter.SetView(this);
    }

    public void SetOpenColor()
    {
      _spriteRenderer.color = OpenColor;
    }
  }
}