using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(TextMeshProUGUI))]
public class OpenHyperlinks : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Camera _camera;
    
    public void OnPointerClick(PointerEventData eventData) 
    {
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(_text, Input.mousePosition, _camera);
        if( linkIndex != -1 ) 
        {
            TMP_LinkInfo linkInfo = _text.textInfo.linkInfo[linkIndex];
            Application.OpenURL(linkInfo.GetLinkID());
        }
    }
}
