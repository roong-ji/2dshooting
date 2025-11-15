using UnityEngine;
using UnityEngine.UI;

public class AutoButton : MonoBehaviour
{
	[Header("버튼 이미지")
	[SerializeField] private Image _buttonImage;
	[SerializeField] private Sprite _onSprite;
	[SerializeField] private Sprite _offSprite;
	private bool _isButtonOn = false;

	public void ToggleButtonImage()
	{
		_isButtonOn = !_isButtonOn;
		_buttonImage.sprite = _isButtonOn ? _onSprite : _offSprite;
	}
}