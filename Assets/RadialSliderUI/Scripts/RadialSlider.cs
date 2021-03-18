using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class RadialSlider: MonoBehaviour
{
	[SerializeField] private Image slider;
	[SerializeField] private TextMeshProUGUI text;

	public void UpdateSliderValue(float value, float limit) {
		slider.fillAmount = value / limit;
		text.text = ((int)slider.fillAmount).ToString();
	}
}
