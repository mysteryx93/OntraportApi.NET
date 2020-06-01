using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using HanumanInstitute.OntraportApi.Converters;

namespace HanumanInstitute.OntraportApi.Models
{
    /// <summary>
    /// When assigning a task through the API, you can include an array of data pertaining to the task message. 
    /// You can specify which task message to use and the due date and assignee of the task.
    /// </summary>
    [JsonObject(NamingStrategyType = typeof(SnakeCaseNamingStrategy), ItemNullValueHandling = NullValueHandling.Ignore)]
    public class AssignTaskMessage
    {
        /// <summary>
        /// Gets or sets the task message ID.
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// Gets or sets the task type.
        /// </summary>
        [JsonConverter(typeof(JsonConverterIntEnum<ApiTask.TaskType>))]
        public ApiTask.TaskType? Type { get; set; }
        /// <summary>
        /// Gets or sets the date and time the task will be due.
        /// </summary>
        [JsonConverter(typeof(JsonConverterDateTime))]
        public DateTimeOffset? DueDate { get; set; }
        /// <summary>
        /// Gets or sets the ID of the user responsible for the task.
        /// </summary>
        public int? TaskOwner { get; set; }
    }
}
