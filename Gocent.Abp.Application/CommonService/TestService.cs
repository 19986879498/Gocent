using System;
using System.Collections.Generic;
using Gocent.Abp.Application.Contracts.ICommonService;

namespace Gocent.Abp.Application.CommonService
{
    public class TestService : ITestService
    {
        /// <summary>
        /// 测试Api
        /// </summary>
        /// <returns></returns>
        public List<string> GetStrings()
        {
            return new List<string>(){"周一","周二","周三","周四","周五","周六","周日"};
        }
    }
}
