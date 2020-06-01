using System;
using HanumanInstitute.OntraportApi.Models;

namespace HanumanInstitute.OntraportApi
{
    /// <summary>
    /// Provides Ontraport API support for CampaignBuilderItem objects.
    /// These objects contain data on your CampaignBuilder campaigns, such as names, IDs, and current status. 
    /// In this section, "campaign" refers to automated marketing campaigns. You can retrieve a single campaign or a list of campaigns.
    /// </summary>
    public interface IOntraportCampaignBuilderItems : IOntraportBaseRead<ApiCampaignBuilderItem>
    {
    }
}
