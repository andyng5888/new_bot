using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System.Threading;

namespace Bot_Application.Dialogs
{
    [Serializable]
    [LuisModel("1c20602d-a4b5-4195-b157-3796bc219d00", "186c630cce0c49239798e5285edec59d")] //for General Queries
    [LuisModel("4360869a-b840-402b-a157-318f612ef7da", "186c630cce0c49239798e5285edec59d")] //for minLawLuis
    [LuisModel("4213f2e2-ca67-4767-90dc-498e5b27aa14", "186c630cce0c49239798e5285edec59d")] //for greeting

    //[LuisModel("1c20602d-a4b5-4195-b157-3796bc219d00", "186c630cce0c49239798e5285edec59")]
    public class LuisDialog : LuisDialog<object>
    {
        public override Task StartAsync(IDialogContext context)
        {
            return base.StartAsync(context);
        }
  
        [LuisIntent("")]
        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            string message = $"Sorry, I did not understand '{result.Query}'. Type 'help' if you need assistance.";

            // alternatively, you could forward to QnA Dialog if no intent is found

            await context.PostAsync(message);

            context.Wait(this.MessageReceived);
        }

        [LuisIntent("greeting")]
        public async Task Greeting(IDialogContext context, LuisResult result)
        {
            string message = $"Hello there";

            await context.PostAsync(message);

            context.Wait(this.MessageReceived);
        }

        private ResumeAfter<object> after()
        {
            return null;
        }

        [LuisIntent("weather")]
        public async Task Middle(IDialogContext context, LuisResult result)
        {
            // confirm we hit weather intent
            string message = $"Weather forecast is...";

            await context.PostAsync(message);

            context.Wait(this.MessageReceived);
        }

        [LuisIntent("Weather.GetForecast")]
        public async Task LanLiangTest(IDialogContext context, LuisResult result)
        {
            // confirm we hit weather intent
            string message = $"Weather forecast is...";

            await context.PostAsync(message);

            context.Wait(this.MessageReceived);
        }

        [LuisIntent("joke")]
        public async Task Joke(IDialogContext context, LuisResult result)
        {
            // confirm we hit joke intent
            string message = $"Let's see...I know a good joke...";

            await context.PostAsync(message);

            await context.Forward(new JokeDialog(), ResumeAfterJokeDialog, context.Activity, CancellationToken.None);
        }

        [LuisIntent("question")]
        public async Task QnA(IDialogContext context, LuisResult result)
        {
            // confirm we hit QnA
            string message = $"Routing to QnA... ";
            await context.PostAsync(message);

            //var userQuestion = (context.Activity as Activity).Text;
            (context.Activity as Activity).Text = "operating hours";
            await context.Forward(new QnaDialog(), ResumeAfterQnA, context.Activity, CancellationToken.None);       
        }

        private async Task ResumeAfterQnA(IDialogContext context, IAwaitable<object> result)
        {
            context.Done<object>(null);
        }

        private async Task ResumeAfterJokeDialog(IDialogContext context, IAwaitable<object> result)
        {
            context.Done<object>(null);
        }

    }
}