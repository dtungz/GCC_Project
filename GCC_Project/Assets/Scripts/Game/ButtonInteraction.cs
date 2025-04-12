using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ButtonInrteraction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Vector3 normalSize = new Vector3(1f, 1f, 1f);
    public Vector3 underCursorSize = new Vector3(0.8f, 0.8f, 1f);
    private RectTransform rt;
    void Start()
    {
        rt = GetComponent<RectTransform>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        rt.localScale = underCursorSize;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        rt.localScale = normalSize;
    }
}
