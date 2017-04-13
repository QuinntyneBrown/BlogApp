using System;
using System.Collections.Generic;
using MetricsDrivenDevelopment.Data.Helpers;
using System.ComponentModel.DataAnnotations.Schema;

namespace MetricsDrivenDevelopment.Data.Model
{
    [SoftDelete("IsDeleted")]
    public class AppComponent
    {
        public int Id { get; set; }

        [ForeignKey("App")]
        public int? AppId { get; set; }

        [ForeignKey("Component")]
        public int? ComponentId { get; set; }

        public virtual App App { get; set; }

        public virtual Component Component { get; set; }

        public bool IsDeleted { get; set; }
    }
}
