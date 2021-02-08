using System.Collections;
using System.Collections.Generic;
using Robot;
using UnityEngine;
using UnityEngine.UI;

public class PartRecordInformationPanelGUI : MonoBehaviour
{
    [SerializeField] private PartRecord partRecord;

    [SerializeField] private Text nameText;

    [SerializeField] private Text descriptionText;

    [SerializeField] private Image displayImage;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetRecord(PartRecord newRecord)
    {
        partRecord = newRecord;
    }

    public void Hide()
    {
        
    }
}
