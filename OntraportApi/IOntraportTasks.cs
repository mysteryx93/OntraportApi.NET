using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using HanumanInstitute.OntraportApi.Models;

namespace HanumanInstitute.OntraportApi
{
    /// <summary>
    /// Provides Ontraport API support for Task objects.
    /// A task object is created when a task is assigned to a contact or other object.
    /// </summary>
    public interface IOntraportTasks : IOntraportBaseRead<ApiTask>
    {
        /// <summary>
        /// Updates a task with a new assignee, due date, or status.
        /// </summary>
        /// <param name="taskId">The task ID.</param>
        /// <param name="owner">The ID of the task assignee.</param>
        /// <param name="dateDue">The date and time the task should be due.</param>
        /// <param name="status">The task's status.</param>
        /// <returns>An object containing updated fields.</returns>
        Task<ApiTask> UpdateAsync(int taskId, int? owner = null, DateTimeOffset? dateDue = null, ApiTask.TaskStatus? status = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assigns a task to one or more contacts.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="searchOptions">The search options.</param>
        /// <param name="message">Data for the task message to assign to contacts.</param>
        Task AssignAsync(ApiObjectType objectType, ApiSearchOptions? searchOptions = null, AssignTaskMessage? message = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Cancels one or more tasks.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="searchOptions">The search options.</param>
        Task CancelAsync(ApiObjectType objectType, ApiSearchOptions? searchOptions = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Marks one or more tasks as completed.
        /// </summary>
        /// <param name="objectType">The object type.</param>
        /// <param name="searchOptions">The search options.</param>
        /// <param name="data">Additional data to set, see documentation.</param>
        /// <returns></returns>
        Task CompleteAsync(ApiObjectType objectType, ApiSearchOptions? searchOptions = null, IDictionary<string, object?>? data = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Reschedules a task for a different date and time.
        /// </summary>
        /// <param name="id">The task ID.</param>
        /// <param name="newTime">The date and time the task should be rescheduled for.</param>
        /// <returns></returns>
        Task RescheduleAsync(int id, DateTimeOffset newTime, CancellationToken cancellationToken = default);
    }
}
