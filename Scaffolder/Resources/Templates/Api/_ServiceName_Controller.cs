namespace $ModuleNamespace$.Api
{
    using System.Web.Mvc;
    using AttributeRouting.Web.Mvc;
    using Service;
    using Models;
    using ShoutEm.Api;
    using ShoutEmBase.Controllers;
    using RoutePrefixAttribute = AttributeRouting.RoutePrefixAttribute;

    [RoutePrefix("{nid:int}/$ModuleName; format="lower"$/objects/$ServiceName$")]
    public class $ControllerName$ :
        RestController<$ServiceName$, $ServiceModelName$, long, $ServiceIoName$>
    {
        private readonly I$ServiceName$Repository repository;

        public $ControllerName$(I$ServiceName$Repository repository)
        {
            this.repository = repository;
        }

        [GET("{id:long}")]
        public override ActionResult Get(long id) { return base.Get(id); }

        [AssertNetwork]
        [AssertUserCanManageApplication]
        [POST("")]
        public override ActionResult Add($ServiceIoName$ io) { return base.Add(io); }

        [AssertUserCanManageApplication]
        [POST("{id:long}")]
        public override ActionResult Update(long id, $ServiceIoName$ io) { return base.Update(id, io); }

        [AssertUserCanManageApplication]
        [DELETE("{id:long}")]
        public override EmptyResult Delete(long id) { return base.Delete(id); }
    }
}
