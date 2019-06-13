using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmergenceGuardian.OntraportApi.Models;
using Xunit;
using Xunit.Abstractions;

namespace EmergenceGuardian.OntraportApi.IntegrationTests
{
    public class OntraportTasksTests : OntraportBaseReadTests<OntraportTasks, ApiTask>
    {
        public OntraportTasksTests(ITestOutputHelper output) :
            base(output, 1)
        {
        }

        [Fact]
        public async Task UpdateAsync_SetStatus_ReturnsTask()
        {
            var api = SetupApi();
            var status = ApiTask.TaskStatus.Cancelled;

            var result = await api.UpdateAsync(ValidId, status: status);

            Assert.Equal(status, result.Status.Value);
        }

        [Fact]
        public async Task AssignAsync_SetNewId_NoException()
        {
            var api = SetupApi();
            var message = new List<AssignTaskMessage>
            {
                new AssignTaskMessage()
                {
                    Id = 1,
                    DueDate = DateTimeOffset.UtcNow,
                    Type = ApiTask.TaskType.Fulfillment
                }
            };

            await api.AssignAsync(
                (int)ApiObjectType.Contact, 
                new ApiSearchOptions(2));
        }

        [Fact]
        public async Task CancelAsync_TaskId_NoException()
        {
            var api = SetupApi();

            await api.CancelAsync(
                (int)ApiObjectType.Contact,
                new ApiSearchOptions(2));
        }

        [Fact]
        public async Task CompleteAsync_TaskId_NoException()
        {
            var api = SetupApi();

            await api.CompleteAsync(
                ApiObjectType.Contact, 
                new ApiSearchOptions().SetStart(0, 2).SetGroupId(16));
        }

        [Fact]
        public async Task RescheduleAsync_TaskId_NoException()
        {
            var api = SetupApi();

            await api.RescheduleAsync(5, new DateTimeOffset(2019, 09, 27, 12, 0, 0, TimeSpan.Zero));
        }
    }
}
