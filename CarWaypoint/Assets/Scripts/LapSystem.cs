using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LapSystem : MonoBehaviour
{

    [SerializeField] public int totalLaps;
    [SerializeField] public int currentLaps;

    public TextMeshProUGUI lapsDisplay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lapsDisplay.text = "Laps: " + currentLaps + "/" + totalLaps;
    }

    private void OnTriggerEnter(Collider other)
    {
        currentLaps+=1;
    }
}
