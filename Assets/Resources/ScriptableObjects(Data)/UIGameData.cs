using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class UIGameData : ScriptableObject
{
    [SerializeField]
    private Slider meter;
    [SerializeField]
    private Text meterText;

    [SerializeField]
    private GameObject[] ps;

    [SerializeField]
    private GameObject image;

    public Slider Meter { get { return meter; } set { meter = value; } }
    public Text MeterText { get { return meterText; } set { meterText = value; } }
    public GameObject Image { get { return image; } set { image = value; } }
    public GameObject[] Ps { get { return ps; } set { ps = value; } }

    public void Dosomething()
    {

    }
}
