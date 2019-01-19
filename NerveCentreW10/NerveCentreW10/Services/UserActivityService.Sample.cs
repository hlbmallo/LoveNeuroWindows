using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using AdaptiveCards;

using NerveCentreW10.Activation;
using NerveCentreW10.Models;
using NerveCentreW10.Views;

using Windows.ApplicationModel;
using Windows.UI;
using Windows.UI.Shell;

namespace NerveCentreW10.Services
{
    public static partial class UserActivityService
    {
        public static async Task AddSampleUserActivity()
        {
            var activityId = "ActivityId";
            var displayText = "Display Text";
            var description = $"Sample UserActivity added from Application '{Package.Current.DisplayName}' at {DateTime.Now.ToShortTimeString()}";
            var imageUrl = "http://adaptivecards.io/content/cats/2.png";

            var activityData = new UserActivityData(activityId, CreateActivationDataSample(), displayText, Colors.DarkRed);
            var adaptiveCard = CreateAdaptiveCardSample(displayText, description, imageUrl);

            await UserActivityService.CreateUserActivityAsync(activityData, adaptiveCard);
        }

        public static SchemeActivationData CreateActivationDataSample()
        {
            //var parameters = new Dictionary<string, string>()
            //{
            //    { "paramName1", "paramValue1" },
            //    { "ticks", DateTime.Now.Ticks.ToString() }
            //};
            //return new SchemeActivationData(typeof(SchemeActivationSamplePage), parameters);

            var parameters = new SubsectionModel()
            {
                Title = "hello2",
            };
            return new SchemeActivationData(typeof(DetailPage), parameters);

        }

        // TODO WTS: Change this to configure your own adaptive card
        // For more info about adaptive cards see http://adaptivecards.io/
        public static IAdaptiveCard CreateAdaptiveCardSample(string displayText, string description, string imageUrl)
        {
            var adaptiveCard = new AdaptiveCard("1.1.2");
            var columns = new AdaptiveColumnSet();
            var firstColumn = new AdaptiveColumn() { Width = "auto" };
            var secondColumn = new AdaptiveColumn() { Width = "*" };

            firstColumn.Items.Add(new AdaptiveImage()
            {
                Url = new Uri(imageUrl),
                Size = AdaptiveImageSize.Medium
            });

            secondColumn.Items.Add(new AdaptiveTextBlock()
            {
                Text = displayText,
                Weight = AdaptiveTextWeight.Bolder,
                Size = AdaptiveTextSize.Large
            });

            secondColumn.Items.Add(new AdaptiveTextBlock()
            {
                Text = description,
                Size = AdaptiveTextSize.Medium,
                Weight = AdaptiveTextWeight.Lighter,
                Wrap = true
            });

            columns.Columns.Add(firstColumn);
            columns.Columns.Add(secondColumn);
            adaptiveCard.Body.Add(columns);

            return AdaptiveCardBuilder.CreateAdaptiveCardFromJson(adaptiveCard.ToJson());
        }
    }
}
