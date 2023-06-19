using LoigcAppsStandardRunActions.Models.WorkflowRunAcionsList;
using LoigcAppsStandardRunActions.Models.WorkflowRunsList;
using System.Text.Json;

namespace LoigcAppsStandardRunActions
{
    public class Class1
    {
        private readonly HttpClient _httpClient;
        private readonly string _resourceGroupName;
        private readonly string _subscriptionId;
        private readonly string _siteName;
        private readonly string _workflowName;

        public Class1(HttpClient httpClient, string resourceGroupName, string subscriptionId, string siteName, string workflowName)
        {
            _httpClient = httpClient;
            _resourceGroupName = resourceGroupName;
            _subscriptionId = subscriptionId;
            _siteName = siteName;
            _workflowName = workflowName;
        }

        public async Task Otameshi()
        {
            // get run list
            var runsList = await GetWorkflowRunsListAsync();

            foreach (var run in runsList.value)
            {
                // get run actions
                var actionsList = await GetWorkflowRunActionsListAsync(run.name);

                foreach (var action in actionsList.value)
                {
                    var simpleModel = new SimpleModel(action.name, action.properties.startTime, action.properties.endTime);
                    simpleModel.Print();
                }
            }
        }

        private async Task<WorkflowRunsListResponse> GetWorkflowRunsListAsync()
        {
            // GET https://management.azure.com/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hostruntime/runtime/webhooks/workflow/api/management/workflows/{workflowName}/runs?api-version=2022-03-01

            var url = $"https://management.azure.com/subscriptions/{_subscriptionId}/resourceGroups/{_resourceGroupName}/providers/Microsoft.Web/sites/{_siteName}/hostruntime/runtime/webhooks/workflow/api/management/workflows/{_workflowName}/runs?api-version=2022-03-01";
            var responseBody = await CallGetRequestAsync(url);

            return JsonSerializer.Deserialize<WorkflowRunsListResponse>(responseBody);
        }

        private async Task<WorkflowRunAcionsListResponse> GetWorkflowRunActionsListAsync(string runName)
        {
            // GET https://management.azure.com/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/sites/{name}/hostruntime/runtime/webhooks/workflow/api/management/workflows/{workflowName}/runs/{runName}/actions?api-version=2022-03-01

            var url = $"https://management.azure.com/subscriptions/{_subscriptionId}/resourceGroups/{_resourceGroupName}/providers/Microsoft.Web/sites/{_siteName}/hostruntime/runtime/webhooks/workflow/api/management/workflows/{_workflowName}/runs/{runName}/actions?api-version=2022-03-01";
            var responseBody = await CallGetRequestAsync(url);

            return JsonSerializer.Deserialize<WorkflowRunAcionsListResponse>(responseBody);
        }

        private async Task<string> CallGetRequestAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);
            var responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("era!");
            }

            return responseBody;
        }
    }
}