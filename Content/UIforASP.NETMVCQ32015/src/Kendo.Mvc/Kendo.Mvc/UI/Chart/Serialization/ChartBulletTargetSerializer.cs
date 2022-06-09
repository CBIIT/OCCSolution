namespace Kendo.Mvc.UI
{
    using System.Collections.Generic;
    using Kendo.Mvc.Infrastructure;
    using Kendo.Mvc.Extensions;

    internal class ChartBulletTargetSerializer : IChartSerializer
    {
        private readonly ChartBulletTarget target;

        public ChartBulletTargetSerializer(ChartBulletTarget BulletTarget)
        {
            this.target = BulletTarget;
        }

        public virtual IDictionary<string, object> Serialize()
        {
            var result = new Dictionary<string, object>();
            
            FluentDictionary.For(result)
                .Add("border", target.Border.CreateSerializer().Serialize(), ShouldSerializeBorder)
                .Add("color", target.Color, () => target.Color.HasValue());

            if (target.Width.HasValue)
            {
                var targetLine = new Dictionary<string, object>();
                targetLine["width"] = target.Width;
                result["line"] = targetLine;
            }

            return result;
        }

        private bool ShouldSerializeBorder()
        {
            return target.Border.Color.HasValue() ||
                   target.Border.Width.HasValue ||
                   target.Border.DashType.HasValue;
        }
    }
}