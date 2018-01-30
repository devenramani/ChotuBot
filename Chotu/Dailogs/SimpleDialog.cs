using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Bot.Connector;
using System.Text;

namespace Chotu.Dailogs
{
    [Serializable]
    public class SimpleDialog : IDialog
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(ActivityReceivedAsync);
        }

        private async Task ActivityReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            var reply = activity.CreateReply();
            reply.Attachments = new List<Attachment>();

            if (activity.Text.StartsWith("hi"))
            {
                await context.PostAsync($"Hello!");
            }
            else if (activity.Text.StartsWith("how are you"))
            {
                await context.PostAsync($"Perfect");
            }

            await context.PostAsync(reply);
            context.Wait(ActivityReceivedAsync);
        }
    }
}