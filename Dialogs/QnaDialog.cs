using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.CognitiveServices.QnAMaker;
using System.Configuration;
using System.Net;

namespace Bot_Application.Dialogs
{
    public class QnaDialog : QnAMakerDialog
    {
        public QnaDialog(): base(
            new QnAMakerService(new QnAMakerAttribute(ConfigurationManager.AppSettings["QnASubscriptionKey"], 
            ConfigurationManager.AppSettings["KnowledgeBaseId"], "Hmm, I wasn't able to find an article about that. Can you try asking in a different way?", 0.5)))
        {
            
        }
        


    }
}