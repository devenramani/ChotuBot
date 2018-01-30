using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Chotu.Dailogs
{
    [LuisModel("LUIS ID", "SUBSCRIPTION KEY")]
    [Serializable]
    public class LuisDialog : LuisDialog<object>
    {

        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            string message = $"Sorry, I did not understand '{result.Query}'.";

            await context.PostAsync(message);

            context.Wait(this.MessageReceived);
        }

        [LuisIntent("Questions")]
        public async Task getQuestions(IDialogContext context, LuisResult result)
        {
            string message = $"I am fine.";

            await context.PostAsync(message);

            context.Wait(this.MessageReceived);
        }

        [LuisIntent("Greetings")]
        public async Task getGreetings(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Hello!");

            var message = context.MakeMessage();

            message.Attachments = new List<Attachment> {
            new Attachment()
            {
             ContentUrl = "https://media.giphy.com/media/qhCX5tOnFOwGQ/giphy.gif",
             ContentType = "image/jpg",
             Name = "Tachikoma - jpg"
            },
          };
            await context.PostAsync(message);
        }
    }
}