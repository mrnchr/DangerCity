using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace DangerCity.UI.Coins
{
    [AddComponentMenu(ACC.Names.COINS_VIEW)]
    public class CoinsView : MonoBehaviour
    {
        [SerializeField]
        private Text _scoreText;

        private void Reset()
        {
            _scoreText = GetComponent<Text>();
        }

        [Inject]
        public void Construct(ICoinsPresenter presenter)
        {
            presenter.SetView(this);
        }

        public void SetScore(string text)
        {
            _scoreText.text = text;
        }
    }
}