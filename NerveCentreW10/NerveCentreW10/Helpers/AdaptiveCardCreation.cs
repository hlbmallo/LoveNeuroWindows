using AdaptiveCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Shell;

namespace NerveCentreW10.Helpers
{
    public class AdaptiveCardCreation
    {
        public static IAdaptiveCard CreateAdaptiveCardWithImage(string displayText, string description, string imageUrl)
        {
            var adaptiveCard = new AdaptiveCard("1.1.2");
            var columns = new AdaptiveColumnSet();
            var firstColumn = new AdaptiveColumn() { Width = "0.4*" };
            var secondColumn = new AdaptiveColumn() { Width = "0.6*" };

            firstColumn.Items.Add(new AdaptiveImage()
            {
                Url = new Uri(imageUrl),
                Size = AdaptiveImageSize.Auto,
            });

            secondColumn.Items.Add(new AdaptiveTextBlock()
            {
                Text = displayText,
                Weight = AdaptiveTextWeight.Bolder,
                Size = AdaptiveTextSize.Large,
                Wrap = true

            });

            //secondColumn.Items.Add(new AdaptiveTextBlock()
            //{
            //    Text = description,
            //    Size = AdaptiveTextSize.Medium,
            //    Weight = AdaptiveTextWeight.Lighter,
            //    Wrap = true
            //});

            columns.Columns.Add(firstColumn);
            columns.Columns.Add(secondColumn);
            adaptiveCard.Body.Add(columns);

            return AdaptiveCardBuilder.CreateAdaptiveCardFromJson(adaptiveCard.ToJson());
        }

        public static IAdaptiveCard CreateAdaptiveCardWithoutImage(string displayText)
        {
            var adaptiveCard = new AdaptiveCard("1.1.2");
            var columns = new AdaptiveColumnSet();
            var firstColumn = new AdaptiveColumn() { Width = "Auto" };

            firstColumn.Items.Add(new AdaptiveTextBlock()
            {
                Text = displayText,
                Weight = AdaptiveTextWeight.Bolder,
                Size = AdaptiveTextSize.Large,
                Wrap = true

            });

            columns.Columns.Add(firstColumn);
            adaptiveCard.Body.Add(columns);

            return AdaptiveCardBuilder.CreateAdaptiveCardFromJson(adaptiveCard.ToJson());
        }
    }
}
