using NUnit.Framework;
using Newtonsoft.Json;
using XplentyApi.Models;

namespace XplentyApi.Test
{
    public class JsonParsingTests
    {

        [Test]
        public void TestClusterResponseCasting()
        {
            const string response = "{\"id\":6636,\"name\":\"WalkMe Cluster\",\"description\":\"asdasd\",\"status\":\"pending\",\"owner_id\":277,\"plan_id\":null,\"nodes\":1,\"type\":\"sandbox\",\"created_at\":\"2014-06-24T10:16:29Z\",\"updated_at\":\"2014-06-24T10:16:29Z\",\"available_since\":null,\"terminated_at\":null,\"launched_at\":null,\"terminate_on_idle\":false,\"time_to_idle\":200,\"terminated_on_idle\":false,\"running_jobs_count\":0,\"url\":\"https://api.xplenty.com/walkmeqa/api/clusters/6636\"}";

            JsonConvert.DeserializeObject<Cluster>(response);

            const string resJob = "{\"id\":298973,\"status\":\"pending_stoppage\",\"variables\":{},\"owner_id\":277,\"progress\":0.0,\"outputs_count\":0,\"started_at\":\"2014-06-24T12:37:02Z\",\"completed_at\":null,\"failed_at\":null,\"created_at\":\"2014-06-24T12:36:57Z\",\"updated_at\":\"2014-06-24T12:37:22Z\",\"cluster_id\":6642,\"package_id\":3044,\"errors\":null,\"url\":\"https://api.xplenty.com/walkmeqa/api/jobs/298973\",\"outputs\":[],\"runtime_in_seconds\":20}";
            JsonConvert.DeserializeObject<Job>(resJob);

            const string response2 = "{\"id\":6642,\"name\":\"WalkMe Cluster\",\"description\":\"asdasd\",\"status\":\"pending_terminate\",\"owner_id\":277,\"plan_id\":null,\"nodes\":1,\"type\":\"sandbox\",\"created_at\":\"2014-06-24T12:23:32Z\",\"updated_at\":\"2014-06-24T12:51:15Z\",\"available_since\":\"2014-06-24T12:50:10Z\",\"terminated_at\":null,\"launched_at\":\"2014-06-24T12:35:45Z\",\"terminate_on_idle\":false,\"time_to_idle\":200,\"terminated_on_idle\":false,\"running_jobs_count\":0,\"url\":\"https://api.xplenty.com/walkmeqa/api/clusters/6642\"}";
            JsonConvert.DeserializeObject<Cluster>(response2);

            const string response3 = "{\"id\":303793,\"status\":\"completed\",\"variables\":{\"destinationTable\":\"ps_tutorial_sum\",\"fromDate\":\"2014-06-28 00:00:00\",\"toDate\":\"2014-06-28 23:59:59\"},\"owner_id\":277,\"progress\":1.0,\"outputs_count\":1,\"started_at\":\"2014-06-30T09:06:31Z\",\"completed_at\":\"2014-06-30T09:10:20Z\",\"failed_at\":null,\"created_at\":\"2014-06-30T09:06:25Z\",\"updated_at\":\"2014-06-30T09:10:20Z\",\"cluster_id\":6724,\"package_id\":3044,\"errors\":null,\"url\":\"https://api.xplenty.com/walkmeqa/api/jobs/303793\",\"outputs\":[{\"id\":386762,\"name\":\"dummy\",\"records_count\":0,\"created_at\":\"2014-06-30T09:10:13Z\",\"updated_at\":\"2014-06-30T09:10:13Z\",\"component_name\":\"destination6\",\"url\":\"https://api.xplenty.com/walkmeqa/api/jobs/303793/outputs/386762\",\"preview_url\":\"https://api.xplenty.com/walkmeqa/api/jobs/303793/outputs/386762/preview\"}],\"runtime_in_seconds\":230}";
            JsonConvert.DeserializeObject<Job>(response3);
        }
    }
}
