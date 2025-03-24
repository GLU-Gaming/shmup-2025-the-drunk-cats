using UnityEngine;
using TMPro;
public class FinalScore : MonoBehaviour
{
    public TextMeshProUGUI FinalScor;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FinalScor = GetComponent<TextMeshProUGUI>();
        int LoadedNumber = PlayerPrefs.GetInt("finalscore");
        FinalScor.text = "Final Score:" + LoadedNumber.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
