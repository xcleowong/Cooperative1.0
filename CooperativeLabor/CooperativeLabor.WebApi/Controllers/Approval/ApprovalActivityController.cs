using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CooperativeLabor.WebApi.Controllers.Approval
{
    using CooperativeLabor.Model;
    using CooperativeLabor.IServices;
    using CooperativeLabor.Services;
    using Unity.Attributes;
    [RoutePrefix("ApprovalActivity")]
    public class ApprovalActivityController : ApiController
    {
        [Dependency]
        public IApprovalActivityServices IapprovalActivity { get; set; }
        
    }
}
