﻿namespace HanumanInstitute.OntraportApi;

/// <summary>
/// Provides Ontraport API support for CampaignBuilderItem objects.
/// These objects contain data on your CampaignBuilder campaigns, such as names, IDs, and current status. 
/// In this section, "campaign" refers to automated marketing campaigns. You can retrieve a single campaign or a list of campaigns.
/// </summary>
public class OntraportCampaignBuilderItems : OntraportBaseRead<ApiCampaignBuilderItem>, IOntraportCampaignBuilderItems
{
    public OntraportCampaignBuilderItems(OntraportHttpClient apiRequest) :
        base(apiRequest, "CampaignBuilderItem", "CampaignBuilderItems")
    { }
        
}
