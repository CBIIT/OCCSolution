namespace Kendo.Mvc.UI
{
    using System.Collections.Generic;
    using Kendo.Mvc.Infrastructure;
    using Kendo.Mvc.Extensions;

    internal class ChartLineMarkersSerializer : IChartSerializer
    {
        private readonly ChartMarkers lineMarker;

        public ChartLineMarkersSerializer(ChartMarkers chartLineMarker)
        {
            this.lineMarker = chartLineMarker;
        }

        public virtual IDictionary<string, object> Serialize()
        {
            var result = new Dictionary<string, object>();
            
            FluentDictionary.For(result)
                .Add("visible", lineMarker.Visible, () => lineMarker.Visible.HasValue)
                .Add("border", lineMarker.Border.CreateSerializer().Serialize(), ShouldSerializeBorder)
                .Add("type", lineMarker.Type.ToString().ToLowerInvariant(), () => lineMarker.Type.HasValue)
                .Add("size", lineMarker.Size, () => lineMarker.Size.HasValue)
                .Add("rotation", lineMarker.Rotation, () => lineMarker.Rotation.HasValue)
                .Add("visual", lineMarker.Visual, () => lineMarker.Visual != null);

            if (lineMarker.BackgroundHandler.HasValue())
            {
                result.Add("background", lineMarker.BackgroundHandler);
            }
            else if (lineMarker.Background.HasValue())
            {
                result.Add("background", lineMarker.Background);
            }

            return result;
        }

        private bool ShouldSerializeBorder()
        {
            return lineMarker.Border.Color.HasValue() ||
                   lineMarker.Border.Width.HasValue ||
                   lineMarker.Border.DashType.HasValue;
        }
    }
}