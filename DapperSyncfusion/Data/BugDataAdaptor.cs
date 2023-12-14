using Syncfusion.Blazor.Data;
using Syncfusion.Blazor;

namespace DapperSyncfusion.Data
{
    public class BugDataAdaptor : DataAdaptor
    {
        private BugDataAccessLayer _dataLayer;
        public BugDataAdaptor(BugDataAccessLayer bugDataAccessLayer)
        {
            _dataLayer = bugDataAccessLayer;
        }

        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string key = null)
        {
            List<Bug> bugs = await _dataLayer.GetBugsAsync();
            int count = await _dataLayer.GetBugCountAsync();
            return dataManagerRequest.RequiresCounts ? new DataResult() { Result = bugs, Count = count } : count;
        }
    }
}
