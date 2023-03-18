using TMPro;
using UnityEngine;

public class NameChanger : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInput;
    private TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void ChangeName()
    {
        text.SetText(nameInput.text);
    }
}
