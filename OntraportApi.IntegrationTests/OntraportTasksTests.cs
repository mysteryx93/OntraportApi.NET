using System;
using System.Threading.Tasks;
using HanumanInstitute.OntraportApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace HanumanInstitute.OntraportApi.IntegrationTests;

public class OntraportTasksTests(ITestOutputHelper output) : 
    OntraportBaseReadTests<OntraportTasks, ApiTask>(output, 1)
{
    [Fact]
    public async Task UpdateAsync_SetStatus_ReturnsTask()
    {
        using var c = CreateContext();
        var status = ApiTask.TaskStatus.Pending;

        var result = await c.Ontra.UpdateAsync(ValidId, status: status);

        var task = await c.Ontra.SelectAsync(result.Id!.Value);
        Assert.Equal(status, task.StatusField.Value);
    }

    [Fact]
    public async Task AssignAsync_SetNewId_NoException()
    {
        using var c = CreateContext();

        await c.Ontra.AssignAsync(
            (int)ApiObjectType.Contact, 
            new ApiSearchOptions(2));
    }

    [Fact]
    public async Task CancelAsync_TaskId_NoException()
    {
        using var c = CreateContext();

        await c.Ontra.CancelAsync(
            (int)ApiObjectType.Contact,
            new ApiSearchOptions(2));
    }

    [Fact]
    public async Task CompleteAsync_TaskId_NoException()
    {
        using var c = CreateContext();

        await c.Ontra.CompleteAsync(
            ApiObjectType.Contact, 
            new ApiSearchOptions().SetStart(0, 2).SetGroupId(16));
    }

    [Fact]
    public async Task RescheduleAsync_TaskId_NoException()
    {
        using var c = CreateContext();

        await c.Ontra.RescheduleAsync(5, new DateTimeOffset(2019, 09, 27, 12, 0, 0, TimeSpan.Zero));
    }
}
