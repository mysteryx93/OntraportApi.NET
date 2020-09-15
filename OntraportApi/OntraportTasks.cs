using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HanumanInstitute.OntraportApi.Converters;
using HanumanInstitute.OntraportApi.Models;
using Newtonsoft.Json.Linq;

namespace HanumanInstitute.OntraportApi
{
    /// <summary>
    /// Provides Ontraport API support for Task objects.
    /// A task object is created when a task is assigned to a contact or other object.
    /// </summary>
    public class OntraportTasks : OntraportBaseRead<ApiTask>, IOntraportTasks
    {
        public OntraportTasks(OntraportHttpClient apiRequest) : 
            base(apiRequest, "Task", "Tasks")
        { }

        /// <summary>
        /// Updates a task with a new assignee, due date, or status.
        /// </summary>
        /// <param name="taskId">The task ID.</param>
        /// <param name="owner">The ID of the task assignee.</param>
        /// <param name="dateDue">The date and time the task should be due.</param>
        /// <param name="status">The task's status.</param>
        /// <returns>An object containing updated fields.</returns>
        public async Task<ApiTask> UpdateAsync(int taskId, int? owner = null, DateTimeOffset? dateDue = null, ApiTask.TaskStatus? status = null, CancellationToken cancellationToken = default)
        {
            var query = new Dictionary<string, object?>
            {
                { "id", taskId },
            }
                .AddIfHasValue("owner", owner)
                .AddIfHasValue("date_due", new JsonConverterDateTime().Format(dateDue))
                .AddIfHasValue("status", new JsonConverterStringEnum<ApiTask.TaskStatus>().Format(status));

            var json = await ApiRequest.PutAsync<JObject>(
                "Tasks", query, cancellationToken).ConfigureAwait(false);
            return await CreateApiObjectAsync(JsonData(json)["attrs"]).ConfigureAwait(false);
        }

        /// <summary>
        /// Assigns a task to one or more contacts.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="searchOptions">The search options.</param>
        /// <param name="message">Data for the task message to assign to contacts.</param>
        public async Task AssignAsync(ApiObjectType objectType, ApiSearchOptions? searchOptions = null, AssignTaskMessage? message = null, CancellationToken cancellationToken = default)
        {
            var query = new Dictionary<string, object?>
            {
                { "object_type_id", (int)objectType },
            }
                .AddSearchOptions(searchOptions, true)
                .AddIfHasValue("message", message);

            await ApiRequest.PostAsync<object>(
                "task/assign", query, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Cancels one or more tasks.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="searchOptions">The search options.</param>
        public async Task CancelAsync(ApiObjectType objectType, ApiSearchOptions? searchOptions = null, CancellationToken cancellationToken = default)
        {
            var query = new Dictionary<string, object?>
            {
                { "objectID", (int)objectType }
            }
                .AddSearchOptions(searchOptions, true);

            await ApiRequest.PostAsync<object>(
                "task/cancel", query, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Marks one or more tasks as completed.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="searchOptions">The search options.</param>
        /// <param name="data">Additional data to set, see documentation.</param>
        /// <returns></returns>
        public async Task CompleteAsync(ApiObjectType objectType, ApiSearchOptions? searchOptions = null, IDictionary<string, object?>? data = null, CancellationToken cancellationToken = default)
        {
            var query = new Dictionary<string, object?>
            {
                { "objectID", (int)objectType }
            }
                .AddSearchOptions(searchOptions, true)
                .AddIfHasValue("data", data);

            await ApiRequest.PostAsync<object>(
                "task/complete", query, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Reschedules a task for a different date and time.
        /// </summary>
        /// <param name="id">The task ID.</param>
        /// <param name="newTime">The date and time the task should be rescheduled for.</param>
        /// <returns></returns>
        public async Task RescheduleAsync(int id, DateTimeOffset newTime, CancellationToken cancellationToken = default)
        {
            var query = new Dictionary<string, object?>
            {
                { "id", id },
                { "newtime", new JsonConverterDateTime().Format(newTime) }
            };

            await ApiRequest.PostAsync<object>(
                "task/reschedule", query, cancellationToken).ConfigureAwait(false);
        }
    }
}
