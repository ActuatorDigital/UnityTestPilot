using UnityEngine;
using UnityEngine.UI;

public class ExampleDropdownOutputUpdate : MonoBehaviour
{
    [SerializeField] private Text ouputText;
    [SerializeField] private Dropdown inDropdown;

    private void Start()
    {
        inDropdown.onValueChanged.AddListener(SetTextFromDropdown);
    }

    private void SetTextFromDropdown(int index)
    {
        ouputText.text = inDropdown.options[index].text;
    }
}
