using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ButtonTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	[SerializeField] GameObject tip;
	// Start is called before the first frame update
	public void OnPointerEnter(PointerEventData eventData)
	{
		tip.SetActive(true);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		tip.SetActive(false);
	}
}
