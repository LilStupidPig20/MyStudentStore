﻿using RTF.Core.Models.Enums;

namespace RTF.CQS.ModelsFromUI.ResponseModels;

public class ExtendedEventInfoFrame
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public DateTime StartDateTime { get; set; }
    
    public DateTime EndDateTime { get; set; }

    public EventType EventType { get; set; }
    
    public double Coins { get; set; }
    
    public List<string> OrganizersNames { get; set; }
}